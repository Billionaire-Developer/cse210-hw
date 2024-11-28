using System;
using System.Collections.Generic;


class Address
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
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}


class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetShippingAddress()
    {
        return $"{name}\n{address.GetFullAddress()}";
    }
}


class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetPackingInfo()
    {
        return $"{name} (ID: {productId})";
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }
}


class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double productTotal = 0;
        foreach (var product in products)
        {
            productTotal += product.GetTotalCost();
        }

        double shippingCost = customer.IsInUSA() ? 5 : 35;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        List<string> packingLabel = new List<string>();
        foreach (var product in products)
        {
            packingLabel.Add(product.GetPackingInfo());
        }
        return string.Join("\n", packingLabel);
    }

    public string GetShippingLabel()
    {
        return customer.GetShippingAddress();
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Create example data
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 Oak St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W123", 10.00, 2));
        order1.AddProduct(new Product("Gadget", "G456", 15.50, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Widget", "W123", 10.00, 3));
        order2.AddProduct(new Product("Gizmo", "Z789", 20.00, 2));

        // Output results
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():0.00}");

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():0.00}");
    }
}