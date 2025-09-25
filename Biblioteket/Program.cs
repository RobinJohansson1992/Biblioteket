namespace Biblioteket
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LogIn();

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Visa böcker \n2. Låna bok \n3. Lämna tillbaka bok \n4. Mina lån \n5. Logga ut");

            int userChoise = -1;

            while (!int.TryParse(Console.ReadLine(), out userChoise) || userChoise < 1 || userChoise > 5)
            {
                Console.WriteLine("Du måste ange ett nummer från listan.");
            }

            switch (userChoise)
            {
                case 1:
                    Console.WriteLine("Visa böcker");
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
                    Console.WriteLine("Du loggas ut...");
                    Console.Clear();
                    LogIn();
                    break;
            }
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

            Console.WriteLine("Välkommen till bibliotekets lånesystem! \nAnge användarnamn och lösenkod för att logga in:");

            bool success = false;

            int attempts = 3;

            while (!success)
            {

                Console.Write("Användarnamn:"); string user1 = Console.ReadLine();
                Console.Write("PIN-kod:"); int pin;
                while (!int.TryParse(Console.ReadLine(), out pin))
                {
                    Console.WriteLine("Din pinkod kan endast bestå av heltal.");
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
                    Console.WriteLine($"Välkommen {user1}! \nTryck valfri knapp för att gå vidare.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Felaktigt användarnamn eller PIN-kod.");
                    attempts--;
                }

                if (attempts <= 0)
                {
                    Console.WriteLine("Du klarade inte att logga in på 3 försök. \nProgrammet avslutas...");
                    Environment.Exit(0);
                }

            }




        }
    }
}
