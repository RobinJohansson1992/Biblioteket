namespace Biblioteket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till bibliotekets lånesystem! \nAnge användarnamn och lösenkod för att logga in:");

            LogIn();

            Console.WriteLine("vad vill du göra?");
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
                    break;
                }

            }




        }
    }
}
