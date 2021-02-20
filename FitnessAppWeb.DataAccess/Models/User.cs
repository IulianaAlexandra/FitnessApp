using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class User
    {
        public User()
        {
            LogExercise = new HashSet<LogExercise>();
            LogWorkout = new HashSet<LogWorkout>();
            PersonalRoutine = new HashSet<PersonalRoutine>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LogExercise> LogExercise { get; set; }
        public virtual ICollection<LogWorkout> LogWorkout { get; set; }
        public virtual ICollection<PersonalRoutine> PersonalRoutine { get; set; }
    }
}
