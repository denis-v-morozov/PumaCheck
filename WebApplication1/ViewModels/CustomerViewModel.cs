using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Customer customer)
        {
            Customer = customer;
        }

        public string Title => "Customer";

        public Customer Customer { get; set; }
    }
}
