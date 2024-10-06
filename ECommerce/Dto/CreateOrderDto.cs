namespace ECommerce.Dto
{
    public class CreateOrderDto
    {
        //int customerId,List<(int productId,int quantity)>orderItems
        public int CustomerId { get; set; }
        public List<(int productId, int quantity)> orderItems { get; set; }
    }
}
