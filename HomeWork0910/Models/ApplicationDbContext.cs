using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeWork0910.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Attempt> Attempts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAttemptAnswer> UserAttemptAnswers { get; set; }

    public virtual DbSet<UserSelectedOption> UserSelectedOptions { get; set; }

    public virtual DbSet<UserTextAnswer> UserTextAnswers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=HomeWork0910; Username=postgres;Password=Ananino30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Answers_pkey");

            entity.HasIndex(e => e.IsCorrect, "IX_Answers_IsCorrect");

            entity.HasIndex(e => e.QuestionId, "IX_Answers_QuestionId");

            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.Question).WithMany(p => p.Answers).HasForeignKey(d => d.QuestionId);
        });

        modelBuilder.Entity<Attempt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Attempts_pkey");

            entity.HasIndex(e => e.StartedAt, "IX_Attempts_StartedAt");

            entity.HasIndex(e => e.StudentId, "IX_Attempts_StudentId");

            entity.HasIndex(e => e.SubmittedAt, "IX_Attempts_SubmittedAt");

            entity.HasIndex(e => e.TestId, "IX_Attempts_TestId");

            entity.Property(e => e.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Student).WithMany(p => p.Attempts).HasForeignKey(d => d.StudentId);

            entity.HasOne(d => d.Test).WithMany(p => p.Attempts)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Courses_pkey");

            entity.HasIndex(e => e.Name, "Courses_Name_key").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Directions_pkey");

            entity.HasIndex(e => e.Name, "Directions_Name_key").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Groups_pkey");

            entity.HasIndex(e => e.Name, "Groups_Name_key").IsUnique();

            entity.HasIndex(e => e.CourseId, "IX_Groups_CourseId");

            entity.HasIndex(e => e.DirectionId, "IX_Groups_DirectionId");

            entity.HasIndex(e => e.ProjectId, "IX_Groups_ProjectId");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Course).WithMany(p => p.Groups)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Direction).WithMany(p => p.Groups)
                .HasForeignKey(d => d.DirectionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Project).WithMany(p => p.Groups)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Projects_pkey");

            entity.HasIndex(e => e.Name, "Projects_Name_key").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Questions_pkey");

            entity.HasIndex(e => e.AnswerType, "IX_Questions_AnswerType");

            entity.HasIndex(e => e.TestId, "IX_Questions_TestId");

            entity.HasIndex(e => new { e.TestId, e.Number }, "UK_Questions_TestId_Number").IsUnique();

            entity.Property(e => e.AnswerType).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.IsScoring).HasDefaultValue(true);
            entity.Property(e => e.Text).HasMaxLength(1000);

            entity.HasOne(d => d.Test).WithMany(p => p.Questions).HasForeignKey(d => d.TestId);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Students_pkey");

            entity.HasIndex(e => e.Phone, "IX_Students_Phone");

            entity.HasIndex(e => e.UserId, "IX_Students_UserId");

            entity.HasIndex(e => e.UserId, "Students_UserId_key").IsUnique();

            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.VkProfileLink).HasMaxLength(200);

            entity.HasOne(d => d.User).WithOne(p => p.Student).HasForeignKey<Student>(d => d.UserId);

            entity.HasMany(d => d.Groups).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentGroup",
                    r => r.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    l => l.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j =>
                    {
                        j.HasKey("StudentId", "GroupId");
                        j.ToTable("StudentGroups");
                        j.HasIndex(new[] { "GroupId" }, "IX_StudentGroups_GroupId");
                    });
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tests_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsPublic).HasDefaultValue(false);
            entity.Property(e => e.IsRepeatable).HasDefaultValue(false);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasMany(d => d.Courses).WithMany(p => p.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    l => l.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    j =>
                    {
                        j.HasKey("TestId", "CourseId");
                        j.ToTable("TestCourses");
                        j.HasIndex(new[] { "CourseId" }, "IX_TestCourses_CourseId");
                    });

            entity.HasMany(d => d.Directions).WithMany(p => p.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestDirection",
                    r => r.HasOne<Direction>().WithMany().HasForeignKey("DirectionId"),
                    l => l.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    j =>
                    {
                        j.HasKey("TestId", "DirectionId");
                        j.ToTable("TestDirections");
                        j.HasIndex(new[] { "DirectionId" }, "IX_TestDirections_DirectionId");
                    });

            entity.HasMany(d => d.Groups).WithMany(p => p.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestGroup",
                    r => r.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    l => l.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    j =>
                    {
                        j.HasKey("TestId", "GroupId");
                        j.ToTable("TestGroups");
                        j.HasIndex(new[] { "GroupId" }, "IX_TestGroups_GroupId");
                    });

            entity.HasMany(d => d.Projects).WithMany(p => p.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestProject",
                    r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                    l => l.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    j =>
                    {
                        j.HasKey("TestId", "ProjectId");
                        j.ToTable("TestProjects");
                        j.HasIndex(new[] { "ProjectId" }, "IX_TestProjects_ProjectId");
                    });

            entity.HasMany(d => d.Students).WithMany(p => p.Tests)
                .UsingEntity<Dictionary<string, object>>(
                    "TestStudent",
                    r => r.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    l => l.HasOne<Test>().WithMany().HasForeignKey("TestId"),
                    j =>
                    {
                        j.HasKey("TestId", "StudentId");
                        j.ToTable("TestStudents");
                        j.HasIndex(new[] { "StudentId" }, "IX_TestStudents_StudentId");
                    });
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TestResults_pkey");

            entity.HasIndex(e => e.AttemptId, "IX_TestResults_AttemptId");

            entity.HasIndex(e => e.Passed, "IX_TestResults_Passed");

            entity.HasIndex(e => e.StudentId, "IX_TestResults_StudentId");

            entity.HasIndex(e => e.TestId, "IX_TestResults_TestId");

            entity.HasIndex(e => new { e.TestId, e.StudentId, e.AttemptId }, "UK_TestResults_TestId_StudentId_AttemptId").IsUnique();

            entity.HasOne(d => d.Attempt).WithMany(p => p.TestResults).HasForeignKey(d => d.AttemptId);

            entity.HasOne(d => d.Student).WithMany(p => p.TestResults).HasForeignKey(d => d.StudentId);

            entity.HasOne(d => d.Test).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.HasIndex(e => e.Email, "IX_Users_Email");

            entity.HasIndex(e => e.Login, "IX_Users_Login");

            entity.HasIndex(e => e.Role, "IX_Users_Role");

            entity.HasIndex(e => e.Email, "Users_Email_key").IsUnique();

            entity.HasIndex(e => e.Login, "Users_Login_key").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
        });

        modelBuilder.Entity<UserAttemptAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserAttemptAnswers_pkey");

            entity.HasIndex(e => e.AttemptId, "IX_UserAttemptAnswers_AttemptId");

            entity.HasIndex(e => e.QuestionId, "IX_UserAttemptAnswers_QuestionId");

            entity.HasIndex(e => new { e.AttemptId, e.QuestionId }, "UK_UserAttemptAnswers_AttemptId_QuestionId").IsUnique();

            entity.Property(e => e.ScoreAwarded).HasDefaultValue(0);

            entity.HasOne(d => d.Attempt).WithMany(p => p.UserAttemptAnswers).HasForeignKey(d => d.AttemptId);

            entity.HasOne(d => d.Question).WithMany(p => p.UserAttemptAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UserSelectedOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserSelectedOptions_pkey");

            entity.HasIndex(e => e.AnswerId, "IX_UserSelectedOptions_AnswerId");

            entity.HasIndex(e => e.UserAttemptAnswerId, "IX_UserSelectedOptions_UserAttemptAnswerId");

            entity.HasOne(d => d.Answer).WithMany(p => p.UserSelectedOptions)
                .HasForeignKey(d => d.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.UserAttemptAnswer).WithMany(p => p.UserSelectedOptions).HasForeignKey(d => d.UserAttemptAnswerId);
        });

        modelBuilder.Entity<UserTextAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserTextAnswers_pkey");

            entity.HasIndex(e => e.UserAttemptAnswerId, "UserTextAnswers_UserAttemptAnswerId_key").IsUnique();

            entity.Property(e => e.TextAnswer).HasMaxLength(2000);

            entity.HasOne(d => d.UserAttemptAnswer).WithOne(p => p.UserTextAnswer).HasForeignKey<UserTextAnswer>(d => d.UserAttemptAnswerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
