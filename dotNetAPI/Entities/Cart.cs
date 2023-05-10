using System;
using System.Collections.Generic;

namespace dotNetAPI.Entities;

public partial class Cart
{
    public int Id { get; set; }

    public int UsersId { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    public string Email { get; set; } = null!;

    public virtual Product? Product { get; set; } = null!;

    public virtual User? Users { get; set; } = null!;
}
