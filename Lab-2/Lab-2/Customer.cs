namespace Lab_2;

public class Customer
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

	//IMPLEMENTERA
    public override string ToString()
    {
        return $"Namn: {Name}\nLösenord: {Password}\nKundvagn: {Cart}";

    }
}