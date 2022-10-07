using System.Runtime.CompilerServices;
using Lab_2;
using Microsoft.VisualBasic.CompilerServices;

var customers = new List<Customer>();
var products = new List<Product>();
var cart = new Customer("", "").Cart;
var inputNamn = String.Empty;
var inputchar = ' ';
var inputint = 0;
var inputstring = string.Empty;
var inputPassword = String.Empty;
var loginName = String.Empty;
var loginOkBool = false;
var loginOrRegBool = false;
var mainMenuBool = true;

customers.Add(new Customer("K", "1"));
customers.Add(new Customer("Knatte", "123"));
customers.Add(new Customer("Fnatte", "321"));
customers.Add(new Customer("Tjatte", "213"));

products.Add(new Product(1, "Äpple", 10));
products.Add(new Product(2, "Banan", 15));
products.Add(new Product(3, "Trocadero", 20));

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
                ShowCart();
                break;
            case '3':
                ToCheckout();
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
    while (true)
    {

        Console.Clear();
        Console.WriteLine("'R' - MainMenu\n" +
                          "Välkommen till Bidl, där allt är billigare." +
                          "Knappa in ID:et på en vara för att lägga den i kundvagnen.\n");

        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        inputchar = Console.ReadKey(true).KeyChar;

        switch (inputchar)
        {
            case '1':
                //Äpple 10kr
                Console.Clear();
                Console.WriteLine(products[0]);
                Console.WriteLine($"Ange antal i siffror:");
                if (int.TryParse(Console.ReadLine(), out inputint))
                {
                    Console.WriteLine($"Lägger till {inputint} {products[0].Name} i kundvagnen.");

                    for (int i = 0; i < inputint; i++)
                    {
                        cart.Add(products[0]);
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltig input, STÄLL IN DIG.\n" +
                                      "Skriv: Jag lär mig fortfarande att använda ett tangentbord.\n" +
                                      "Om du vill komma vidare.");
                    inputstring = Console.ReadLine();
                    if (inputstring == "Jag lär mig fortfarande att använda ett tangentbord.")
                    {
                        Console.Clear();
                        Console.WriteLine("Vad du kan!");
                        Thread.Sleep(800);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("HEJDÅ!");
                        Thread.Sleep(800);
                        Environment.Exit(0);
                    }

                }

                break;
            case '2':
                //Banan 15kr
                Console.Clear();
                Console.WriteLine(products[1]);
                Console.WriteLine($"Ange antal i siffror:");
                if (int.TryParse(Console.ReadLine(), out inputint))
                {
                    Console.WriteLine($"Lägger till {inputint} {products[1].Name} i kundvagnen.");

                    for (int i = 0; i < inputint; i++)
                    {
                        cart.Add(products[1]);
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltig input, STÄLL IN DIG.\n" +
                                      "Skriv: Jag lär mig fortfarande att använda ett tangentbord.\n" +
                                      "Om du vill komma vidare.");
                    inputstring = Console.ReadLine();
                    if (inputstring == "Jag lär mig fortfarande att använda ett tangentbord.")
                    {
                        Console.Clear();
                        Console.WriteLine("Vad du kan!");
                        Thread.Sleep(800);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("HEJDÅ!");
                        Thread.Sleep(800);
                        Environment.Exit(0);
                    }

                }

                break;
            case '3':
                //Trocadero 20kr
                Console.Clear();
                Console.WriteLine(products[2]);
                Console.WriteLine($"Ange antal i siffror:");
                if (int.TryParse(Console.ReadLine(), out inputint))
                {
                    Console.WriteLine($"Lägger till {inputint} {products[2].Name} i kundvagnen.");

                    for (int i = 0; i < inputint; i++)
                    {
                        cart.Add(products[2]);
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltig input, STÄLL IN DIG.\n" +
                                      "Skriv: Jag lär mig fortfarande att använda ett tangentbord.\n" +
                                      "Om du vill komma vidare.");
                    inputstring = Console.ReadLine();
                    if (inputstring == "Jag lär mig fortfarande att använda ett tangentbord.")
                    {
                        Console.Clear();
                        Console.WriteLine("Vad du kan!");
                        Thread.Sleep(800);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("HEJDÅ!");
                        Thread.Sleep(800);
                        Environment.Exit(0);
                    }

                }
                break;
            case 'r':
                MainMenu();
                break;
        }
    }
}

void ShowCart()
{
    var idOne = 0;
    var idTwo = 0;
    var idThree = 0;
    var totalPrice = 0f;

    foreach (var product in cart)
    {
        if (product.Id == 1)
        {
            idOne++;
            totalPrice += product.Price;
        }
        else if (product.Id == 2)
        {
            idTwo++;
            totalPrice += product.Price;
        }
        else if (product.Id == 3)
        {
            idThree++;
            totalPrice += product.Price;
        }
    }

    Console.Clear();
    Console.WriteLine("'R' - MainMenu\n" +
                      "Din Kundvagn:\n");

    if (idOne > 0)
    {
        Console.WriteLine($"{idOne}x {products[0].Name}, {products[0].Price} SEK styck.");
    }
    if (idTwo > 0)
    {
        Console.WriteLine($"{idTwo}x {products[1].Name}, {products[1].Price} SEK styck.");
    }
    if (idThree > 0)
    {
        Console.WriteLine($"{idThree}x {products[2].Name}, {products[2].Price} SEK styck.");
    }

    Console.WriteLine($"\nTotala priset:\n{totalPrice} SEK");

    inputchar = Console.ReadKey(true).KeyChar;
    if (inputchar == 'r')
    {
        MainMenu();
    }
}

void ToCheckout()
{
    var idOne = 0;
    var idTwo = 0;
    var idThree = 0;
    var totalPrice = 0f;

    foreach (var product in cart)
    {
        if (product.Id == 1)
        {
            idOne++;
            totalPrice += product.Price;
        }
        else if (product.Id == 2)
        {
            idTwo++;
            totalPrice += product.Price;
        }
        else if (product.Id == 3)
        {
            idThree++;
            totalPrice += product.Price;
        }
    }

    Console.Clear();
    Console.WriteLine("'R' - MainMenu\n");

    Console.WriteLine($"Totala priset:\n{totalPrice} SEK\n\n1. För att betala.");

    inputchar = Console.ReadKey(true).KeyChar;
    if (inputchar == 'r')
    {
        MainMenu();
    }
    else if (inputchar == '1')
    {
        //rensa varukorg
    }
}


//void ShowList(List<Customer> kund)
//{

//    foreach (var a in kund)
//    {
//        Console.WriteLine($"Name: {a.Name} Password: {a.Password}");
//    }

//    Console.ReadKey(true);
//}



