using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class MuscleGroups
    {
        public MuscleGroups()
        {
            Exercises = new HashSet<Exercises>();
            Workout = new HashSet<Workout>();
        }

        public int IdGroup { get; set; }
        public string GroupName { get; set; }
        public string GroupPicture { get; set; }

        public virtual ICollection<Exercises> Exercises { get; set; }
        public virtual ICollection<Workout> Workout { get; set; }
    }
}
