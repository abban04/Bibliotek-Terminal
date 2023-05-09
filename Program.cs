namespace bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instansierar nytt objekt av Library
            Library myLibrary = new Library();
            string answer = "";
            bool loggedIn = false;

            Console.WriteLine("Välkommen!");
            //Inloggningsdel
            while ((answer != "4"))
            {
                if (!loggedIn)
                {
                    Console.WriteLine("Välj ett av följande alternativ:");
                    Console.WriteLine("1. Registrera ny användare");
                    Console.WriteLine("2. Logga in");
                    Console.WriteLine("4. Avsluta");
                    answer = Console.ReadLine();

                    if (answer == "1")
                    {
                        Console.Clear();
                        Register.RegisterPage();
                    }
                    else if (answer == "2")
                    {
                        Console.Clear();
                        loggedIn = Register.LoginPage();
                    }
                }
                else
                {
                    //Om man är inloggad
                    Console.Clear();
                    Console.WriteLine("Du är nu inloggad. Vad vill du göra?");
                    Console.WriteLine("1. Sök efter bok");
                    Console.WriteLine("2. Låna bok");
                    Console.WriteLine("3. Lämna tillbaka bok");
                    Console.WriteLine("4. Avlsuta");
                    Console.WriteLine("5. Ändra lösenord");
                    answer = Console.ReadLine();

                    if (answer == "1")
                    {
                        Library.Search();
                    }
                    else if (answer == "2")
                    {
                        Library.BorrowBook();
                    }
                    else if (answer == "3")
                    {
                        Library.ReturnBook();
                    }
                    else if (answer == "5")
                    {
                        Register.ChangePassword();
                    }
                }
            }
            Console.WriteLine("Du loggas ut. Välkommen åter!");
            
        }
        }   
}
