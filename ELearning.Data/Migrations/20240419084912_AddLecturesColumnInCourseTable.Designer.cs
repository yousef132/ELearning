﻿// <auto-generated />
using System;
using ELearning.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ELearning.Data.Migrations
{
    [DbContext(typeof(ELearningDbContext))]
    [Migration("20240419084912_AddLecturesColumnInCourseTable")]
    partial class AddLecturesColumnInCourseTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ELearning.Data.Entities.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lectures")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Question.BaseQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RightAnswer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("BaseQuestions");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentAssignment", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<double>("Mark")
                        .HasColumnType("float");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("StudentAssignments");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentCourse", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentExam", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "ExamId");

                    b.HasIndex("ExamId");

                    b.ToTable("StudentExams");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentQuestion", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BaseQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentAnswerId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BaseQuestionId");

                    b.HasIndex("BaseQuestionId");

                    b.ToTable("StudentQuestions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ELearning.Data.Context.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Assignment", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ELearning.Data.Entities.TimedEntity", "TimedEntity", b1 =>
                        {
                            b1.Property<int>("AssignmentId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Close")
                                .HasColumnType("datetime2");

                            b1.Property<double>("Grade")
                                .HasColumnType("float");

                            b1.Property<DateTime>("Open")
                                .HasColumnType("datetime2");

                            b1.HasKey("AssignmentId");

                            b1.ToTable("Assignments");

                            b1.WithOwner()
                                .HasForeignKey("AssignmentId");
                        });

                    b.Navigation("Course");

                    b.Navigation("TimedEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("ELearning.Data.Entities.Attachment", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearning.Data.Entities.Course", "Course")
                        .WithMany("Attachments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Course", b =>
                {
                    b.HasOne("ELearning.Data.Context.ApplicationUser", "User")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Exam", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ELearning.Data.Entities.TimedEntity", "TimedEntity", b1 =>
                        {
                            b1.Property<int>("ExamId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Close")
                                .HasColumnType("datetime2");

                            b1.Property<double>("Grade")
                                .HasColumnType("float");

                            b1.Property<DateTime>("Open")
                                .HasColumnType("datetime2");

                            b1.HasKey("ExamId");

                            b1.ToTable("Exams");

                            b1.WithOwner()
                                .HasForeignKey("ExamId");
                        });

                    b.Navigation("Course");

                    b.Navigation("TimedEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("ELearning.Data.Entities.Question.BaseQuestion", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Exam", "Exam")
                        .WithMany("BaseQuestions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("ELearning.Data.Entities.Choice", "Choices", b1 =>
                        {
                            b1.Property<int>("BaseQuestionId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int>("Answer")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BaseQuestionId", "Id");

                            b1.ToTable("Choices");

                            b1.WithOwner()
                                .HasForeignKey("BaseQuestionId");
                        });

                    b.Navigation("Choices");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentAssignment", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Assignment", "Assignment")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearning.Data.Context.ApplicationUser", "User")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentCourse", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearning.Data.Context.ApplicationUser", "User")
                        .WithMany("StudentCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentExam", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Exam", "Exam")
                        .WithMany("StudentExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearning.Data.Context.ApplicationUser", "User")
                        .WithMany("StudentExams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearning.Data.Entities.StudentQuestion", b =>
                {
                    b.HasOne("ELearning.Data.Entities.Question.BaseQuestion", "BaseQuestion")
                        .WithMany("StudentQuestions")
                        .HasForeignKey("BaseQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearning.Data.Context.ApplicationUser", "User")
                        .WithMany("StudentQuestions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseQuestion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ELearning.Data.Entities.Assignment", b =>
                {
                    b.Navigation("StudentAssignments");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Attachments");

                    b.Navigation("Exams");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Exam", b =>
                {
                    b.Navigation("BaseQuestions");

                    b.Navigation("StudentExams");
                });

            modelBuilder.Entity("ELearning.Data.Entities.Question.BaseQuestion", b =>
                {
                    b.Navigation("StudentQuestions");
                });

            modelBuilder.Entity("ELearning.Data.Context.ApplicationUser", b =>
                {
                    b.Navigation("StudentAssignments");

                    b.Navigation("StudentCourses");

                    b.Navigation("StudentExams");

                    b.Navigation("StudentQuestions");

                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
