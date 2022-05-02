﻿using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    public class User
    {
        public long UserId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public string PasswordHash { get; set; }

        public List<Save> Saves { get; set; }

    }
}
