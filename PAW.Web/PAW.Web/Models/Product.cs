using System.ComponentModel.DataAnnotations;

namespace PAW.Web.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int? InventoryId { get; set; }
    public int? SupplierId { get; set; }
    public string? Description { get; set; }

    [Range(0, 9.99, ErrorMessage = "El rating debe estar entre 0 y 9.99")]
    public decimal? Rating { get; set; }

    public int? CategoryId { get; set; }
    public DateTime? LastModified { get; set; }
    public string? ModifiedBy { get; set; }
    public string? CreatedBy { get; set; }

    public Category? Category { get; set; }
    public Inventory? Inventory { get; set; }
    public Supplier? Supplier { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public DateTime? LastModified { get; set; }
    public string? ModifiedBy { get; set; }
}

public class Inventory
{
    public int InventoryId { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
    public DateTime? LastUpdated { get; set; }
    public int? ProductId { get; set; }
    public DateTime? DateAdded { get; set; }
    public string? ModifiedBy { get; set; }
}

public class Supplier
{
    public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public DateTime? LastModified { get; set; }
    public string? ModifiedBy { get; set; }
}
