using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnessAppWebAPI.Models
{
    public partial class improvedfitnessappContext : DbContext
    {
        public improvedfitnessappContext()
        {
        }

        public improvedfitnessappContext(DbContextOptions<improvedfitnessappContext> options)
            : base(options)
        {
        }

        public virtual ISet<ExTarget> ExTarget { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<LogExercise> LogExercise { get; set; }
        public virtual DbSet<LogWorkout> LogWorkout { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MuscleGroups> MuscleGroup { get; set; }
        public virtual DbSet<PersonalRoutine> PersonalRoutine { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RoutineExercise> RoutineExercise { get; set; }
        public virtual DbSet<SetTarget> SetTarget { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workout> Workout { get; set; }
        public virtual DbSet<WorkoutExercise> WorkoutExercise { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("User=root;Server=localhost;Password=aparatfoto17!;Database=improvedfitnessapp;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExTarget>(entity =>
            {
                entity.HasKey(e => e.IdExTarget)
                    .HasName("PRIMARY");

                entity.ToTable("ex_target");

                entity.HasIndex(e => e.Set)
                    .HasName("set_fk_idx");

                entity.Property(e => e.IdExTarget).HasColumnName("id_ex_target");

                entity.Property(e => e.NumberOfSets).HasColumnName("number_of_sets");

                entity.Property(e => e.Set).HasColumnName("set");

                entity.HasOne(d => d.SetNavigation)
                    .WithMany(p => p.ExTarget)
                    .HasForeignKey(d => d.Set)
                    .HasConstraintName("set_fk");
            });

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.HasKey(e => e.IdEx)
                    .HasName("PRIMARY");

                entity.ToTable("exercises");

                entity.HasIndex(e => e.ExTarget)
                    .HasName("ex_target_ex_fk_idx");

                entity.HasIndex(e => e.TargetedGroup)
                    .HasName("ex_group_fk_idx");

                entity.Property(e => e.IdEx).HasColumnName("id_ex");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ExTarget).HasColumnName("ex_target");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PictureSource)
                    .HasColumnName("picture_source")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TargetedGroup).HasColumnName("targeted_group");

                entity.Property(e => e.VideoSource)
                    .HasColumnName("video_source")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExTargetNavigation)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.ExTarget)
                    .HasConstraintName("ex_target_ex_fk");

                entity.HasOne(d => d.TargetedGroupNavigation)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.TargetedGroup)
                    .HasConstraintName("ex_group_fk");
            });

            modelBuilder.Entity<LogExercise>(entity =>
            {
                entity.HasKey(e => e.IdLogEx)
                    .HasName("PRIMARY");

                entity.ToTable("log_exercise");

                entity.HasIndex(e => e.Exercise)
                    .HasName("log_ex_fk_idx");

                entity.HasIndex(e => e.User)
                    .HasName("log_user_fk_idx");

                entity.Property(e => e.IdLogEx).HasColumnName("id_log_ex");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Exercise).HasColumnName("exercise");

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.ExerciseNavigation)
                    .WithMany(p => p.LogExercise)
                    .HasForeignKey(d => d.Exercise)
                    .HasConstraintName("log_ex_fk");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.LogExercise)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("log_user_fk");
            });

            modelBuilder.Entity<LogWorkout>(entity =>
            {
                entity.HasKey(e => e.IdLogWorkout)
                    .HasName("PRIMARY");

                entity.ToTable("log_workout");

                entity.HasIndex(e => e.User)
                    .HasName("log_workout_user_idx");

                entity.HasIndex(e => e.Workout)
                    .HasName("workout_log_fk_idx");

                entity.Property(e => e.IdLogWorkout).HasColumnName("id_log_workout");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.User).HasColumnName("user");

                entity.Property(e => e.Workout).HasColumnName("workout");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.LogWorkout)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("log_workout_user");

                entity.HasOne(d => d.WorkoutNavigation)
                    .WithMany(p => p.LogWorkout)
                    .HasForeignKey(d => d.Workout)
                    .HasConstraintName("workout_log_fk");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PRIMARY");

                entity.ToTable("menu");

                entity.HasIndex(e => e.Breakfast)
                    .HasName("breakfast_fk_idx");

                entity.HasIndex(e => e.Dinner)
                    .HasName("dinner_fk_idx");

                entity.HasIndex(e => e.Lunch)
                    .HasName("lunch_fk_idx");

                entity.Property(e => e.IdMenu).HasColumnName("id_menu");

                entity.Property(e => e.Breakfast).HasColumnName("breakfast");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Dinner).HasColumnName("dinner");

                entity.Property(e => e.Lunch).HasColumnName("lunch");

                entity.Property(e => e.Menucol).HasColumnName("menucol");

                entity.HasOne(d => d.BreakfastNavigation)
                    .WithMany(p => p.MenuBreakfastNavigation)
                    .HasForeignKey(d => d.Breakfast)
                    .HasConstraintName("breakfast_fk");

                entity.HasOne(d => d.DinnerNavigation)
                    .WithMany(p => p.MenuDinnerNavigation)
                    .HasForeignKey(d => d.Dinner)
                    .HasConstraintName("dinner_fk");

                entity.HasOne(d => d.LunchNavigation)
                    .WithMany(p => p.MenuLunchNavigation)
                    .HasForeignKey(d => d.Lunch)
                    .HasConstraintName("lunch_fk");
            });

            modelBuilder.Entity<MuscleGroups>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("PRIMARY");

                entity.ToTable("muscle_groups");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.GroupName)
                    .HasColumnName("group_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GroupPicture)
                    .HasColumnName("group_picture")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonalRoutine>(entity =>
            {
                entity.HasKey(e => e.IdRoutine)
                    .HasName("PRIMARY");

                entity.ToTable("personal_routine");

                entity.HasIndex(e => e.User)
                    .HasName("ex_user_fk_idx");

                entity.Property(e => e.IdRoutine).HasColumnName("id_routine");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalRoutinecol)
                    .HasColumnName("personal_routinecol")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.PersonalRoutine)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("ex_user_fk");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.IdRecipe)
                    .HasName("PRIMARY");

                entity.ToTable("recipe");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PictureSource)
                    .HasColumnName("picture_source")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoutineExercise>(entity =>
            {
                entity.HasKey(e => new { e.Routine, e.Exercise })
                    .HasName("PRIMARY");

                entity.ToTable("routine_exercise");

                entity.HasIndex(e => e.Exercise)
                    .HasName("routine_ex_fk2_idx");

                entity.Property(e => e.Routine).HasColumnName("routine");

                entity.Property(e => e.Exercise).HasColumnName("exercise");

                entity.HasOne(d => d.ExerciseNavigation)
                    .WithMany(p => p.RoutineExercise)
                    .HasForeignKey(d => d.Exercise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("routine_ex_fk2");

                entity.HasOne(d => d.RoutineNavigation)
                    .WithMany(p => p.RoutineExercise)
                    .HasForeignKey(d => d.Routine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("routine_ex_fk1");
            });

            modelBuilder.Entity<SetTarget>(entity =>
            {
                entity.HasKey(e => e.IdSet)
                    .HasName("PRIMARY");

                entity.ToTable("set_target");

                entity.Property(e => e.IdSet).HasColumnName("id_set");

                entity.Property(e => e.PauseDuration).HasColumnName("pause_duration");

                entity.Property(e => e.SetDuration).HasColumnName("set_duration");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasKey(e => e.IdWorkout)
                    .HasName("PRIMARY");

                entity.ToTable("workout");

                entity.HasIndex(e => e.TargetedGroup)
                    .HasName("workout_group_fk_idx");

                entity.Property(e => e.IdWorkout).HasColumnName("id_workout");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DifficultyLevel)
                    .HasColumnName("difficulty_level")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PictureSource)
                    .HasColumnName("picture_source")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TargetedGroup).HasColumnName("targeted_group");

                entity.HasOne(d => d.TargetedGroupNavigation)
                    .WithMany(p => p.Workout)
                    .HasForeignKey(d => d.TargetedGroup)
                    .HasConstraintName("workout_group_fk");
            });

            modelBuilder.Entity<WorkoutExercise>(entity =>
            {
                entity.HasKey(e => new { e.IdEx, e.IdWorkout })
                    .HasName("PRIMARY");

                entity.ToTable("workout_exercise");

                entity.HasIndex(e => e.IdWorkout)
                    .HasName("ex_workout_fk1_idx");

                entity.Property(e => e.IdEx).HasColumnName("id_ex");

                entity.Property(e => e.IdWorkout).HasColumnName("id_workout");

                entity.HasOne(d => d.IdExNavigation)
                    .WithMany(p => p.WorkoutExercise)
                    .HasForeignKey(d => d.IdEx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ex_workout_fk2");

                entity.HasOne(d => d.IdWorkoutNavigation)
                    .WithMany(p => p.WorkoutExercise)
                    .HasForeignKey(d => d.IdWorkout)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ex_workout_fk1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
