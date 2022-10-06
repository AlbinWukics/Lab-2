using System.Runtime.CompilerServices;
using Lab_2;

var customers = new List<Customer>();
var products = new List<Product>();
var inputNamn = String.Empty;
var inputchar = ' ';
var inputPassword = String.Empty;
var loginName = String.Empty;
var loginOkBool = false;
var loginOrRegBool = false;
var mainMenuBool = true;

customers.Add(new Customer("K", "1"));
customers.Add(new Customer("Knatte", "123"));
customers.Add(new Customer("Fnatte", "321"));
customers.Add(new Customer("Tjatte", "213"));

products.Add(new Product(1,"Äpple",10));
products.Add(new Product(2,"Banan",15));
products.Add(new Product(3,"Trocadero",20));

//var product = new Product();
//string FilePath = "customers.json";
//var customerlist = new List<Customer>();

InitialLoginChoice();
void InitialLoginChoice()
{
    while (loginOrRegBool == false)
    {
        Console.WriteLine("Hej\n1. Logga in\n2. Registera nytt konto");
        inputchar = Console.ReadKey(true).KeyChar;
        Console.Clear();

        switch (inputchar)
        {
            case '1':
                loginOrRegBool = true;
                LoginCheck();
                break;

            case '2':
                loginOrRegBool = true;
                AddCustomer();
                break;

            default:
                Console.Clear();
                Console.WriteLine("Ogiltig input.\nTryck för att pröva igen.");
                Console.ReadKey(true);
                Console.Clear();
                break;
        }
    }
}

void AddCustomer()
{
    //lägg till kund
    Console.WriteLine("Namn:");
    inputNamn = Console.ReadLine();
    Console.WriteLine("Lösenord:");
    inputPassword = Console.ReadLine();

    customers.Add(new Customer(inputNamn, inputPassword + ""));
    loginName = inputNamn;
    loginOkBool = true;
    Console.Clear();
    Console.WriteLine("Loggar in...");
    Thread.Sleep(1000);
    mainMenuBool = true;

    MainMenu();
}

void LoginCheck()
{
    while (loginOkBool == false)
    {
        Console.Write("Namn: ");
        inputNamn = Console.ReadLine();
        Console.Write("Lösenord: ");
        inputPassword = Console.ReadLine();

        foreach (var customer in customers)
        {
            if (customer.Name.ToLower() == inputNamn.ToLower())
            {
                if (customer.Password == inputPassword)
                {
                    loginOkBool = true;
                    loginName = customer.Name;
                    Console.Clear();
                    Console.WriteLine("Loggar in...");
                    Thread.Sleep(1000);
                    mainMenuBool = true;

                    MainMenu();

                    return;
                }
                else if (customer.Name.ToLower() == inputNamn.ToLower() && customer.Password != inputPassword)
                {
                    //Fel lösenord, låt han försöka igen.
                    loginOkBool = false;
                    Console.WriteLine("Fel lösenord.\nTryck för att försöka igen.");
                    Console.ReadKey(true);
                    Console.Clear();

                    LoginCheck();
                }
            }
        }

        //Om fel användarnamn, fråga om användaren vill lägga till nytt konto
        Console.Clear();
        Console.WriteLine("Kundnamn finns ej registrerat, vill du registrera ny kund?\n1. Ja\n2. Nej");
        inputchar = Console.ReadKey(true).KeyChar;
        Console.Clear();

        if (inputchar == '1')
        {
            Console.WriteLine("Registera ny kund\n");
            loginOkBool = true;
            AddCustomer();
        }

        //Väljer att försöka igen eller ogiltig knapp

    }
}

void MainMenu()
{
    while (mainMenuBool)
    {
        Console.Clear();
        Console.WriteLine($"Välkommen in i värmen {loginName}!\n\n" +
                          "1. Handla\n" +
                          "2. Se kundvagn\n" +
                          "3. Till kassan\n" +
                          "4. Logga ut\n" +
                          "5. Exit");
        inputchar = Console.ReadKey(true).KeyChar;
        Console.Clear();

        switch (inputchar)
        {
            case '1':
                ProductMenu();
                break;
            case '2':
                //metod för Se kundvagn
                break;
            case '3':
                //metod för Till kassan
                break;
            case '4':
                loginName = String.Empty;
                loginOkBool = false;
                loginOrRegBool = false;
                mainMenuBool = false;
                InitialLoginChoice();
                break;
            case '5':
                Environment.Exit(0);
                break;
        }
    }
}

void ProductMenu()
{
    Console.Clear();
    Console.WriteLine("Välkommen till Bidl, där allt är billigare.\n");

    

    Console.ReadKey(true);
}


