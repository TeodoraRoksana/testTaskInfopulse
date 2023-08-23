using TestTask.API.Models.DTO;
using TestTask.Models;

namespace TestTask.API.Models.Mapper
{
    public class OrderMapper : IMapper<Order, OrderDTO>
    {
        public OrderDTO Map(Order data)
        {
            return new OrderDTO
            {
                id = data.OrderId,
                date = data.Date,
                client = data.Customers,
                status = data.Statuses,
                totalCost = data.TotalCost,
                comment = data.Comment,
                ProductsInOrder = data.OrderProducts
            };
        }

        public Order Unmap(OrderDTO data)
        {
            return new Order
            {
                OrderId = data.id,
                Date = data.date,
                CustomerId = data.client.CustomerId,
                StatusId = data.status.StatusId,
                TotalCost = data.totalCost, 
                Comment = data.comment,
                OrderProducts = data.ProductsInOrder
            };
        }
    }
}
