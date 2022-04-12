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


namespace Backend_API.Controllers
{

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


        [HttpPost("register"), AllowAnonymous]

        public async Task<ActionResult<Token>> Register(User regUser)
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

            await _context.SaveChangesAsync();

            var jwtToken = new Token();

            jwtToken.JWT = GenerateToken(user);

            return CreatedAtAction("Get", new { userName = user.Username }, jwtToken);

        }

        private string GenerateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(2)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("")),
                SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpPost("jwtlogin"), AllowAnonymous]
        public async Task<IActionResult> JWTlogin([FromBody] User loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Username");
                return BadRequest();
            }

            var passwordSignInResult = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password
                                                                    , false);
            if (passwordSignInResult.Succeeded)
                return new ObjectResult(GenerateToken(loginUser));
            return BadRequest("Invalid login");
        }

        //[HttpPost("login"), AllowAnonymous]
        //public async Task<ActionResult<Token>> Login(LoginUser login)

        //{

        //}
    }
}
