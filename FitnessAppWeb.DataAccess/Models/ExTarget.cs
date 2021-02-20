using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class ExTarget
    {
        public ExTarget()
        {
            Exercises = new HashSet<Exercises>();
        }

        public int IdExTarget { get; set; }
        public int? NumberOfSets { get; set; }
        public int? Set { get; set; }

        public virtual SetTarget SetNavigation { get; set; }
        public virtual ICollection<Exercises> Exercises { get; set; }
    }
}
