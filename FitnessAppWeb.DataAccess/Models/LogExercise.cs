using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class LogExercise
    {
        public int IdLogEx { get; set; }
        public int? Exercise { get; set; }
        public int? User { get; set; }
        public DateTime? Date { get; set; }

        public virtual Exercises ExerciseNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
