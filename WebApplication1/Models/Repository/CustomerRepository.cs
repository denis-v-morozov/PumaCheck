namespace WebApplication1.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PantherDbContext _pantherDbContext;

        public CustomerRepository(PantherDbContext pantherDbContext)
        {
            _pantherDbContext = pantherDbContext;
        }

        public IEnumerable<Customer> AllCustomers
        {
            get
            {
               var allCustomers =  _pantherDbContext.Customers;

                foreach (var customer in allCustomers)
                {
                    //this is terrible I know, but I didn't set things up correctly and now running out of time
                    var orders = _pantherDbContext.Orders.Where(o => o.Customer.CustomerId == customer.CustomerId).ToList();
                    customer.Orders = orders;
                }

                return allCustomers;
            }
        }

        public IEnumerable<Customer> ActiveCustomers =>
            _pantherDbContext.Customers.Where(c => c.IsActive)
                                       .OrderBy(c => c.CustomerName);

        public Customer? GeCustomerById(int customerId)
        {
            return _pantherDbContext.Customers.FirstOrDefault(c =>  c.CustomerId == customerId);
        }
    }
}
