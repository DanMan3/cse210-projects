using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        var json = "orders.json";
        var jsonObjs = GetProductsFromFile(json);

        foreach (var item in jsonObjs)
        {
            var newCustomer = GenerateCustomer(item);
            var constructedProducts = ConstructProduct(item);

            var order = new Order(constructedProducts, newCustomer);
            orders.Add(order);
        }

        Console.Clear();
        foreach (var order in orders)
        {
            var packingLabel = order.CreatePackingLabel();
            var shippingLabel = order.CreateShippingLabel();
            var total = order.CalculateTotalCost();



            foreach (var line in packingLabel)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(shippingLabel);
            Console.WriteLine($"Total: ${total:0.00}");

            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
        }


    }


    static List<JsonObject> GetProductsFromFile(string file)
    {


        var json = File.ReadAllText(file);
        var parsed = JsonNode.Parse(json);
        var orders = new List<JsonObject>();


        // "parsed" parses to a JsonObject that compiles to a JsonArray, so cast it now and use the data.
        if (parsed is JsonArray arr)
        {
            foreach (var item in arr)
            {
                if (item is JsonObject obj)
                {
                    orders.Add(obj);
                }
            }
        }
        return orders;

    }



    public static List<Product> ConstructProduct(JsonObject jsonObject)
    {

        var listOfProducts = new List<Product>();


        var productsArray = jsonObject["products"].AsArray();

        foreach (var product in productsArray)
        {
            if (product is JsonObject prod)
            {
                var name = prod["name"]?.GetValue<string>() ?? "";
                var id = prod["id"]?.GetValue<int>() ?? 0;
                var price = prod["price"]?.GetValue<float>() ?? 0f;
                var qty = prod["quantity"]?.GetValue<float>() ?? 0f;

                listOfProducts.Add(new Product(name, id, price, qty));
            }
        }

        return listOfProducts;

    }

    public static Customer GenerateCustomer(JsonObject jsonObject)
    {
        // if (jsonObjects == null || jsonObjects.Count == 0)
        //     return new Customer("", new Address("", "", "", ""));

        var customerObj = jsonObject["customer"] as JsonObject;
        var addrObj = customerObj["address"] as JsonObject;

        var address = new Address(
            addrObj?["streetAddress"]?.GetValue<string>() ?? "",
            addrObj?["city"]?.GetValue<string>() ?? "",
            addrObj?["stateOrProvince"]?.GetValue<string>() ?? "",
            addrObj?["country"]?.GetValue<string>() ?? ""
        );

        return new Customer(customerObj?["name"]?.GetValue<string>() ?? "", address);
    }

}