using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class OrderLogic
    {
        private readonly OrderRepository orderRepo;
        public OrderLogic(OrderRepository r)
        {
            orderRepo = r;
        }
    }

}