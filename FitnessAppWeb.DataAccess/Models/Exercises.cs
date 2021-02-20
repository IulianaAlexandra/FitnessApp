using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class Exercises
    {
        public Exercises()
        {
            LogExercise = new HashSet<LogExercise>();
            RoutineExercise = new HashSet<RoutineExercise>();
            WorkoutExercise = new HashSet<WorkoutExercise>();
        }

        public int IdEx { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string PictureSource { get; set; }
        public string VideoSource { get; set; }
        public int? TargetedGroup { get; set; }
        public int? ExTarget { get; set; }

        public virtual ExTarget ExTargetNavigation { get; set; }
        public virtual MuscleGroups TargetedGroupNavigation { get; set; }
        public virtual ICollection<LogExercise> LogExercise { get; set; }
        public virtual ICollection<RoutineExercise> RoutineExercise { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutExercise { get; set; }
    }
}
