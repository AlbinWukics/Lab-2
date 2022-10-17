using Lab_2;

var customers = new List<Customer>();
var products = new List<Product>();
var inputNamn = String.Empty;
var inputchar = ' ';
var inputint = 0;
var inputstring = string.Empty;
var inputPassword = String.Empty;
var loginOkBool = false;
var loginOrRegBool = false;
var mainMenuBool = false;
Customer? loggedInCustomer = null;

customers.Add(new Customer("K", "1"));
customers.Add(new Customer("Knatte", "123"));
customers.Add(new Customer("Fnatte", "321"));
customers.Add(new Customer("Tjatte", "213"));

products.AddRange(new[]
{
    new Product(1, "Äpple",10),
    new Product(2, "Banan", 15),
    new Product(3, "Trocadero", 20)
});

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
    loginOkBool = true;
    mainMenuBool = true;
    Console.Clear();
    Console.WriteLine("Loggar in...");
    Thread.Sleep(1000);

    //Jag vet att denna ligger sist i listan, måste jag använda en Foreach-loop för att ge loggedInCustomer rätt värde?
    //foreach (var customer in customers)
    //{
    //    if (customer.Name == inputNamn && customer.Password == inputPassword)
    //    {
    //        loggedInCustomer = customer;
    //        break;
    //    }
    //}

    //OVANSTÅENDE UTKOMMENTERAT BÖR GÖRA SAMMA SAK SOM NEDANSTÅENDE.

    loggedInCustomer = customers.LastOrDefault();

    MainMenu();
}

void LoginCheck()
{
    loginOkBool = false;
    loggedInCustomer = null;

    while (loginOkBool == false)
    {
        Console.Write("Namn: ");
        inputNamn = Console.ReadLine();
        Console.Write("Lösenord: ");
        inputPassword = Console.ReadLine();

        //Med denna lösningen kan det inte finnas två konton med samma namn
        foreach (var customer in customers)
        {
            if (customer.Name.ToLower().Equals(inputNamn.ToLower()))
            {
                if (customer.IsPasswordOk(inputPassword))
                {
                    loggedInCustomer = customer;
                    Console.Clear();
                    Console.WriteLine("Loggar in...");
                    Thread.Sleep(1000);
                    mainMenuBool = true;
                    loginOkBool = true;

                    MainMenu();
                }
                else if (customer.Name.ToLower() == inputNamn.ToLower() && customer.Password != inputPassword)
                {
                    //Fel lösenord, låt han försöka igen.
                    loginOkBool = false;
                    Console.WriteLine("Fel lösenord.\nTryck för att försöka igen.");
                    Console.ReadKey(true);
                    Console.Clear();

                    //Är detta fel? Väldigt smidigt i alla fall.
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
        Console.WriteLine($"Välkommen in i värmen {inputNamn}!\n\n" +
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
                inputNamn = String.Empty;
                inputPassword = String.Empty;
                loggedInCustomer = null;
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
                          "Välkommen till Bidl, där allt är billigare.\n" +
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
                        loggedInCustomer.Cart.Add(products[0]);
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
                        loggedInCustomer.Cart.Add(products[1]);
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
                        loggedInCustomer.Cart.Add(products[2]);
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

    foreach (var product in loggedInCustomer.Cart)
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

    foreach (var product in loggedInCustomer.Cart)
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

    Console.WriteLine("\n\nKonton och varukorgar:\n");
    foreach (var customer in customers)
    {
        Console.WriteLine(customer);
    }

    inputchar = Console.ReadKey(true).KeyChar;
    if (inputchar == 'r')
    {
        MainMenu();
    }
    else if (inputchar == '1')
    {
        loggedInCustomer.Cart.Clear();
    }
}


//string FilePath = "customers.json";
//var customerlist = new List<Customer>();
