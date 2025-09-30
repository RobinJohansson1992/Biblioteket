namespace Biblioteket
{

    
    internal class Program
    {
        //Array that holds the available books in the library:
        static (int bookIndex, string books, int available)[] bookInfo =


            {
                (1, "Harry Potter", 2),
                (2, "Sagan om ringen", 1),
                (3, "Bamse i trollskogen", 4),
                (4, "Throne of glass", 1),
                (5, "A  song of ice and fire", 2)
            };


        static (string borrowedBooks, int numbersBorrowed)[] borrowedInfo =
      {
                ("Harry Potter", 0),
                ("Sagan om ringen", 0),
                ("Bamse i trollskogen", 0),
                ("Throne of glass", 0),
                ("A  song of ice and fire", 0)
        };



        //Method for returning books:
        static void ReturnBooks()
        {
            Console.Clear();
            Console.WriteLine("Ange index-nummer på boken du vill returnera:");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 5)
            {
                Console.WriteLine("Du måste ange index-nummer på en bok i biblioteket.");
            }

            // Userinput - 1 is saved in arrayIndex because the array begins on 0:
            int arrayIndex = userInput - 1;
            // book stores the book the user picked from bookInfo:
            var book = bookInfo[arrayIndex];
            // returnBook also stores the book the user picked to know if a book is borrowed...
            var returnBook = borrowedInfo[arrayIndex];

            while (returnBook.numbersBorrowed < 1)
            {
                Console.WriteLine("Den här boken har du inte i ditt 'lånat-saldo'.");
                Console.WriteLine("Tryck enter för att återgå till menyn.");
                Console.ReadLine();
                Menu();
            }

            if (arrayIndex > 0 || arrayIndex < 6)
            {
                // Available books of the one the user picked increase by +1 in library,
                // the book the user returns decrease by -1 in borrowed books.
                bookInfo[arrayIndex] = (book.bookIndex, book.books, book.available + 1);
                borrowedInfo[arrayIndex] = (returnBook.borrowedBooks, returnBook.numbersBorrowed - 1);
                Console.WriteLine($"Du lämnade tillbaka {book.books}.");
                Console.WriteLine("Tryck enter får att återgå till menyn.");
                Console.ReadLine();
            }
            
           

                Menu();
        }

        //Method for borrowing books:
        static void BorrowBooks()
        {
            Console.Clear();
            Console.WriteLine("Skriv in index-nummer på boken du vill låna:");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 5)
            {
                Console.WriteLine("Du måste ange ett index-nummer på en bok i biblioteket.");
            }

            // Userinput - 1 is saved in arrayIndex because the array begins on 0:
            int arrayIndex = userInput - 1;

            // book stores the book the user picked from bookInfo:
            var book = bookInfo[arrayIndex];
            // borrowed also stores the book the user picked to know if a book is borrowed...
            var borrowed = borrowedInfo[arrayIndex];

            if (book.available > 0)
            {
                //If there are more than 0 books in the library, book.available is reduced by -1.
                bookInfo[arrayIndex] = (book.bookIndex, book.books, book.available - 1);
                //... and the numbersBorrowed increadse by +1
                borrowedInfo[arrayIndex] = (borrowed.borrowedBooks, borrowed.numbersBorrowed + 1);
                Console.WriteLine($"Du lånade boken {book.books}, du har nu lånat {borrowed.numbersBorrowed + 1} ex av {borrowed.borrowedBooks} ");
                
            }
            else
            {
                //If there are 0 of this book left in the library, print this:
                Console.WriteLine("Den här boken finns inte just nu.");
            }

                Console.WriteLine("Tryck enter för att återgå till huvudmenyn.");
            Console.ReadLine();
            Menu();
        }

        static void Main(string[] args)
        {

            LogIn();

        }


        //Login menu method:
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

                //Successful login opens the main menu:
                if (success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Välkommen {user1}! \n");
                    Console.ResetColor();
                    Console.WriteLine("Tryck valfri knapp för att gå vidare.");
                    Console.ReadLine();
                    Menu();
                }
                //User has 3 attempts to log in
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktigt användarnamn eller PIN-kod.");
                    Console.ResetColor();
                    attempts--;
                }

                //Program stops if the login fails 
                if (attempts <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du klarade inte att logga in på 3 försök. \nProgrammet avslutas...");
                    Console.ResetColor();
                    Environment.Exit(0);
                }

            }


        }

        //Method that displays the main menu:
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
                    BorrowBooks();
                    break;

                case 3:
                    ReturnBooks();
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

        //Method to display the available books in library:
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
