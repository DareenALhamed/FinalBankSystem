using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class BankAccount:Admin
    {
        private Audit audit;
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public BankAccount(string name, decimal balance, int accountNumber, bool IsActive)
        {

            Balance = 1000;
            AccountNumber = GetAccountNumber();
        }
        public void Deposit()
        {
            Console.WriteLine("Please enter the amount you want to deposit");
            decimal amount = decimal.Parse(Console.ReadLine());
            Balance += amount;
            Console.WriteLine($"Your balance is :{Balance}");



        }
        public void Withdraw()
        {
            Console.WriteLine("Please enter the amount you want to withdraw");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (Balance == 0 || amount > Balance)
            {
                Console.WriteLine("There is a proplem");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Your balance is :{Balance}");
            }
        }
        public string GetAccountNumber()
        {
            return Guid.NewGuid().ToString();//generate a unique identifier string
        }
    }
}
