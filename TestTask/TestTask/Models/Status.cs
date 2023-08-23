using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestTask.Models;

public partial class Status
{
    [Key]
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
}
