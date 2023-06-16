using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTry.Interfaces;

namespace MultiTry.Staff
{
    public class Chef : IStaff
    {
        public delegate void DishPreparedHandler(string chefName, string dishName);
        public event DishPreparedHandler? DishPrepared;

        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public Dictionary<string, Recipe> Recipes { get; set; } = new Dictionary<string, Recipe>();

        public Chef(string name, Dictionary<string, Recipe> recipes = null)
        {
            Name = name;
            Recipes = recipes ?? new Dictionary<string, Recipe>();
        }

        public void Cook(string dishName)
        {
            if (!Recipes.ContainsKey(dishName))
            {
                throw new Exception("Recipe not found");
            }

            Recipe recipe = Recipes[dishName];
            foreach (var ingredient in recipe.Ingredients)
            {
                PizzeriaData.IngredientStorage.TakeIngredient(ingredient.Key, ingredient.Value);
            }

            Thread.Sleep(3000); // симуляція часу приготування
            PizzeriaData.IngredientStorage.PutDish(dishName);
            DishPrepared?.Invoke(Name, dishName);
            IsBusy = false;  // зайнятість кухаря негативна
        }


        public string Info
        {
            get
            {
                string dishes = string.Join(", ", Recipes.Keys);
                return $"{Name}'s dishes: {dishes}";
            }
        }
    }
}
