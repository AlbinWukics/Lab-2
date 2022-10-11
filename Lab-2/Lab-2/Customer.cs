namespace Lab_2;

public record Customer
{
    private string _name;
    public string Name
    {
        get { return _name; }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
    }

    private List<Product> _cart;
    public List<Product> Cart
    {
        get { return _cart; }
        set { _cart = value; }
    }

    public Customer(string name, string password)
    {
        _name = name;
        _password = password;
        Cart = new List<Product>();
    }

    public override string ToString()
    {
        var output = String.Empty;
        output += $"Namn: {Name}\nLösenord: {Password}\n";
        output += "Varukorg:\n";
        foreach (var product in Cart)
        {
            output += $"{product}\n";
        }

        output += "\n";
        return output;
    }
}