using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class WorkoutExercise
    {
        public int IdEx { get; set; }
        public int IdWorkout { get; set; }

        public virtual Exercises IdExNavigation { get; set; }
        public virtual Workout IdWorkoutNavigation { get; set; }
    }
}
