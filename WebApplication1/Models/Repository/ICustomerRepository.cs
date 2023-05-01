namespace WebApplication1.Models.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> AllCustomers { get; }
        IEnumerable<Customer> ActiveCustomers { get; }
        Customer? GeCustomerById(int customerId);
    }
}
