using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.API.Models.DTO;
using TestTask.API.Models.Mapper;
using TestTask.Models;

namespace TestTask.API.Services.DBService
{
    public class DBService : IDBService
    {
        private readonly TestTaskContext _context;
        private IMapper<Order, OrderDTO> _mapper;

        public DBService(TestTaskContext context)
        {
            _context = context;
            _mapper = new OrderMapper();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public List<OrderDTO> getOrdersWithItems()
        {
            List<Order> orders = _context.Order.Include(p => p.Statuses).Include(p => p.Customers).Include(p => p.OrderProducts).ToList();
            List<OrderDTO> listOrder = new List<OrderDTO>();
            foreach (Order order in orders)
            {
                listOrder.Add(_mapper.Map(order));
            }

            return listOrder;
        }

        public List<Status> getStatuses()
        {
            return _context.Statuses.ToList();
        }

        public List<Product> getProductsWithItems()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public List<OrderProduct> getProductsInOrderWithItems()
        {
            return _context.OrderProducts.Include(p => p.ProductSize).ToList();
        }

        public async Task<ActionResult<List<OrderProduct>>> postProductInOrder1(OrderProduct orderProduct)
        {
            Product product = _context.Products.Where(p => p.ProductId == orderProduct.ProductId).FirstOrDefault();
            if (product != null && product.Quantity >= orderProduct.OrderQuantity)
            {
                product.Quantity -= orderProduct.OrderQuantity;
            }

            _context.OrderProducts.Add(orderProduct);

            _context.SaveChanges();

            return _context.OrderProducts.ToList();
        }


        public void postProductInOrder(OrderProduct orderProduct)
        {
            Product product = _context.Products.Where(p => p.ProductId == orderProduct.ProductId).FirstOrDefault();
            if (product != null && product.Quantity >= orderProduct.OrderQuantity)
            {
                product.Quantity -= orderProduct.OrderQuantity;
            
                _context.OrderProducts.Add(orderProduct);
            }
        }

        public void postOrder(OrderDTO order)
        {
            Order newOrder = _mapper.Unmap(order);
            List<OrderProduct> productsInOrder = newOrder.OrderProducts.ToList();
            newOrder.OrderProducts = null;

            _context.Order.Add(newOrder);
            

            Customer customer = _context.Customers.FirstOrDefault(p => p.CustomerId == newOrder.CustomerId);
            if (customer != null)
                customer.OrdersCount++;
            saveChengesInDB();
            List<Order> orders = _context.Order.ToList();
            foreach(OrderProduct orderProduct in productsInOrder)
            {
                orderProduct.OrderId = orders.Last().OrderId;
                orderProduct.ProductId = orderProduct.Product.ProductId;
                orderProduct.ProductSizeId = orderProduct.ProductSize.ProductSizeId;
                orderProduct.Product = null;
                orderProduct.ProductSize = null;
                postProductInOrder(orderProduct);
            }
        }



        public async Task<ActionResult<List<Order>>> postOrder2(OrderDTO order)
        {
            Order newOrder = _mapper.Unmap(order);

            _context.Order.Add(newOrder);

            Customer customer = _context.Customers.FirstOrDefault(p => p.CustomerId == newOrder.CustomerId);
            if (customer != null)
                customer.OrdersCount++;


            await _context.SaveChangesAsync();

            return _context.Order.Include(p => p.Customers).Include(p => p.Statuses).ToList();
        }

        public void deleteProductInOrderById(int id)
        {
            OrderProduct orderProduct = _context.OrderProducts.FirstOrDefault(p => p.OrderProductsId == id);

            if (orderProduct != null)
            {
                _context.OrderProducts.Remove(orderProduct);
            }
        }

        public void deleteOrderById(int id)
        {
            Order order = _context.Order.FirstOrDefault(p => p.OrderId == id);

            if(order != null)
            {
                List<OrderProduct> orderProducts = _context.OrderProducts.Where(p => p.OrderId == id).ToList();
                foreach (OrderProduct orderProduct in orderProducts)
                {
                    deleteProductInOrderById(orderProduct.OrderProductsId);
                }

                Customer customer = _context.Customers.FirstOrDefault(p => p.CustomerId == order.CustomerId);
                if (customer != null)
                    customer.OrdersCount--;

                _context.Order.Remove(order);
            }
        }

        public void saveChengesInDB() { _context.SaveChanges(); }
    }
}
