using MultiTry.Staff;

namespace MultiTry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pizzaIngredients = new Dictionary<string, uint>()
            {
                { "Cheese", 2 },
                { "Tomato", 2 },
                { "Dough", 1 }
            };
            var pizzaRecipe = new Recipe("Pizza", pizzaIngredients);

            var cakeIngredients = new Dictionary<string, uint>()
            {
                { "Cheese", 1 },
                { "Milk", 1 }
            };
            var cakeRecipe = new Recipe("Cake", cakeIngredients);


            // Add chefs
/*            Chef chef1 = new Chef("Linda", new Dictionary<string, Recipe>
                                           {
                                               { pizzaRecipe.Name, pizzaRecipe },
                                               { cakeRecipe.Name, cakeRecipe }
                                           }
            );
            chef1.DishPrepared += Print;
            PizzeriaData.ChefManager.Chefs.Add(chef1);*/

            Chef chef2 = new Chef("Nick", new Dictionary<string, Recipe>
                                          {
                                              { pizzaRecipe.Name, pizzaRecipe },
                                              { cakeRecipe.Name, cakeRecipe },
                                          }
            );
            chef2.DishPrepared += Print;
            PizzeriaData.ChefManager.Chefs.Add(chef2);

            Chef chef3 = new Chef("Bob", new Dictionary<string, Recipe>
                                          {
                                              { cakeRecipe.Name, cakeRecipe }
                                          }
            );
            chef3.DishPrepared += Print;
            PizzeriaData.ChefManager.Chefs.Add(chef3);



            Console.WriteLine(PizzeriaData.IngredientStorage.ToString());
            Console.WriteLine(new string('-', 20));

            PizzeriaData.ChefManager.AddOrder("Pizza");
            PizzeriaData.ChefManager.AddOrder("Cake");
            PizzeriaData.ChefManager.AddOrder("Pizza");
            PizzeriaData.ChefManager.AddOrder("Pizza");
            PizzeriaData.ChefManager.AddOrder("Cake");
            PizzeriaData.ChefManager.AddOrder("Pizza");

            Console.WriteLine(PizzeriaData.ChefManager.GetChefByName("Nick").Info);

            Console.ReadKey();
            PizzeriaData.ChefManager.AddOrder("Cake");
            PizzeriaData.ChefManager.AddOrder("Pizza");

            Console.ReadKey();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(PizzeriaData.IngredientStorage.ToString());
        }

        public static void Print(string name, string dishName)
        {
            Console.WriteLine($"Chef {name} has cooked {dishName}");
        }
    }
}