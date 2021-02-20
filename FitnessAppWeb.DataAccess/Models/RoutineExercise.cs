using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class RoutineExercise
    {
        public int Routine { get; set; }
        public int Exercise { get; set; }

        public virtual Exercises ExerciseNavigation { get; set; }
        public virtual PersonalRoutine RoutineNavigation { get; set; }
    }
}
