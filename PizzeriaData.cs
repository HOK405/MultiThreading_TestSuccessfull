
using MultiTry.Staff;

namespace MultiTry
{
    public static class PizzeriaData
    {
        public static Storage IngredientStorage { get; set; } = new Storage();
        public static ChefManager ChefManager { get; set; } = new ChefManager("Sapar");
    }
}
