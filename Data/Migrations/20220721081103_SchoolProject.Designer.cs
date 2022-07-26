﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20220721081103_SchoolProject")]
    partial class SchoolProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("YearGroupId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("YearGroupId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"),
                            FirstName = "Ben",
                            LastName = "Sztucki",
                            UserTypeId = 1
                        },
                        new
                        {
                            UserId = new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1"),
                            FirstName = "Luke",
                            LastName = "Dallimore",
                            UserTypeId = 2,
                            YearGroupId = 1
                        },
                        new
                        {
                            UserId = new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53"),
                            FirstName = "Mike",
                            LastName = "Prosser",
                            UserTypeId = 2,
                            YearGroupId = 2
                        },
                        new
                        {
                            UserId = new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f"),
                            FirstName = "Maddie",
                            LastName = "Williams",
                            UserTypeId = 2,
                            YearGroupId = 3
                        },
                        new
                        {
                            UserId = new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b"),
                            FirstName = "Sarah",
                            LastName = "Williams",
                            UserTypeId = 2,
                            YearGroupId = 4
                        },
                        new
                        {
                            UserId = new Guid("39b79056-d79a-4672-a068-104cc3d77116"),
                            FirstName = "Jamie",
                            LastName = "Buckley",
                            UserTypeId = 2,
                            YearGroupId = 5
                        });
                });

            modelBuilder.Entity("Models.Entities.Class", b =>
                {
                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "SchoolId");

                    b.ToTable("Class");

                    b.HasData(
                        new
                        {
                            ClassId = "A1",
                            SchoolId = 1
                        },
                        new
                        {
                            ClassId = "A2",
                            SchoolId = 1
                        },
                        new
                        {
                            ClassId = "A3",
                            SchoolId = 1
                        },
                        new
                        {
                            ClassId = "A4",
                            SchoolId = 1
                        },
                        new
                        {
                            ClassId = "B1",
                            SchoolId = 2
                        },
                        new
                        {
                            ClassId = "B2",
                            SchoolId = 2
                        },
                        new
                        {
                            ClassId = "B3",
                            SchoolId = 2
                        },
                        new
                        {
                            ClassId = "B4",
                            SchoolId = 2
                        },
                        new
                        {
                            ClassId = "C1",
                            SchoolId = 3
                        },
                        new
                        {
                            ClassId = "C2",
                            SchoolId = 3
                        },
                        new
                        {
                            ClassId = "C3",
                            SchoolId = 3
                        },
                        new
                        {
                            ClassId = "C4",
                            SchoolId = 3
                        });
                });

            modelBuilder.Entity("Models.Entities.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("School");

                    b.HasData(
                        new
                        {
                            SchoolId = 1,
                            Address = "Address",
                            Name = "Test name"
                        },
                        new
                        {
                            SchoolId = 2,
                            Address = "Address",
                            Name = "Test name 2"
                        },
                        new
                        {
                            SchoolId = 3,
                            Address = "Address 3",
                            Name = "Test name 3"
                        });
                });

            modelBuilder.Entity("Models.Entities.UserClass", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId", "SchoolId");

                    b.HasIndex("ClassId", "SchoolId");

                    b.ToTable("UserClass");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"),
                            ClassId = "A1",
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"),
                            ClassId = "A2",
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"),
                            ClassId = "A3",
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1"),
                            ClassId = "A1",
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1"),
                            ClassId = "A2",
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53"),
                            ClassId = "B1",
                            SchoolId = 2
                        },
                        new
                        {
                            UserId = new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53"),
                            ClassId = "B2",
                            SchoolId = 2
                        },
                        new
                        {
                            UserId = new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f"),
                            ClassId = "B1",
                            SchoolId = 2
                        },
                        new
                        {
                            UserId = new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f"),
                            ClassId = "B2",
                            SchoolId = 2
                        },
                        new
                        {
                            UserId = new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b"),
                            ClassId = "C1",
                            SchoolId = 3
                        },
                        new
                        {
                            UserId = new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b"),
                            ClassId = "C2",
                            SchoolId = 3
                        },
                        new
                        {
                            UserId = new Guid("39b79056-d79a-4672-a068-104cc3d77116"),
                            ClassId = "C1",
                            SchoolId = 3
                        },
                        new
                        {
                            UserId = new Guid("39b79056-d79a-4672-a068-104cc3d77116"),
                            ClassId = "C2",
                            SchoolId = 3
                        });
                });

            modelBuilder.Entity("Models.Entities.UserSchool", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SchoolId");

                    b.HasIndex("SchoolId");

                    b.ToTable("UserSchool");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"),
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1"),
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53"),
                            SchoolId = 2
                        },
                        new
                        {
                            UserId = new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f"),
                            SchoolId = 2
                        },
                        new
                        {
                            UserId = new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b"),
                            SchoolId = 3
                        },
                        new
                        {
                            UserId = new Guid("39b79056-d79a-4672-a068-104cc3d77116"),
                            SchoolId = 3
                        });
                });

            modelBuilder.Entity("Models.Entities.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserType");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            Name = "Teacher"
                        },
                        new
                        {
                            UserTypeId = 2,
                            Name = "Pupil"
                        });
                });

            modelBuilder.Entity("Models.Entities.YearGroup", b =>
                {
                    b.Property<int>("YearGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YearGroupId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YearGroupId");

                    b.ToTable("YearGroup");

                    b.HasData(
                        new
                        {
                            YearGroupId = 1,
                            Name = "Year 1"
                        },
                        new
                        {
                            YearGroupId = 2,
                            Name = "Year 2"
                        },
                        new
                        {
                            YearGroupId = 3,
                            Name = "Year 3"
                        },
                        new
                        {
                            YearGroupId = 4,
                            Name = "Year 4"
                        },
                        new
                        {
                            YearGroupId = 5,
                            Name = "Year 5"
                        },
                        new
                        {
                            YearGroupId = 6,
                            Name = "Year 6"
                        },
                        new
                        {
                            YearGroupId = 7,
                            Name = "Year 7"
                        },
                        new
                        {
                            YearGroupId = 8,
                            Name = "Year 8"
                        },
                        new
                        {
                            YearGroupId = 9,
                            Name = "Year 9"
                        },
                        new
                        {
                            YearGroupId = 10,
                            Name = "Year 10"
                        },
                        new
                        {
                            YearGroupId = 11,
                            Name = "Year 11"
                        },
                        new
                        {
                            YearGroupId = 12,
                            Name = "Year 12"
                        },
                        new
                        {
                            YearGroupId = 13,
                            Name = "Year 13"
                        });
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.HasOne("Models.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.YearGroup", "YearGroup")
                        .WithMany("Users")
                        .HasForeignKey("YearGroupId");

                    b.Navigation("UserType");

                    b.Navigation("YearGroup");
                });

            modelBuilder.Entity("Models.Entities.UserClass", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("UserClasses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Class", "Class")
                        .WithMany("UserClasses")
                        .HasForeignKey("ClassId", "SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.UserSchool", b =>
                {
                    b.HasOne("Models.Entities.School", "School")
                        .WithMany("UserSchools")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("UserSchools")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("UserClasses");

                    b.Navigation("UserSchools");
                });

            modelBuilder.Entity("Models.Entities.Class", b =>
                {
                    b.Navigation("UserClasses");
                });

            modelBuilder.Entity("Models.Entities.School", b =>
                {
                    b.Navigation("UserSchools");
                });

            modelBuilder.Entity("Models.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Models.Entities.YearGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
