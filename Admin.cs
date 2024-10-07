using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        const string AccountFile = "accounts.txt";// to store data in AccountFile

        public void CreateAccount(List<BankAccount> accounts)
        {
            try
            {
                Console.WriteLine("Enter Your Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Your Balance");
                decimal balance = decimal.Parse(Console.ReadLine());
                int accountNumber = accounts.Count + 1;//unique account number, 1 is to add the new one to the last one
                Console.WriteLine($"Your Account Number is: {accountNumber}");
                accounts.Add(new BankAccount(name, balance, accountNumber, true));
                Console.WriteLine($"Your Account Has Been Added Successfully {name} ");
                SavingFile(accounts);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public void ReadAccounts(List<BankAccount> accounts)
        {
            try
            {
                if (File.Exists(AccountFile))// to be sure that the file exist or not
                {
                    using (StreamReader Read = new StreamReader(AccountFile))//to read the file 
                    {
                        string line;// to read every single line
                        while ((line = Read.ReadLine()) != null)// if the line is not null
                        {
                            string[] ToParts = line.Split('|');// to split the line
                            int accountNumber = int.Parse(ToParts[0]);
                            string name = ToParts[1];
                            decimal balance = decimal.Parse(ToParts[2]);// the balance is not define.
                            accounts.Add(new BankAccount(name, balance, accountNumber, true));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Data Founded");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }

        public void UpdateAccount(List<BankAccount> accounts)
        {
            try
            {
                Console.WriteLine("Enter Account Number");
                string accountNumber = Console.ReadLine();
                BankAccount account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    Console.WriteLine("Enter New Name:");
                    string newName = Console.ReadLine();
                    account.Name = newName;
                    Console.WriteLine("Do You want To Activate/DeActivate Yor Account?\n" +
                        "Press 1 To Activate\nPress 2 To DeActivate");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (account.IsActive == true)
                            {
                                Console.WriteLine("Your Account Is Already ACTIVE");
                            }
                            else
                            {
                                account.IsActive = true;
                                Console.WriteLine("Your Account has been Activated Successfully");
                            }
                            break;
                        case 2:
                            if (account.IsActive == true)
                            {
                                account.IsActive = false;
                                Console.WriteLine("Your Account has been DeActivated Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Your Account Is Already DEACTIVE");
                            }
                            break;
                    }
                    Console.WriteLine("Account has been Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Check the Account Number");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }
        public void DeleteAccount(List<BankAccount> accounts)
        {
            try
            {
                Console.WriteLine("Enter Your Account Number:");
                string accountNumber = Console.ReadLine();
                BankAccount account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    accounts.Remove(account);
                    Console.WriteLine("Account Deleted Successfully");
                    SavingFile(accounts);
                }
                else
                {
                    Console.WriteLine("Check the Account Number");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }
        private void SavingFile(List<BankAccount> accounts)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(AccountFile))
                {
                    foreach (BankAccount account in accounts)
                    {
                        writer.WriteLine($"{account.AccountNumber}| {account.Name} | {account.Balance}");
                    }
                }
            }

            catch (Exception ex)
            { Console.WriteLine("ERROR " + ex.Message); }
        }
    }
}
