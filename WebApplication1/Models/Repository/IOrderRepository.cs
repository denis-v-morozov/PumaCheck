namespace WebApplication1.Models.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GeOrdersByCustomerId(int customerId);
    }
}
