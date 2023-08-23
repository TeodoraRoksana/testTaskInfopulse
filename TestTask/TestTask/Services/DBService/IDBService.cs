using Microsoft.AspNetCore.Mvc;
using TestTask.API.Models.DTO;
using TestTask.Models;

namespace TestTask.API.Services.DBService
{
    public interface IDBService
    {
        public List<OrderDTO> getOrdersWithItems();
        public List<Customer> GetCustomers();
        public List<Status> getStatuses();
        public List<Product> getProductsWithItems();
        public List<OrderProduct> getProductsInOrderWithItems();
        public Task<ActionResult<List<OrderProduct>>> postProductInOrder1(OrderProduct orderProduct);
        public void postProductInOrder(OrderProduct orderProduct);
        public Task<ActionResult<List<Order>>> postOrder2(OrderDTO order);
        public void postOrder(OrderDTO order);
        public void deleteProductInOrderById(int id);
        public void deleteOrderById(int id);
        public void saveChengesInDB();
    }
}
