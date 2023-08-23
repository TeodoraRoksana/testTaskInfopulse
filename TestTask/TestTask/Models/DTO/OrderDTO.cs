using TestTask.Models;

namespace TestTask.API.Models.DTO
{
    public class OrderDTO
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public Customer client { get; set; }
        public Status status { get; set; }
        public double totalCost { get; set; }
        public string? comment { get; set; }
        public virtual ICollection<OrderProduct>? ProductsInOrder { get; set; } = new List<OrderProduct>();
    }
}
