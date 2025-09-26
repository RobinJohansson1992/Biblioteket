namespace Biblioteket
{

    
    internal class Program
    {
        static (int bookIndex, string books, int available)[] bookInfo =


            {
                (1, "Harry Potter", 2),
                (2, "Sagan om ringen", 1),
                (3, "Bamse i trollskogen", 4),
                (4, "Throne of glass", 1),
                (5, "A  song of ice and fire", 2)
            };


        static void Main(string[] args)
        {

            LogIn();

            Menu();
            
        }

        static void LogIn()
        {
            (string userName, int code)[] users =
            {
                ("Chewy", 4466),
                ("Luke", 1234),
                ("Han", 1992),
                ("Leia", 9999),
                ("Yoda", 1337)
            };
            Console.Clear();
            Console.WriteLine("Välkommen till bibliotekets lånesystem! \nAnge användarnamn och pinkod för att logga in:");

            bool success = false;

            int attempts = 3;

            while (!success)
            {

                Console.Write("Användarnamn:"); string user1 = Console.ReadLine();
                Console.Write("PIN-kod:"); int pin;
                while (!int.TryParse(Console.ReadLine(), out pin))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Din pinkod kan endast bestå av heltal.");
                    Console.ResetColor();
                }

                foreach (var user in users)
                {
                    if (user.userName == user1 && user.code == pin)
                    {
                        success = true;
                        break;
                    }
                }

                if (success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Välkommen {user1}! \n");
                    Console.ResetColor();
                    Console.WriteLine("Tryck valfri knapp för att gå vidare.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktigt användarnamn eller PIN-kod.");
                    Console.ResetColor();
                    attempts--;
                }

                if (attempts <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du klarade inte att logga in på 3 försök. \nProgrammet avslutas...");
                    Console.ResetColor();
                    Environment.Exit(0);
                }

            }


        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Visa böcker \n2. Låna bok \n3. Lämna tillbaka bok \n4. Mina lån \n5. Logga ut");

            int userChoise;

            while (!int.TryParse(Console.ReadLine(), out userChoise) || userChoise < 1 || userChoise > 5)
            {
                Console.WriteLine("Du måste ange ett nummer från listan.");
            }


            switch (userChoise)
            {
                case 1:
                    DisplayBooks();
                    break;

                case 2:
                    Console.WriteLine("Låna bok");
                    break;

                case 3:
                    Console.WriteLine("Lämna tillbaka bok");
                    break;

                case 4:
                    Console.WriteLine("Mina lån");
                    break;

                case 5:
                    Console.WriteLine("Logga ut");
                    Console.WriteLine("Du loggas ut... Tryck enter för att återgå till startsidan.");
                    Console.ReadLine();
                    
                    LogIn();
                    break;
            }
        }

        static void DisplayBooks()
        {
            Console.Clear();
            Console.WriteLine("Tillgängliga böcker:");

            foreach (var book in bookInfo)
            {
                Console.WriteLine($"{book.bookIndex}. {book.books}, antal: {book.available}");
            }
            Console.WriteLine("Tryck enter för att återgå till menyn.");
            Console.ReadLine();
            Menu();
        }


        
    }
}
