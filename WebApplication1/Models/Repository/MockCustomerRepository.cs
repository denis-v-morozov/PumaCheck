namespace WebApplication1.Models.Repository
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEnumerable<Customer> _allCustomers;
        public MockCustomerRepository(IOrderRepository orderReository)
        {
            _orderRepository = orderReository;
            _allCustomers = MockAllCustomers();
        }

        public IEnumerable<Customer> MockAllCustomers()
        {
            return new List<Customer>
            {
                new Customer { CustomerId=1,
                               CustomerName="Mill 1",  Description = "All-Hands on Board, no fingers missing", IsActive = true,
                               ImageUrl = "https://cdn.pixabay.com/photo/2016/09/02/18/38/factory-1639990__480.jpg",
                               Orders = _orderRepository.GeOrdersByCustomerId(1).ToList()
                             },
                new Customer { CustomerId=2,
                               CustomerName="Mill 2",  Description = "Go Paper", IsActive = true,
                               ImageUrl = "https://www.dayoadetiloye.com/wp-content/uploads/2017/05/PAPER-MILL-BUSINESS-PLAN-IN-NIGERIA.jpg",
                               Orders = _orderRepository.GeOrdersByCustomerId(2).ToList()
                             },
                new Customer { CustomerId=3,
                               CustomerName="Mill 3",  Description = "Loggers are our friends", IsActive = false,
                               ImageUrl = "https://cdn.pixabay.com/photo/2019/11/02/13/52/lost-places-4596469_1280.jpg",
                               Orders = _orderRepository.GeOrdersByCustomerId(3).ToList()
                             },
            };
        }

        public IEnumerable<Customer> ActiveCustomers => AllCustomers.Where(c => c.IsActive);

        public IEnumerable<Customer> AllCustomers => _allCustomers;

        public Customer? GeCustomerById(int customerId)
        {
            return AllCustomers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
