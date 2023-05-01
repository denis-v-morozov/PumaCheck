using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class OrderDetailedTask
    {
        [Key]
        public int OrderDetailedTaskId { get; set; } //PK

        public Order? Order { get; set; } 
        public string TaskName { get; set; } = string.Empty; //Denis Notes: defaulting to string.empty becaue property is not going to be nullable inside of the app
        public string? TaskDescription { get; set; } //Denis notes: 'string?' indicates that Property is 'optional' =>  not required to be filled in the DB

    }
}
