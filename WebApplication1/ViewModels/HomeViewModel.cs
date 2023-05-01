using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Customer> AllCustomers { get; set; }

        public HomeViewModel(IEnumerable<Customer> customers)
        {
            AllCustomers = customers;
        }
    }
}
