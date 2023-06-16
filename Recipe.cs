using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTry
{
    public class Recipe
    {
        public string Name { get; set; }
        public Dictionary<string, uint> Ingredients { get; set; }

        public Recipe(string name, Dictionary<string, uint> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
}
