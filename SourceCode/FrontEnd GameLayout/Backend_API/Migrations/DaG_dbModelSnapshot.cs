﻿// <auto-generated />
using System;
using Backend_API.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_API.Migrations
{
    [DbContext(typeof(DaG_db))]
    partial class DaG_dbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Backend_API.Models.RoomDescription", b =>
                {
                    b.Property<int>("RoomDescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomDescriptionID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomDescriptionID");

                    b.ToTable("RoomDescriptions", (string)null);

                    b.HasData(
                        new
                        {
                            RoomDescriptionID = 1,
                            Description = "DB says: This is room 1"
                        },
                        new
                        {
                            RoomDescriptionID = 2,
                            Description = "DB says: This is room 2"
                        },
                        new
                        {
                            RoomDescriptionID = 3,
                            Description = "DB says: This is room 3"
                        },
                        new
                        {
                            RoomDescriptionID = 4,
                            Description = "DB says: This is room 4"
                        },
                        new
                        {
                            RoomDescriptionID = 5,
                            Description = "DB says: This is room 5"
                        },
                        new
                        {
                            RoomDescriptionID = 6,
                            Description = "DB says: This is room 6"
                        },
                        new
                        {
                            RoomDescriptionID = 7,
                            Description = "DB says: This is room 7"
                        },
                        new
                        {
                            RoomDescriptionID = 8,
                            Description = "DB says: This is room 8"
                        },
                        new
                        {
                            RoomDescriptionID = 9,
                            Description = "DB says: This is room 9"
                        },
                        new
                        {
                            RoomDescriptionID = 10,
                            Description = "DB says: This is room 10"
                        },
                        new
                        {
                            RoomDescriptionID = 11,
                            Description = "DB says: This is room 11"
                        },
                        new
                        {
                            RoomDescriptionID = 12,
                            Description = "DB says: This is room 12"
                        },
                        new
                        {
                            RoomDescriptionID = 13,
                            Description = "DB says: This is room 13"
                        },
                        new
                        {
                            RoomDescriptionID = 14,
                            Description = "DB says: This is room 14"
                        },
                        new
                        {
                            RoomDescriptionID = 15,
                            Description = "DB says: This is room 15"
                        },
                        new
                        {
                            RoomDescriptionID = 16,
                            Description = "DB says: This is room 16"
                        },
                        new
                        {
                            RoomDescriptionID = 17,
                            Description = "DB says: This is room 17"
                        },
                        new
                        {
                            RoomDescriptionID = 18,
                            Description = "DB says: This is room 18"
                        },
                        new
                        {
                            RoomDescriptionID = 19,
                            Description = "DB says: This is room 19"
                        },
                        new
                        {
                            RoomDescriptionID = 20,
                            Description = "DB says: This is room 20"
                        });
                });

            modelBuilder.Entity("Backend_API.Models.Save", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<string>("SaveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Saves", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 2,
                            RoomID = 1,
                            SaveName = "NewGame2"
                        },
                        new
                        {
                            ID = 1,
                            RoomID = 1,
                            SaveName = "NewGame1"
                        },
                        new
                        {
                            ID = 3,
                            RoomID = 1,
                            SaveName = "NewGame3"
                        },
                        new
                        {
                            ID = 4,
                            RoomID = 1,
                            SaveName = "NewGame4"
                        },
                        new
                        {
                            ID = 5,
                            RoomID = 1,
                            SaveName = "NewGame5"
                        });
                });

            modelBuilder.Entity("Backend_API.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Backend_API.Models.VisitedRooms", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<long>("VistedRoomId")
                        .HasColumnType("bigint");

                    b.HasKey("SaveId", "VistedRoomId");

                    b.ToTable("VisitedRooms", (string)null);
                });

            modelBuilder.Entity("Backend_API.Models.Save", b =>
                {
                    b.HasOne("Backend_API.Models.User", null)
                        .WithMany("Saves")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Backend_API.Models.VisitedRooms", b =>
                {
                    b.HasOne("Backend_API.Models.Save", "Save")
                        .WithMany("VisitedRooms")
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Save");
                });

            modelBuilder.Entity("Backend_API.Models.Save", b =>
                {
                    b.Navigation("VisitedRooms");
                });

            modelBuilder.Entity("Backend_API.Models.User", b =>
                {
                    b.Navigation("Saves");
                });
#pragma warning restore 612, 618
        }
    }
}
