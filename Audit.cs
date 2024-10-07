using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Audit
    {
        const string AccountFile = "accounts.txt";// to store data in AccountFile
        private readonly List<BankAccount> accounts;
        public void ReadAccounts()
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
        public void SavingFile()
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
