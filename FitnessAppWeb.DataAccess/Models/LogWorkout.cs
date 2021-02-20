using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class LogWorkout
    {
        public int IdLogWorkout { get; set; }
        public int? Workout { get; set; }
        public int? User { get; set; }
        public DateTime? Date { get; set; }

        public virtual User UserNavigation { get; set; }
        public virtual Workout WorkoutNavigation { get; set; }
    }
}
