using MultiTry;
using System.Collections.Concurrent;

namespace MultiTry
{
    public class ChefManager
    {
        private readonly object _chefLock = new object();
        private ConcurrentQueue<string> _orderQueue = new ConcurrentQueue<string>();
        private Thread _orderProcessingThread;

        public List<Chef> Chefs { get; set; } = new List<Chef>();

        public ChefManager()
        {
            _orderProcessingThread = new Thread(ProcessOrders);
            _orderProcessingThread.Start();
        }

        private void ProcessOrders()
        {
            while (true)
            {
                if (_orderQueue.TryDequeue(out string order))
                {
                    Chef freeChef = null;
                    lock (_chefLock)
                    {
                        freeChef = Chefs.Find(chef => !chef.IsBusy && chef.Recipes.ContainsKey(order));
                    }

                    if (freeChef != null)
                    {
                        freeChef.IsBusy = true;
                        new Thread(() => freeChef.Cook(order)).Start();
                    }
                    else
                    {
                        _orderQueue.Enqueue(order);
                        Thread.Sleep(1000);  
                    }
                }
                else
                {
                    Thread.Sleep(1000); 
                }
            }
        }


        public void AddOrder(string order)
        {
            _orderQueue.Enqueue(order);
        }

        public Chef GetChefByName(string name)
        {
            return Chefs.Find(chef => chef.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }

}