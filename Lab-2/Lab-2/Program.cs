using System.Runtime.CompilerServices;
using Lab_2;

var customers = new List<Customer>();
var inputNamn = String.Empty;
var inputchar = ' ';
var inputPassword = String.Empty;
var loginName = String.Empty;
var loginOk = false;
var loginOrReg = false;
//var product = new Product();

customers.Add(new Customer("K", "1"));
customers.Add(new Customer("Knatte", "123"));
customers.Add(new Customer("Fnatte", "321"));
customers.Add(new Customer("Tjatte", "213"));


LoginChoice();
void LoginChoice()
{
    while (loginOrReg == false)
    {
        Console.WriteLine("Hej\n1. Logga in\n2. Registera nytt konto");
        inputchar = Console.ReadKey().KeyChar;
        Console.Clear();

        switch (inputchar)
        {
            case '1':
                loginOrReg = true;
                LoginCheck();
                while (loginOk)
                {
                    Console.WriteLine("inloggad");
                    Console.ReadKey(true);
                }
                break;

            case '2':
                loginOrReg = true;
                Console.WriteLine("reigsterar ny kund");
                Console.ReadKey(true);
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

void LoginCheck()
{
    while (loginOk == false)
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
                    loginOk = true;
                    loginName = customer.Name;
                    break;
                }
                else
                {
                    //Fel lösenord, låt han försöka igen.
                    Console.WriteLine("Fel lösenord.\nTryck för att försöka igen.");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                }
            }
            else
            {
                //Om fel användarnamn, fråga om användaren vill lägga till nytt konto
                Console.Clear();
                Console.WriteLine("Kundnamn finns ej registrerat, vill du registrera ny kund?\n1. Ja\n2. Nej");
                inputchar = Console.ReadKey().KeyChar;
                Console.Clear();

                if (inputchar == '1')
                {
                    Console.WriteLine("registerar ny kund");
                    loginOk = true;
                    break;
                }
                else
                {
                    //Väljer att försöka igen
                    break;
                }

            }
        }
    }
}


string FilePath = "customers.json";
var customerlist = new List<Customer>();



void AddCustomer()
{
    //lägg till kund
    Console.WriteLine("Namn:");
    inputNamn = Console.ReadLine();
    Console.WriteLine("Lösenord:");
    inputPassword = Console.ReadLine();

    customers.Add(new Customer(inputNamn,inputPassword));
    loginName = inputNamn;
    loginOk = true;

}




