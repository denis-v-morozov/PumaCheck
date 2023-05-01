namespace WebApplication1.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PantherDbContext _pantherDbContext;

        public OrderRepository(PantherDbContext pantherDbContext)
        {
            _pantherDbContext = pantherDbContext;
        }

        public IEnumerable<Order> GeOrdersByCustomerId(int customerId)
        {
            return _pantherDbContext.Orders.Where(o => o.Customer.CustomerId == customerId).ToList();
        }
    }
}
