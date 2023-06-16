using System.Text;

namespace MultiTry
{
    public class Storage
    {
        private Dictionary<string, uint> _ingredientStorage = new()
        {
            { "Cheese", 20 },
            { "Tomato", 20 },
            { "Dough", 20 },
            { "Milk", 20 }
        };
        private Dictionary<string, uint> _preparedDishes = new Dictionary<string, uint>();

        public void PutIngredient(string name, uint quantity)
        {
            if (_ingredientStorage.ContainsKey(name))
            {
                _ingredientStorage[name] += quantity;
            }
            else
            {
                _ingredientStorage.Add(name, quantity);
            }
        }

        public bool TakeIngredient(string name, uint quantity)
        {
            if (_ingredientStorage.ContainsKey(name) && _ingredientStorage[name] >= quantity)
            {
                _ingredientStorage[name] -= quantity;
                return true;
            }
            else
            {
                return false;
                throw new Exception("Not enough ingredients or ingredient not found");
            }
        }

        public void PutDish(string name)
        {
            if (_preparedDishes.ContainsKey(name))
            {
                _preparedDishes[name]++;
            }
            else
            {
                _preparedDishes.Add(name, 1);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Ingredients and parts of dishes:\n");

            foreach (KeyValuePair<string, uint> item in _ingredientStorage)
            {
                result.Append($"{item.Key} - {item.Value}\n");
            }
            result.Append("\nReady dishes:\n");

            if (_preparedDishes.Count is 0)
            {
                result.Append("Empty");
            }
            else
            {
                foreach (KeyValuePair<string, uint> item in _preparedDishes)
                {
                    result.Append($"{item.Key} - {item.Value}\n");
                }
            }
            return result.ToString();
        }
    }
}
