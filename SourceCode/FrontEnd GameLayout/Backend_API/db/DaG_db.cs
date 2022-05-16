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
            //Keys
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

            //Rooms
            modelBuilder.Entity<VisitedRooms>()
                .HasKey(x => new { x.SaveId, x.VistedRoomId});

            //Puzzles
            modelBuilder.Entity<Puzzles>()
                            .HasKey(i => new { i.Puzzles_ID, i.Save_ID });
            //Inventory
            modelBuilder.Entity<Inventory_Items>()
                            .HasKey(k => new { k.SaveID, k.ItemID });
            //Enemies
            modelBuilder.Entity<Enemies_killed>()
                            .HasKey(k => new { k.SaveID, k.EnemyID });

            // one to many relationship save vistedRooms
            modelBuilder.Entity<VisitedRooms>()
                .HasOne<Save>(x => x.Save)
                .WithMany(y => y.VisitedRooms)
                .HasForeignKey(x => x.SaveId);

            //many to one
            modelBuilder.Entity<Save>()
                .HasOne<User>(s => s.User)
                .WithMany(s => s.Saves)
                .HasForeignKey(i => i.Username);


            //1 save to many Puzzles
            modelBuilder.Entity<Puzzles>()
                .HasOne<Save>(i => i.save)
                .WithMany(i => i.Save_Puzzles)
                .HasForeignKey(s => s.Save_ID);

            //1 Save to many Items
            modelBuilder.Entity<Inventory_Items>()
                .HasOne<Save>(i => i.save)
                .WithMany(s => s.Save_Inventory_Items)
                .HasForeignKey(s => s.SaveID);

            //1 Save to many Enemies
            modelBuilder.Entity<Enemies_killed>()
                .HasOne<Save>(s => s.save)
                .WithMany(s => s.Save_Enemies_killed)
                .HasForeignKey(i => i.SaveID);


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
                new RoomDescription { RoomDescriptionID = 1, Description = 
                "1: The king has died of a magical curse caused by mysterious powers and a dooming presence is in store for the kingdom of Valirea. The threats of raids and magic power from foreign kingdoms are present and will end all of what you love and cherish. A strange oracle has foreseen that all this can be stopped if the Sword of Destiny is found and kept by the kingdom. The Sword of destiny is enchanted with holy powers and can protect the kingdom from evil. But to retrieve The Sword of Destiny, a mighty and brave warrior must face a trial in the lair of doom. It has been told that many have failed and perished in a attempt to retrieve the sword. You see no other choice and volunteer to save the kingdom of Valirea. You have entered the dark lair to retrieve the Sword of Destiny. The sheer cold and silence gives you discomforting feeling. You ask yourself, Is this really a good idea?. To move to the next room, use the arrow - keys or the move - buttons on the screen." },
                new RoomDescription { RoomDescriptionID = 2, Description = "2. You hear a strange rumble. What is happening? The opening behind you begins to collapse. You sprint to avoid getting smashed by the falling rocks. There's no escape now! You stumble upon a rusty sword on the ground.Might be useful. Use the interact button to pick up found items. Found items can be located and equipped in the inventory. If you wish to view your character's stats, click the character-option.2" },
                new RoomDescription { RoomDescriptionID = 3, Description = "3. That was a strange encounter, but the naked gnoblin is no more. You've made it through to a room with lit torches on the walls. The lit torches reveals blood soaked walls and the thought of you becoming the next victim hits your thoughts.You stumble on a dusty shield in the corner of the room.Might be useful after that encounter." },
                new RoomDescription { RoomDescriptionID = 4, Description = "4. The door revealed a tunnel that led to a poorly lit room. It stinks of rotten flesh and you want to move further into the lair. Which way do you want to go?" },
                new RoomDescription { RoomDescriptionID = 5, Description = "5. This room seems empty and dark. There are writings on the wall and a little door for what you assume is for a dwarf-like creature. You check it out and conclude you can squeeze yourself through the door." },
                new RoomDescription { RoomDescriptionID = 6, Description = "6. The whelps corpse has a weird smell to it. The room leads to another door. What is behind it?" },
                new RoomDescription { RoomDescriptionID = 7, Description = "7. What is this? It looks like a cellar that hasn't been used for quite a while. A corpse is present behind the bars.The corpse has been there for a long time and has rotten down to mere bones.You stumble upon a key and a shield in the hands of the poor creature.Might be useful later." },
                new RoomDescription { RoomDescriptionID = 8, Description = "8. This badly-lit corridor leads to a rusty door. What's behind it?" },
                new RoomDescription { RoomDescriptionID = 9, Description = "9. The room is empty, but leads to another door." },
                new RoomDescription { RoomDescriptionID = 10, Description = "10. It seems you've stumpled upon a dining room. Skeletons are still seated at the table. What the hell happened here? You gaze upon the table and see a key. Might be useful later." },
                new RoomDescription { RoomDescriptionID = 11, Description = "11. Wait, a well? A rope is attached to it so i can climb down. A door is also present. Which way will you go? Either option seems dangerous. " },
                new RoomDescription { RoomDescriptionID = 12, Description = "12. The room is lit by a mysterious item in the middle. This seems important for your journey." },
                new RoomDescription { RoomDescriptionID = 13, Description = "13. The dead naked Gnoblin looks horrendous. That's a sight you don't want to see again." },
                new RoomDescription { RoomDescriptionID = 14, Description = "14. Ew. The room is filled by a stench of rotten flesh. A dead soldier lies in the corner with a battleaxe in hand. It seems well-crafted." },
                new RoomDescription { RoomDescriptionID = 15, Description = "15. The door locks as you enter the room. Something mysterious is happening." },
                new RoomDescription { RoomDescriptionID = 16, Description = "16. The corridor is split between two ways. Which way do you take?" },
                new RoomDescription { RoomDescriptionID = 17, Description = "17. The brute-gnoblin put up a good fight, but it is gone like the others. The room you entered is lit room with torches." },
                new RoomDescription { RoomDescriptionID = 18, Description = "18. A door is present and you need a key. It might be somewhere else in the dungeon. You can sense an evil presence behind the door." },
                new RoomDescription { RoomDescriptionID = 19, Description = "19. The Gnoblin king has been slayed. I can now retrieve the Sword of Destiny." },
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
