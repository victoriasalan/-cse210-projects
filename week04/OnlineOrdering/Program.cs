using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("200 Roosevelt Bld", "New York", "NY", "USA");
        Customer customer1 = new Customer("Andres Rivera", address1);

        Product product1 = new Product("Iphone charger", "9654-9721", 3.00, 2);
        Product product2 = new Product("Iphone14ProMax case", "5279-3721", 12.99, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Price: ${order1.CalculateTotalPrice():F2}");
        Console.WriteLine();



        Address address2 = new Address("Los Ceibos 12th St", "Quito", "Pichincha", "Ecuador");
        Customer customer2 = new Customer("Alicia Nevarez", address2);

        Product product3 = new Product("Nike Shoes Sport", "5285-9934", 80.99, 1);
        Product product4 = new Product("Liquid Blush Rare Beauty", "7623-8755", 23.99, 2);
        Product product5 = new Product("Makeup Brushes", "2951-9432", 16.99, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}