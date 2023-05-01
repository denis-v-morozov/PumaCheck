using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private int customerId;


        //Denis note: S.O.L.I.D. principles with /DI/Ioc pattern => injecting dependencies into c-tor (instead of creating new instances when needed)
        public CustomerController(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        /// <summary>
        /// Denis note: probably a terrible name but just returning all customers, (instead of active ones, as I don't have so many setup)
        /// https://localhost:7115/customer/list
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Panther Solutions (All Customers)";

            // a better way is: because now I can bind to multiple properties on the ViewModel
            var vm = new CustomerListViewModel(_customerRepository.AllCustomers);

            return View(vm);
        }

        /// <summary>
        /// the route to this one should be: 
        /// https://localhost:7075/customer/details/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {           
            var customer = _customerRepository.AllCustomers.FirstOrDefault(c => c.CustomerId == id);
            if(customer == null)
            {
                return NotFound();
            }

            var vm = new CustomerViewModel(customer);

            ViewBag.CurrentCategory = $"Panther Solutions (Customer Name: {customer.CustomerName}, Id:{customer.CustomerId})";
            ViewBag.CustomerId = id;

            return View(vm);
        }
    }
}
