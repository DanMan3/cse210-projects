public class Product
{
    private string _name;
    private int _id;
    private double _price;
    private double _quantity;



    public Product(string name, int id, double price, double quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }


    public double TotalCost()
    {
        return _price * _quantity;
    }


    public string GetName()
    {
        return _name;
    }

    public int GetId()
    {
        return _id;
    }

    public double GetPrice()
    {
        return _price;
    }

    public double GetQuantity()
    {
        return _quantity;
    }




}
