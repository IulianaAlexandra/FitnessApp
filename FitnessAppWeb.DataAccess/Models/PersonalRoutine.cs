using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class PersonalRoutine
    {
        public PersonalRoutine()
        {
            RoutineExercise = new HashSet<RoutineExercise>();
        }

        public int IdRoutine { get; set; }
        public int? User { get; set; }
        public DateTime? Date { get; set; }
        public string PersonalRoutinecol { get; set; }
        public string Name { get; set; }

        public virtual User UserNavigation { get; set; }
        public virtual ICollection<RoutineExercise> RoutineExercise { get; set; }
    }
}
