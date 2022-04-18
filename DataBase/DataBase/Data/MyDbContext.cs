﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Models
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ProjektDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Save>()
                .HasKey(k => k.ID);


            modelBuilder.Entity<Save>()
                .HasData(
                new Save { RoomID = 14, ID = 2 },
                new Save { RoomID = 12, ID = 1 },
                new Save { RoomID = 3, ID = 3 },
                new Save { RoomID = 4, ID = 4 },
                new Save { RoomID = 5, ID = 5 }
                );
        }

        public DbSet<Save> Saves { get; set; }

    }
}