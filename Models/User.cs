using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLeg.Models
{
    public class User
    {
        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        public List<Save> Saves { get; set; }

    }

}
