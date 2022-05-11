﻿using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }


        [Required]
        [MaxLength(64)]
        public string Password { get; set; }


    }
}
