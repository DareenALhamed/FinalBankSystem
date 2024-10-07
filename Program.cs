namespace Final
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Auth auth = new Auth(100, 10);
            User[] userIndex = new User[100];
            User newUser = new User { Id = 2, Name = "User2", Password = "password1" };// the array register in auth class
            Audit audit = new Audit();


            static void Menu()
            {
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. User Login ");
                Console.WriteLine("3. Admin Login ");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Your Choice:");
            }
            Console.WriteLine("Welcome To The National Bank, PLease Enter You Choice");
             

            Menu();
            int option = int.Parse(Console.ReadLine());
            bool exit = true;
            switch (option)
            {
                case 1:
                    auth.Register(newUser);
                    break;
                case 2:
                    auth.Login();
                    break;
                case 3:
                    auth.LoginAdmin();
                    break;
                case 4:
                    exit = true;
                    break;
                   
                   

                default:
                    Console.WriteLine("Invalid!PLease Enter Number Between 1 and 4");
                    break;
            }

        }
    }
}
