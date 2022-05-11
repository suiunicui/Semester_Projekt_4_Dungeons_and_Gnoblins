#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend_API.Models;
using Backend_API.db;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Backend_API.Models.DTO;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DaG_db _context;

        const int BcryptWorkfactor = 11;


        public UserController(DaG_db context)
        {
            _context = context;
        }

        
        [HttpGet("GetUser")]
        public async Task<ActionResult<UserDTO>> GetUser(string username)
        {
            var user = await _context.Users.FindAsync(username);

            if (user == null)
            {
                return NotFound();
            }
            var userDto = new UserDTO();
            userDto.Username = user.Username;

            return userDto;
        }


        [HttpPost("Register"), AllowAnonymous]

        public async Task<ActionResult<Token>> Register(UserDTO regUser)
        {
            regUser.Username = regUser.Username.ToLower();
            var nameExist = await _context.Users.Where(u => u.Username == regUser.Username).FirstOrDefaultAsync();
            if (nameExist != null)
            {
                return BadRequest(new { errorMessage = "Name is already in use" });
            }
            
            var user = new User()
            {
                Username = regUser.Username,
                
            };


            user.Password = BCrypt.Net.BCrypt.HashPassword(regUser.Password, BcryptWorkfactor);
            _context.Users.Add(user);

            _context.Saves.AddRange(
                new Save { RoomID = 1,SaveName = "NewGame1", Username = user.Username},
                new Save { RoomID = 1, SaveName = "NewGame2", Username = user.Username },
                new Save { RoomID = 1, SaveName = "NewGame3", Username = user.Username },
                new Save { RoomID = 1, SaveName = "NewGame4", Username = user.Username },
                new Save { RoomID = 1, SaveName = "NewGame5", Username = user.Username });

            await _context.SaveChangesAsync();

            var jwtToken = new Token();

            jwtToken.JWT = GenerateToken(regUser);

            return CreatedAtAction("GetUser", new { username = user.Username }, jwtToken);

        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<ActionResult<Token>> Login(UserDTO userDTO)

        {
            userDTO.Username = userDTO.Username.ToLower();
            var user = await _context.Users.Where(u => u.Username == userDTO.Username).FirstOrDefaultAsync();
            if (user != null)
            {
                var isValid = BCrypt.Net.BCrypt.Verify(userDTO.Password, user.Password);
                if (isValid == true)
                {
                    return new Token {JWT = GenerateToken(userDTO)};
                }

            }
            ModelState.AddModelError(string.Empty, "Wrong Username or Password");
            return BadRequest(ModelState);
        }


        private string GenerateToken(UserDTO user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(2)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("adfhsjddsadh@£€{1425452}")),
                SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpPost("jwtlogin"), AllowAnonymous]
        public async Task<IActionResult> JWTlogin([FromBody] UserDTO loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                return BadRequest(ModelState);
            }

            var passwordSignInResult = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
            if (passwordSignInResult.Succeeded)
                return new ObjectResult(GenerateToken(loginUser));
            return BadRequest("Invalid login");
        }


    }
}
