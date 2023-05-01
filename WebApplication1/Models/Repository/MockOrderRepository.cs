using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Models.Repository
{
    public class MockOrderRepository : IOrderRepository
    {
        private readonly IOrderDetailedTaskRepository _orderDetailedTaskRepository;
        private readonly IEnumerable<Order> _allOrders;

        public MockOrderRepository(IOrderDetailedTaskRepository orderDetailedTaskRepository)
        {
            _orderDetailedTaskRepository = orderDetailedTaskRepository;

            _allOrders = MockAllOrders();
        }

        public IEnumerable<Order> AllOrders => _allOrders; 

        public IEnumerable<Order> GeOrdersByCustomerId(int customerId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        
            //mocking what's in the db
            AllOrders.ElementAt(0).Customer.CustomerId = 1;
            AllOrders.ElementAt(1).Customer.CustomerId = 1;
            AllOrders.ElementAt(2).Customer.CustomerId = 2;
            AllOrders.ElementAt(3).Customer.CustomerId = 2;
            AllOrders.ElementAt(4).Customer.CustomerId = 2;
            AllOrders.ElementAt(5).Customer.CustomerId = 1;

            var allOrders = AllOrders.Where(o => o.Customer.CustomerId == customerId);

#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return allOrders;
        }

        private IEnumerable<Order> MockAllOrders()
        {
            return DbInitializer.InitialOrders;
            //return new List<Order>
            //{
            //    new Order
            //    {
            //        IsActive = true,
            //        OrderDescription = "Some side work, chopping this big Red wood",
            //        OrderId = 1,
            //        OrderName = "Red wood - midnight special",
            //        OrderTasks = DbInitializer.InitialOrderTasks 
            //    },
            //    new Order
            //    {
            //        IsActive = true,
            //        OrderDescription = "Make paper",
            //        OrderId = 2,
            //        OrderName = "Paper special",
            //        OrderTasks = DbInitializer.InitialOrderTasks 
            //    },
            //};
        }
    }
}
