using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product p in _products)
        {
            total += p.GetTotalPrice();
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35;

        return total + shipping;
    }

    public string GetPackingLabel()
    {
        string result = "----- PACKING LABEL -----\n";

        foreach (Product p in _products)
        {
            result += $"{p.GetName()} (ID: {p.GetId()})\n";
        }

        return result;
    }

    public string GetShippingLabel()
    {
        string result = "----- SHIPPING LABEL -----\n";
        result += $"{_customer.GetName()}\n";
        result += $"{_customer.GetAddress().GetFullAddress()}";

        return result;
    }
}
