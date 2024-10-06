using ECommerce.Models;

namespace ECommerce.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime SignUpDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
