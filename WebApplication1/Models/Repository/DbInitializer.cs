using System.IO.Pipelines;

namespace WebApplication1.Models.Repository
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            PantherDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PantherDbContext>();

            if (!context.Customers.Any())
            {
                context.AddRange(InitialCustomers);
            }

            if (!context.Orders.Any())
            {
                context.Orders.AddRange(InitialOrders);
            }

            if (!context.OrderDetailedTasks.Any())
            {
                context.OrderDetailedTasks.AddRange(InitialOrderTasks);
            }

            context.SaveChanges();
        }

        private static List<Customer> _customers;
        public static List<Customer> InitialCustomers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new List<Customer>
                    {
                        new Customer
                        {
                            CustomerName = "Mill 1",
                            Description = "All-Hands on Board, no fingers missing",
                            IsActive = true,
                            ImageUrl = "https://cdn.pixabay.com/photo/2016/09/02/18/38/factory-1639990__480.jpg",
                        },
                        new Customer
                        {
                            CustomerName = "Mill 2",
                            Description = "Go Paper",
                            IsActive = true,
                            ImageUrl = "https://www.dayoadetiloye.com/wp-content/uploads/2017/05/PAPER-MILL-BUSINESS-PLAN-IN-NIGERIA.jpg",
                        },
                        new Customer
                        {
                            CustomerName = "Mill 3",
                            Description = "Loggers are our friends",
                            IsActive = false,
                            ImageUrl = "https://cdn.pixabay.com/photo/2019/11/02/13/52/lost-places-4596469_1280.jpg",
                        }
                    };
                }
                return _customers;
            }
        }

        private static List<Order> _orders;
        public static List<Order> InitialOrders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new List<Order>
                    {
                        new Order
                        {
                            IsActive = true,
                            OrderDescription = "Some side work, chopping this big Red wood",
                            OrderTasks = InitialOrderTasks.Take(4).ToList(),
                            OrderName = "Red wood - midnight special",
                            Customer = InitialCustomers.ElementAt(0)
                        },
                        new Order
                        {
                            IsActive = true,
                            OrderDescription = "Make paper",
                            OrderTasks = InitialOrderTasks.Take(8).ToList(),
                            OrderName = "Paper special",
                            Customer = InitialCustomers.ElementAt(0)
                        },
                        new Order
                        {
                            IsActive = true,
                            OrderDescription = "Diff side work, sitting around waiting for the boss",
                            OrderTasks = InitialOrderTasks,
                            OrderName = "some important work",
                            Customer = InitialCustomers.ElementAt(1)
                        },
                        new Order
                        {
                            IsActive = true,
                            OrderDescription = "Make paper",
                            OrderTasks = InitialOrderTasks.Where(t => t.TaskDescription != null && t.TaskDescription.Contains("r")).ToList(),
                            OrderName = "Paper special",
                            Customer = InitialCustomers.ElementAt(1)
                        },
                        new Order
                        {
                            IsActive = true,
                            OrderDescription = "Very important stuff",
                            OrderTasks = InitialOrderTasks,
                            OrderName = "some important work",
                            Customer = InitialCustomers.ElementAt(1)
                        },
                        new Order
                        {
                            IsActive = true,
                            OrderDescription = "Make paper",
                            OrderTasks = InitialOrderTasks,
                            OrderName = "Paper special",
                            Customer = InitialCustomers.ElementAt(2)
                        },

                    };
                }
                return _orders;
            }
        }

        private static List<OrderDetailedTask> _tasks;
        public static List<OrderDetailedTask> InitialOrderTasks
        {
            get
            {
                if (_tasks == null)
                {
                    _tasks = new List<OrderDetailedTask>
                    {
                        new OrderDetailedTask { TaskName = "Local Permit", TaskDescription = "Bribe the forest ranger" },
                        new OrderDetailedTask { TaskName = "Hire a red neck", TaskDescription = "Find someone with a chain saw" },
                        new OrderDetailedTask { TaskName = "Bring log to Mill", TaskDescription = "Get me a big truck" },
                        new OrderDetailedTask { TaskName = "Cut wood to small slivers", TaskDescription = "Lots of work to do" },
                        new OrderDetailedTask { TaskName = "Cut", TaskDescription = "Cut so small chunkies" },
                        new OrderDetailedTask { TaskName = "Roll", TaskDescription = "thin and roll" },
                        new OrderDetailedTask { TaskName = "Quality Control", TaskDescription = "Automation overdrive" },
                        new OrderDetailedTask { TaskName = "Selebrate success", TaskDescription = "Everything is awsome - happy hour" }
                    };
                }
                return _tasks;
            }
        }
    }
}
