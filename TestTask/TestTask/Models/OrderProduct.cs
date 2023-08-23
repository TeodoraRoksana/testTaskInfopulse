using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestTask.Models;

public partial class OrderProduct
{
    [Key]
    public int OrderProductsId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int OrderQuantity { get; set; }

    public int ProductSizeId { get; set; }
    [JsonIgnore]
    public virtual Order? Order { get; set; } = null!;

    public virtual Product? Product { get; set; } = null!;

    public virtual ProductSize? ProductSize { get; set; } = null!;
}
