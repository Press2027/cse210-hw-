using System;

class Program
{
    static void Main(string[] args)
    {
        // -------- Order 1 (USA customer) --------
        Address address1 = new Address("123 Main St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("Wilson Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop bag", "LS1001", 19.99, 2));
        order1.AddProduct(new Product("Wireless Keybord", "WM2002", 29.99, 1));
        order1.AddProduct(new Product("USB-Universal", "UC3003", 9.99, 3));

        // -------- Order 2 (International customer) --------
        Address address2 = new Address("Luthuli Avenue", "Nairobi", "ON", "Kenya");
        Customer customer2 = new Customer("David Wambua", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Bed Lamp", "DL4004", 35.99, 1));
        order2.AddProduct(new Product("Touch Keyboard", "MK5005", 89.99, 1));

        // -------- Display Results --------
        DisplayOrder(order1);
        Console.WriteLine("\n----------------------------------\n");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order.GetTotalCost():0.00}");
    }
}
