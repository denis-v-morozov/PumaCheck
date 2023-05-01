namespace WebApplication1.Models.Repository
{
    public class OrderDetailedTaskRepository : IOrderDetailedTaskRepository
    {
        private readonly PantherDbContext _pantherDbContext;

        public OrderDetailedTaskRepository(PantherDbContext pantherDbContext)
        {
            _pantherDbContext = pantherDbContext;
        }

        public IEnumerable<OrderDetailedTask> GeOrdersDetailedTasksByOrderId(int orderId)
        {
            var order = _pantherDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
       
             return order == null 
                        ? new List<OrderDetailedTask>() 
                        : order.OrderTasks == null
                            ? new List<OrderDetailedTask>()
                            : order.OrderTasks;
            
            //broke with new DB model = > old: _pantherDbContext.OrderDetailedTasks.Where(t => t.Order.OrderId == orderId);   
        }
    }
}
