using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CustomerListViewModel
    {
        public CustomerListViewModel(IEnumerable<Customer> customers)
        {
            Customers = customers;
        }

        public string Title => "Customers";

        public IEnumerable<Customer> Customers { get; set; }
    }
}
