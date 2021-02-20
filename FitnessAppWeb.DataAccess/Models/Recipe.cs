using System;
using System.Collections.Generic;

namespace FitnessAppWebAPI.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            MenuBreakfastNavigation = new HashSet<Menu>();
            MenuDinnerNavigation = new HashSet<Menu>();
            MenuLunchNavigation = new HashSet<Menu>();
        }

        public int IdRecipe { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PictureSource { get; set; }

        public virtual ICollection<Menu> MenuBreakfastNavigation { get; set; }
        public virtual ICollection<Menu> MenuDinnerNavigation { get; set; }
        public virtual ICollection<Menu> MenuLunchNavigation { get; set; }
    }
}
