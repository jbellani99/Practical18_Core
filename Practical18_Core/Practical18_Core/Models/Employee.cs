using System.ComponentModel.DataAnnotations;

namespace Practical18_Core.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public decimal salary { get; set; }
        

    }
}
