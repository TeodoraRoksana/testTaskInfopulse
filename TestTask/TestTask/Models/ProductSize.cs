using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestTask.Models;

public partial class ProductSize
{
    [Key]
    public int ProductSizeId { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();
}
