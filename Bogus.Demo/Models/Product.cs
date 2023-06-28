namespace Bogus.Demo.Models;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ProductionDate { get; set; }
    public string? VendorEmail { get; set; }
    public string? CreatedBy { get; set; }

    public static Faker<Product> Fake()
    {
        return new Faker<Product>()
                .RuleFor(p => p.Id, s => Guid.NewGuid())
                .RuleFor(p => p.Name, s => s.Commerce.ProductName())
                .RuleFor(p => p.Description, (s, p) => s.Commerce.ProductDescription())
                .RuleFor(p => p.Price, s => s.Finance.Amount(10, 99))
                .RuleFor(p => p.ProductionDate, s => s.Date.Past(1))
                .RuleFor(p => p.VendorEmail, s => s.Person.Email)
                .RuleFor(p => p.CreatedBy, s => s.Person.UserName);
    }
}
