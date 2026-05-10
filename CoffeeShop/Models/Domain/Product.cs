using System;
using System.Collections.Generic;

namespace CoffeeShop.Models.Domain;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public string? ImgUrl { get; set; }

    public decimal Price { get; set; }

    public bool IsTrendingProduct { get; set; }
}
