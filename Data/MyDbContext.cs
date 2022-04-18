using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektLeg.Models;

namespace ProjektLeg
{
 
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=127.0.0.1,1433;Database=ProjektDb;User ID=SA;Password=Engelund99;");

            //optionsBuilder.UseInMemoryDatabase("DbLeg");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /****************KEYS****************/

            //User
            modelBuilder.Entity<User>()
                            .HasKey(k => k.Username);
            
            modelBuilder.Entity<User>()
                            .HasIndex(p => new { p.Username, p.Password }).IsUnique();

            //Save
            modelBuilder.Entity<Save>()
                            .HasKey(k => k.SaveID);

            modelBuilder.Entity<Save>()
                .HasIndex(n => new { n.SaveName, n.name }).IsUnique();

            //Puzzles
            modelBuilder.Entity<Puzzles>()
                            .HasKey(i => new { i.Puzzles_ID, i.Save_ID});
            //Inventory
            modelBuilder.Entity<Inventory_Items>()
                            .HasKey(k => new {k.SaveID, k.ItemID});
            //Enemies
            modelBuilder.Entity<Enemies_killed>()
                            .HasKey(k => new { k.SaveID, k.EnemyID });

           


            /****************Relations****************/
            //1 User to many Saves
            modelBuilder.Entity<Save>()
                .HasOne<User>(s => s.user)
                .WithMany(s => s.Saves)
                .HasForeignKey(i => i.name);

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

            /****************Starup Data****************/

            
        }

        public DbSet<Save> Saves { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Inventory_Items> Items { get; set; }

        public DbSet<Enemies_killed> Enemies { get; set; } 

        public DbSet<Puzzles> Puzzles { get; set; }
    }

}
