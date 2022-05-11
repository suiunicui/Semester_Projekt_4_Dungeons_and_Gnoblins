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
            modelBuilder.Entity<User>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<Save>()
                .HasKey(x => x.ID);
                
            modelBuilder.Entity<RoomDescription>()
                .HasKey(x => x.RoomDescriptionID);

            modelBuilder.Entity<VisitedRooms>()
                .HasKey(x => new { x.SaveId, x.VistedRoomId});

            // one to many relationship save vistedRooms
            modelBuilder.Entity<VisitedRooms>()
                .HasOne<Save>(x => x.Save)
                .WithMany(y => y.VisitedRooms)
                .HasForeignKey(x => x.SaveId);



            modelBuilder.Entity<Save>()
                .HasData(
                new Save { RoomID = 1, ID = 2, SaveName = "NewGame2", UserId = 1 },
                new Save { RoomID = 1, ID = 1, SaveName = "NewGame1", UserId = 2 },
                new Save { RoomID = 1, ID = 3, SaveName = "NewGame3", UserId = 3 },
                new Save { RoomID = 1, ID = 4, SaveName = "NewGame4", UserId = 4 },
                new Save { RoomID = 1, ID = 5, SaveName = "NewGame5", UserId = 5 }
                );

            modelBuilder.Entity<User>()
                .HasData(
                new User { Username = "Gamer1", Password = "123"});


            modelBuilder.Entity<RoomDescription>()
                .HasData(
                new RoomDescription { RoomDescriptionID = 1, Description = "DB says: This is room 1" },
                new RoomDescription { RoomDescriptionID = 2, Description = "DB says: This is room 2" },
                new RoomDescription { RoomDescriptionID = 3, Description = "DB says: This is room 3" },
                new RoomDescription { RoomDescriptionID = 4, Description = "DB says: This is room 4" },
                new RoomDescription { RoomDescriptionID = 5, Description = "DB says: This is room 5" },
                new RoomDescription { RoomDescriptionID = 6, Description = "DB says: This is room 6" },
                new RoomDescription { RoomDescriptionID = 7, Description = "DB says: This is room 7" },
                new RoomDescription { RoomDescriptionID = 8, Description = "DB says: This is room 8" },
                new RoomDescription { RoomDescriptionID = 9, Description = "DB says: This is room 9" },
                new RoomDescription { RoomDescriptionID = 10, Description = "DB says: This is room 10" },
                new RoomDescription { RoomDescriptionID = 11, Description = "DB says: This is room 11" },
                new RoomDescription { RoomDescriptionID = 12, Description = "DB says: This is room 12" },
                new RoomDescription { RoomDescriptionID = 13, Description = "DB says: This is room 13" },
                new RoomDescription { RoomDescriptionID = 14, Description = "DB says: This is room 14" },
                new RoomDescription { RoomDescriptionID = 15, Description = "DB says: This is room 15" },
                new RoomDescription { RoomDescriptionID = 16, Description = "DB says: This is room 16" },
                new RoomDescription { RoomDescriptionID = 17, Description = "DB says: This is room 17" },
                new RoomDescription { RoomDescriptionID = 18, Description = "DB says: This is room 18" },
                new RoomDescription { RoomDescriptionID = 19, Description = "DB says: This is room 19" },
                new RoomDescription { RoomDescriptionID = 20, Description = "DB says: This is room 20" }
                );
        }


        public DbSet<VisitedRooms> VisitedRooms { get; set; }

        public DbSet<RoomDescription> RoomDescriptions { get; set; }

        public DbSet<Save> Saves { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
