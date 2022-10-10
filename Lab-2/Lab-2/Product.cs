namespace Lab_2;

public class Product
{
    private float _price;
    public float Price
    {
        get { return _price; }
        set { _price = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private int _id;
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public Product(int id, string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price} SEK | ID: {Id}";
    }
}