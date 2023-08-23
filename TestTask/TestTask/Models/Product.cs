using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestTask.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual Category? Category { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();
}
