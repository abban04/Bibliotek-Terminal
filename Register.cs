namespace bibliotek
{
    internal class Register
    {
        static string currentUser = "";
        //Registreringssida
        public static void RegisterPage()
    {
        Console.Clear();
        Console.WriteLine("För att registrera dig ange personnummer och lösenord.");
        Console.WriteLine("");

        Console.Write("Personnummer: ");
        var persnumber = Console.ReadLine();

        Console.Write("Lösenord: ");
        var password = Console.ReadLine();



        if (UserInfoIncomplete(persnumber, password))
        {
            Console.Clear();
            Console.WriteLine("Ange riktiga uppgifter för att kunna registrera dig.");
            Console.WriteLine("");
            RegisterPage();
            return;
        }

        var line = $"{persnumber} {password}\n";

        File.AppendAllText(@"C:\Users\albert.rogo\source\repos\bibliotek.cs\Users.txt", line);

        Console.WriteLine("Du är nu registrerad och kan logga in. Vänligen vänta för att skickas till inloggningssidan.");

        Thread.Sleep(6000);
    }
        public static bool LoginPage()
        {
            Console.Clear();

            Console.WriteLine("Välkommen!");


            Console.WriteLine("För att logga in ange personnummer och lösenord.");
            Console.WriteLine("");

            Console.Write("Personnummer: ");
            var persnumber = Console.ReadLine();

            Console.Write("Lösenord: ");
            var password = Console.ReadLine();

            string [] loginFromFile = File.ReadAllLines(@"C:\Users\albert.rogo\source\repos\bibliotek.cs\Users.txt");

            bool loginOk = false;
            foreach(var line in loginFromFile)
            {
                string[] tokens = line.Split(" ");
                //Console.WriteLine(tokens[0]);
                //Console.WriteLine(tokens[1]);

                string userIdFromFile = tokens[0];
                string userPassword = tokens[1];
                //string userPassword = "hyra123";

                if (userIdFromFile == persnumber && userPassword == password)
                {
                    loginOk = true;
                    currentUser = persnumber;
                }
                
            }
            if (loginOk)
            {
                Console.WriteLine("Inloggningen lyckades");
                return true;
            }
            else
            {
                //LoginPage();
                return false;
            }
        }
            //Ändra lösenord för användare
            public static void ChangePassword()
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange nytt lösenord: ");
                var newPassword = Console.ReadLine();

                List<string> allUsers = new List<string>(File.ReadAllLines(@"C:\Users\albert.rogo\source\repos\bibliotek.cs\Users.txt"));  
                int i = 0;
                int lineNumber = 0;
                string line = "";
                foreach (var user in allUsers)
                {
                    string[] tokens1 = user.Split(" ");
                    string userIdFromFile = tokens1[0];
                    if(userIdFromFile == currentUser)
                    {
                        line = $"{userIdFromFile} {newPassword}";
                        Console.Write($"{currentUser} {userIdFromFile} {newPassword}");
                        lineNumber = i;
                    }
                    i++;
                }
                allUsers[i-1] = line;
                File.WriteAllLines(@"C:\Users\albert.rogo\source\repos\bibliotek.cs\Users.txt", allUsers.ToArray());
            }



        //Ser till så något skrivs vid registrering
        static bool UserInfoIncomplete(string? firstPersnumber, string? password)
        {
            if (firstPersnumber == null || firstPersnumber == "") return true;
            if (password == null || password == "") return true;

            return false;
        }
    }
}
