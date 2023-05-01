using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty; //Denis Notes: defaulting to string.empty becaue property is not going to be nullable inside of the app

        public string? Description { get; set; } //Denis notes: 'string?' indicates that Property is 'optional' =>  not required to be filled in the DB
        
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public List<Order> Orders { get; set; } 
    }
}
