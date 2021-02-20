using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class Workout
    {
        public Workout()
        {
            LogWorkout = new HashSet<LogWorkout>();
            WorkoutExercise = new HashSet<WorkoutExercise>();
        }

        public int IdWorkout { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureSource { get; set; }
        public string DifficultyLevel { get; set; }
        public int? Duration { get; set; }
        public int? TargetedGroup { get; set; }

        public virtual MuscleGroups TargetedGroupNavigation { get; set; }
        public virtual ICollection<LogWorkout> LogWorkout { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutExercise { get; set; }
    }
}
