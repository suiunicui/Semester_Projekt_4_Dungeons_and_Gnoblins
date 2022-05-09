using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Backend_API.Models
{
    public class Save
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public int RoomID { get; set; }

        public string SaveName { get; set; }


        public List<VisitedRooms> VisitedRooms { get; set; }

    }
}
