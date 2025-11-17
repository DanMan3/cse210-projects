public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;


    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }


    public double CalculateTotalCost()
    {
        var subtotal = 0.00;
        var country = _customer.IsInUsa();

        foreach (var product in _products)
        {
            subtotal += product.TotalCost();
        }

        double shipping = 0;

        if (country)
        {
            shipping = 5.00;
        }
        else
        {
            shipping = 35.00;
        }

        return subtotal += shipping;
    }

    public List<String> CreatePackingLabel()
    {
        var packingLabel = new List<String>();

        foreach (var product in _products)
        {
            packingLabel.Add($"{product.GetName()} (ID: {product.GetId()})");
        }

        return packingLabel;
    }


    public string CreateShippingLabel()
    {


        return $@"
Name: {_customer.GetName()}
Shipping Address: {_customer.GetAddress()}";
    }
}