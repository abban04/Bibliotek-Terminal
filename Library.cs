using System.Security.Cryptography.X509Certificates;

namespace bibliotek
{
    internal class Library
    {
        //Kollar status på bok
        static bool[] isBookBorrowed = new bool[10];
        public Library()
        {
            for (int i = 0; i < 10; i++)
            {
                isBookBorrowed[i] = false;
            }
        }

        //Söker upp böcker utifrån lån eller tillbakalämning
        public static void Search()
        {
            Console.Clear();
            string rentGive = "";

            Console.WriteLine("Välkommen! Vill du låna eller lämna tillbaka? (l/t) ");
            rentGive = Console.ReadLine();

            if (rentGive == "l")
            {
                BorrowBook();
            }
            else if (rentGive == "t")
            {
                ReturnBook();
            }
        }

        //Låna bok 
        public static void BorrowBook()
        {
            Console.Clear();
            bool bookFound = false;
            string bookNum = "";

            Console.WriteLine("Välkommen! Vänligen ange boktitel: ");
            var bookTitle = Console.ReadLine();

            Console.WriteLine("Vänligen ange författare: ");
            var bookAuthor = Console.ReadLine();

            Console.WriteLine("Vänligen ange ISBN: ");
            var bookISBN = Console.ReadLine();

            string[] booksFromFile = File.ReadAllLines(@"C:\Users\albert.rogo\source\repos\bibliotek.cs\bibliotek.cs\Books.txt");
            foreach (var line in (booksFromFile))
            {
                string[] tokens = line.Split(" ");
                if (line.Contains(bookTitle.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];
                }

                else if (line.Contains(bookAuthor.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];

                }
                else if (line.Contains(bookISBN.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];
                }

            }

            if (bookFound)
            {
                int bookIndex = Int16.Parse(bookNum);

                if (isBookBorrowed[bookIndex] == false)
                {
                    Console.WriteLine("Boken finns tillgänglig för utlåning. Vill du låna den? j/n:  ");
                    var rentBook = Console.ReadLine();
                    if (rentBook == "j")
                    {
                        isBookBorrowed[bookIndex] = true;
                        Console.WriteLine("Boken är nu utlånad till dig. Du tas tillbaks till huvudmenyn...");
                        Thread.Sleep(4000);
                    }
                    else
                    {
                        Console.WriteLine("Du tas tillbaks till huvudmenyn. Var god vänta.");
                        Thread.Sleep(4000);
                    }
                }
                else
                {
                    Console.WriteLine("Boken finns tyvärr inte tillgänglig");
                    Console.WriteLine("Du tas tillbaks till huvudmenyn. Var god vänta.");
                    Thread.Sleep(4000);
                }
            }
        }

        //Lämna tillbaka bok
        public static void ReturnBook()
        {
            Console.Clear();
            bool bookFound = false;
            string bookNum = "";

            Console.WriteLine("Tillbakalämning av bok");
            Console.WriteLine("Skriv bokens ISBN: ");
            var ISBNnumber = Console.ReadLine();

            string[] booksFromFile = File.ReadAllLines(@"C:\Users\albert.rogo\source\repos\bibliotek.cs\bibliotek.cs\Books.txt");
            foreach (var line in (booksFromFile))
            {
                string[] tokens = line.Split(" ");
                if (line.Contains(ISBNnumber.ToString()))
                {
                    bookFound = true;
                    bookNum = tokens[0];
                    Console.WriteLine($"Bekräfta att du vill lämna tillbaka boken med ISBN nummret {ISBNnumber}: (j/n)");
                    var answer = Console.ReadLine();

                    if (answer == "j")
                    {
                        isBookBorrowed[Int16.Parse(bookNum)] = false;
                        Console.WriteLine("Boken är nu tillbakalämnad");
                    }
                    else
                    {
                        Console.WriteLine("Du tas tillbaka till huvudmenyn...");
                        Thread.Sleep(3000);
                    }
                }
            }
        }
    }
}
