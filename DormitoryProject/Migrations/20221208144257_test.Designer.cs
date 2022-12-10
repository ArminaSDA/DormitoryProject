﻿// <auto-generated />
using System;
using DormitoryProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DormitoryProject.Migrations
{
    [DbContext(typeof(DormitoryContext))]
    [Migration("20221208144257_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("StudentId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Dormitory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Dormitories");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DormitoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DormitoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Announcement", b =>
                {
                    b.HasOne("DormitoryProject.DAL.Entities.Room", "Room")
                        .WithMany("Announcements")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_Announcements_Rooms");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Application", b =>
                {
                    b.HasOne("DormitoryProject.DAL.Entities.Announcement", "Announcement")
                        .WithMany("Applications")
                        .HasForeignKey("AnnouncementId")
                        .IsRequired()
                        .HasConstraintName("FK_Applications_Announcements");

                    b.HasOne("DormitoryProject.DAL.Entities.Student", "Student")
                        .WithMany("Applications")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Applications_Students");

                    b.Navigation("Announcement");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Room", b =>
                {
                    b.HasOne("DormitoryProject.DAL.Entities.Dormitory", "Dormitory")
                        .WithMany("Rooms")
                        .HasForeignKey("DormitoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Rooms_Dormitories");

                    b.Navigation("Dormitory");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Announcement", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Dormitory", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Room", b =>
                {
                    b.Navigation("Announcements");
                });

            modelBuilder.Entity("DormitoryProject.DAL.Entities.Student", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
