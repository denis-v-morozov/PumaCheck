namespace WebApplication1.Models.Repository
{
    public class MockOrderDetailedTaskRepository : IOrderDetailedTaskRepository
    {
        private List<OrderDetailedTask> _allOrderDetailedTasks;

        public MockOrderDetailedTaskRepository() 
        {
            _allOrderDetailedTasks = new List<OrderDetailedTask>()
            {
                new OrderDetailedTask {/*OrderId = 1,*/ OrderDetailedTaskId = 11, TaskName = "Local Permit", TaskDescription = "Bribe the forest ranger" },
                new OrderDetailedTask {/*OrderId = 1,*/ OrderDetailedTaskId = 12, TaskName = "Hire a red neck", TaskDescription = "Find someone with a chain saw" },
                new OrderDetailedTask {/*OrderId = 1,*/ OrderDetailedTaskId = 13, TaskName = "Bring log to Mill", TaskDescription = "Getter trucker" },
                new OrderDetailedTask {/*OrderId = 1,*/ OrderDetailedTaskId = 12, TaskName = "Cut wood to small slivers", TaskDescription = "Lots of work to do" },

                new OrderDetailedTask {/*OrderId = 2,*/ OrderDetailedTaskId = 21, TaskName = "Cut", TaskDescription = "Cut so small chunkies" },
                new OrderDetailedTask {/*OrderId = 2,*/ OrderDetailedTaskId = 22, TaskName = "Roll", TaskDescription = "thin and roll" },
                new OrderDetailedTask {/*OrderId = 2,*/ OrderDetailedTaskId = 23, TaskName = "Quality Control", TaskDescription = "Automation overdrive" },
                new OrderDetailedTask {/*OrderId = 2,*/ OrderDetailedTaskId = 22, TaskName = "Selebrate success", TaskDescription = "Everything is awsome - happy hour" },

            };
        }
        
        public IEnumerable<OrderDetailedTask> GeOrdersDetailedTasksByOrderId(int orderId)
        {
            return null; //broke it with new DB models - old code: _allOrderDetailedTasks.Where(t => t.Order.OrderId == orderId);
        }
    }
}
