using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class SetTarget
    {
        public SetTarget()
        {
            ExTarget = new HashSet<ExTarget>();
        }

        public int IdSet { get; set; }
        public int? SetDuration { get; set; }
        public int? PauseDuration { get; set; }

        public virtual ICollection<ExTarget> ExTarget { get; set; }
    }
}
