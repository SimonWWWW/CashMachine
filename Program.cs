using System;
using System.ComponentModel.Design;

namespace str3
{
    class Program
    {
        static void Main(string[] args)
        {
            string PIN = "";
            int tryCount = 0; //liczba prob wpisania pinu
            while (PIN != "1234")
            {
                tryCount++;
                if (tryCount > 3)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Podaj PIN:");
                PIN = Console.ReadLine();
                if (PIN != "1234")
                {
                    Console.WriteLine("PIN jest nieprawidłowy, zostało {0} prób", 3 - tryCount);
                }
            }
            decimal accountBalance = 9234234.73m;
        MenuCommand:
            Console.WriteLine("1.Stan konta\n2.Wpłata\n3.Wypłata\n4.Wyjście");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Stan konta: ", accountBalance.ToString("n2") + " zł ");
                    Console.ReadKey();
                    goto MenuCommand;
                case "2":
                    decimal amount = -1;
                    while (amount < 0)
                    {
                        Console.WriteLine("Podaj kwotę, którą chcesz wpłacić: ");
                        amount = checkAccountBalance();
                    }
                    accountBalance += amount;
                    Console.WriteLine($"Wpłacona kwota: {amount}, stan konta: {accountBalance}");
                    Console.ReadKey();
                    goto MenuCommand;
                case "3":
                    amount = -1;
                    while (amount < 0)
                    {
                        Console.WriteLine("Podaj kwotę, którą chcesz wypłacić: ");
                        amount = checkAccountBalance();
                    }
                    accountBalance -= amount;
                    Console.WriteLine($"Wypłacona kwota: {amount}, stan konta: {accountBalance}");
                    Console.ReadKey();
                    goto MenuCommand;

                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja");
                    goto MenuCommand;
            }
            Console.ReadKey();
        }
            static decimal checkAccountBalance()
            {
                string input = Console.ReadLine();
                decimal amount;
                if(decimal.TryParse(input,out amount))
                {
                    if((amount % 20 == 0) || (amount % 50 == 0))
                    {
                        return amount;
                    }
                }
                Console.WriteLine("Nieprawidłowa kwota");
                return -1;
            }
        }
    }
