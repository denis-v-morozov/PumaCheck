namespace WebApplication1.Models.Repository
{
    public interface IOrderDetailedTaskRepository
    {
        IEnumerable<OrderDetailedTask> GeOrdersDetailedTasksByOrderId(int orderId);
    }
}
