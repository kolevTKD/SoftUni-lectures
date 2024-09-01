﻿// <auto-generated />
using EntityRelationsTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityRelationsTest.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    partial class DemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityRelationsTest.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddressText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FacultyNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.StudentLecturer", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "LecturerId");

                    b.HasIndex("LecturerId");

                    b.ToTable("StudentLecturer");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Project", b =>
                {
                    b.HasOne("EntityRelationsTest.Models.Student", "Student")
                        .WithMany("Projects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Student", b =>
                {
                    b.HasOne("EntityRelationsTest.Models.Address", "Address")
                        .WithOne("Student")
                        .HasForeignKey("EntityRelationsTest.Models.Student", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.StudentLecturer", b =>
                {
                    b.HasOne("EntityRelationsTest.Models.Student", "Student")
                        .WithMany("StudentLecturer")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityRelationsTest.Models.Lecturer", "Lecturer")
                        .WithMany("StudentLecturer")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Address", b =>
                {
                    b.Navigation("Student")
                        .IsRequired();
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Lecturer", b =>
                {
                    b.Navigation("StudentLecturer");
                });

            modelBuilder.Entity("EntityRelationsTest.Models.Student", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("StudentLecturer");
                });
#pragma warning restore 612, 618
        }
    }
}