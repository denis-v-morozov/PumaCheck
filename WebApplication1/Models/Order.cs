using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; } //PK

        //public int CustomerId { get; set; } //FK
        public Customer? Customer { get; set; } //EF Relationship

        public string OrderName { get; set; } = string.Empty; //Denis Notes: defaulting to string.empty becaue property is not going to be nullable inside of the app

        public string? OrderDescription { get; set; } //Denis notes: 'string?' indicates that Property is 'optional' =>  not required to be filled in the DB

        public bool IsActive { get; set; }

        public List<OrderDetailedTask>? OrderTasks { get; set; }
    }
}
