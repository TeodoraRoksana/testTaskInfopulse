using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public DateTime Date { get; set; }

    public int CustomerId { get; set; }

    public int StatusId { get; set; }

    public double TotalCost { get; set; }

    public string? Comment { get; set; }

    public virtual Customer? Customers { get; set; } = null!;

    public virtual ICollection<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Status Statuses { get; set; } = null!;
}
