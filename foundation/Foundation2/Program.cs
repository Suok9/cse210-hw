using System;
using System.Collections.Generic;

// Product class
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

// Address class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

// Order class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.GetTotalCost();
        }
        decimal shippingCost = customer.IsInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"{product.GetName()} ({product.GetProductId()})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// Program class for testing
class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "A123", 10.99m, 2));
        order1.AddProduct(new Product("Gadget", "B456", 5.49m, 4));

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalPrice():F2}");
    }
}
