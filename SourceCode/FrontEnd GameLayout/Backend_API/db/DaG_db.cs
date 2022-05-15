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
                .HasKey(x => x.Username);

            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Username, p.Password }).IsUnique();

            modelBuilder.Entity<Save>()
                .HasKey(x => x.ID);

            modelBuilder.Entity<Save>()
                .HasIndex(n => new { n.SaveName, n.Username }).IsUnique();

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
                .HasOne<User>(s => s.User)
                .WithMany(s => s.Saves)
                .HasForeignKey(i => i.Username);



            modelBuilder.Entity<Save>()
                .HasData(
                new Save { RoomID = 0, ID = 2, SaveName = "NewGame2", Username = "gamer1" },
                new Save { RoomID = 0, ID = 1, SaveName = "NewGame1", Username = "gamer1" },
                new Save { RoomID = 0, ID = 3, SaveName = "NewGame3", Username = "gamer1" },
                new Save { RoomID = 0, ID = 4, SaveName = "NewGame4", Username = "gamer1" },
                new Save { RoomID = 0, ID = 5, SaveName = "NewGame5", Username = "gamer1" }
                );

            modelBuilder.Entity<User>()
                .HasData(
                new User { Username = "Gamer1", Password = BCrypt.Net.BCrypt.HashPassword("123", 11) });


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

        public DbSet<Inventory_Items> Items { get; set; }

        public DbSet<Enemies_killed> Enemies { get; set; }

        public DbSet<Puzzles> Puzzles { get; set; }
    }
}
