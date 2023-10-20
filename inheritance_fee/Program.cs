using System;
using System.Text.RegularExpressions;

namespace MyBill
{
    internal class Program
    {
        class Bill
        {
            public string Id { get; set; }
            public string Currency { get; set; }
            public string Place { get; set; }
            public string Name { get; set; }
            public string FurtherAnalytics { get; set; }
            public double Residue { get; set; }
            public string Other { get; set; }

            public Bill()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Created a bill");
                Console.ResetColor();
            }
        }

        class Credit : Bill
        {
            public double Percentage { get; set; }

            public Credit() : base()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You created a credit bill");
                Console.ResetColor();
            }

            public new void inputInfo()
            {
                Console.WriteLine("Enter Name of bill: ");
                Name = Console.ReadLine();

                string pattern = @"^[A-Z]{2}\d{27}$";
                Regex regex = new Regex(pattern);
                do
                {
                    Console.WriteLine("Enter ID (AA111111111111111111111111111): ");
                    Id = Console.ReadLine();
                } while (!regex.IsMatch(Id));

                do
                {
                    Console.WriteLine("Enter Currency: ");
                    Currency = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(Currency));

                Console.WriteLine("Enter the institution where the account is opened: ");
                Place = Console.ReadLine();

                Console.WriteLine("Would you enter residue (y/n)");
                string yn = Console.ReadLine();
                if (yn == "y")
                {
                    Residue = double.Parse(Console.ReadLine());
                }
                else
                {
                    Residue = 0;
                    Console.WriteLine("Residue = 0 " + Currency);
                }

                Console.WriteLine("Enter additional analytics: ");
                FurtherAnalytics = Console.ReadLine();
                Console.WriteLine("Enter the percentage: ");
                Percentage = double.Parse(Console.ReadLine());

                // Розрахунок відсотків і нового залишку
                double interest = Residue * (Percentage / 100.0);
                Residue += interest;

                Console.WriteLine("Interest: " + interest.ToString("C"));
                Console.WriteLine("Balance after interest accrual: " + Residue.ToString("C"));
            }
        }

        class Deposit : Bill
        {
            public DateTime ExpiryDate { get; set; }

            public Deposit() : base()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You created a deposit bill");
                Console.ResetColor();
            }

            public new void inputInfo()
            {
                Console.WriteLine("Enter Name of bill: ");
                Name = Console.ReadLine();

                string pattern = @"^[A-Z]{2}\d{27}$";
                Regex regex = new Regex(pattern);
                do
                {
                    Console.WriteLine("Enter ID (AA111111111111111111111111111): ");
                    Id = Console.ReadLine();
                } while (!regex.IsMatch(Id));

                do
                {
                    Console.WriteLine("Enter Currency: ");
                    Currency = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(Currency));

                Console.WriteLine("Enter the institution where the account is opened: ");
                Place = Console.ReadLine();

                Console.WriteLine("Would you enter residue (y/n)");
                string ny = Console.ReadLine();
                if (ny == "y")
                {
                    Residue = double.Parse(Console.ReadLine());
                }
                else
                {
                    Residue = 0;
                    Console.WriteLine("Residue = 0 " + Currency);
                }

                Console.WriteLine("Enter additional analytics: ");
                FurtherAnalytics = Console.ReadLine();

                Console.WriteLine("Enter the predicted end date (yyyy-MM-dd): ");
                ExpiryDate = DateTime.Parse(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            int choose;
            do
            {
                Console.WriteLine("Choose your bill (1 - Credit; 2 - Deposit): ");
                choose = int.Parse(Console.ReadLine());
            } while (choose < 1 || choose > 2);

            switch (choose)
            {
                case 1:
                    Credit billCredit = new Credit();
                    billCredit.inputInfo();
                    break;
                case 2:
                    Deposit billDeposit = new Deposit();
                    billDeposit.inputInfo();
                    break;
            }
        }
    }
}