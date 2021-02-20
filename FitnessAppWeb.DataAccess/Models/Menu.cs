using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class Menu
    {
        public int IdMenu { get; set; }
        public string Date { get; set; }
        public DateTime? Menucol { get; set; }
        public int? Breakfast { get; set; }
        public int? Lunch { get; set; }
        public int? Dinner { get; set; }

        public virtual Recipe BreakfastNavigation { get; set; }
        public virtual Recipe DinnerNavigation { get; set; }
        public virtual Recipe LunchNavigation { get; set; }
    }
}
