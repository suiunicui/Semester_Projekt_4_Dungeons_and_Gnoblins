using Backend_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_API.db
{
    public class DaG_db : DbContext
    { 
        public DaG_db(DbContextOptions<DaG_db> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Save>()
                .HasKey(k => k.ID);

            modelBuilder.Entity<RoomDescription>()
                .HasKey(x => x.RoomDescriptionID);

            modelBuilder.Entity<Save>()
                .HasData(
                new Save { RoomID = 14, ID = 2, SaveName = "LuyenGame1" },
                new Save { RoomID = 12, ID = 1, SaveName = "AndersGame2" },
                new Save { RoomID = 3, ID = 3, SaveName = "MortenGame" },
                new Save { RoomID = 4, ID = 4, SaveName = "ODGame" },
                new Save { RoomID = 5, ID = 5, SaveName = "SuneGame" }
                );

            modelBuilder.Entity<RoomDescription>()
                .HasData(
                new RoomDescription { RoomDescriptionID = 1, Description = "This is room 1" },
                new RoomDescription { RoomDescriptionID = 2, Description = "This is room 2" },
                new RoomDescription { RoomDescriptionID = 3, Description = "This is room 3" },
                new RoomDescription { RoomDescriptionID = 4, Description = "This is room 4" },
                new RoomDescription { RoomDescriptionID = 5, Description = "This is room 5" },
                new RoomDescription { RoomDescriptionID = 6, Description = "This is room 6" },
                new RoomDescription { RoomDescriptionID = 7, Description = "This is room 7" },
                new RoomDescription { RoomDescriptionID = 8, Description = "This is room 8" },
                new RoomDescription { RoomDescriptionID = 9, Description = "This is room 9" },
                new RoomDescription { RoomDescriptionID = 10, Description = "This is room 10" },
                new RoomDescription { RoomDescriptionID = 11, Description = "This is room 11" },
                new RoomDescription { RoomDescriptionID = 12, Description = "This is room 12" },
                new RoomDescription { RoomDescriptionID = 13, Description = "This is room 13" },
                new RoomDescription { RoomDescriptionID = 14, Description = "This is room 14" },
                new RoomDescription { RoomDescriptionID = 15, Description = "This is room 15" },
                new RoomDescription { RoomDescriptionID = 16, Description = "This is room 16" },
                new RoomDescription { RoomDescriptionID = 17, Description = "This is room 17" },
                new RoomDescription { RoomDescriptionID = 18, Description = "This is room 18" },
                new RoomDescription { RoomDescriptionID = 19, Description = "This is room 19" },
                new RoomDescription { RoomDescriptionID = 20, Description = "This is room 20" }
                );
        }




        public DbSet<RoomDescription> RoomDescriptions { get; set; }

        public DbSet<Save> Saves { get; set; }

        //public DbSet<User> Users { get; set; }

    }
}
