namespace Topic_1_6____Summative_Game
{
    internal class Program
    {
        public static void Lose(double bet, double balance)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Uh oh! You didn't win your bet!");
            Console.WriteLine($"You bet {bet.ToString("C")} and lost it!");
            Console.WriteLine($"Your new balance is {balance.ToString("C")}. ");
        }

        public static void Win(double bet, double balance)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("WOW! Congrats! You won your bet!");
            Console.WriteLine($"You bet {bet.ToString("C")} and gained it back!");
            Console.WriteLine($"Your new balance is {balance.ToString("C")}. ");

        }
        static void Main(string[] args)
        {
            double bet, accountBalance;
            string choice;
            accountBalance = 100;
            Boolean done = false;
            Die die1, die2;
            die1 = new Die();
            die2 = new Die();
            
            Console.WriteLine("Hello and Welcome to Casino Italiano! Here you can bet on the outcome of two dice. \nPlease wait for the game to begin...");
            Thread.Sleep(4000);
            while (!done)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Clear();
                die1.RollDie();
                die2.RollDie();
                Console.WriteLine($"Your current account balance is: {accountBalance.ToString("C")} ");
                Console.WriteLine();
                Console.WriteLine("The possible outcomes you can bet on are: ");
                Console.WriteLine("1 - Doubles");
                Console.WriteLine("2 - Not Doubles");
                Console.WriteLine("3 - Even Sum");
                Console.WriteLine("4 - Odd Sum");
                Console.WriteLine("Q - Quit");
                Console.WriteLine();
                Console.WriteLine("How much money would you like to bet? ");
                Console.ForegroundColor= ConsoleColor.White;
                while (!Double.TryParse(Console.ReadLine(), out bet) || bet > accountBalance || bet < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Incorrect bet. Please try again. You can only bet up to {accountBalance.ToString("C")}.");
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("What would you like to bet on? Type the number OR the name: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine().ToLower().Trim();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"You picked {choice}. Let's see if you bet right...");

                if (choice == "1" || choice == "doubles")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    die1.DrawDie();
                    die2.DrawDie();
                    Console.WriteLine();
                    if (die1.Roll == die2.Roll)
                    {
                        accountBalance += bet;
                        Win(bet, accountBalance);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Press ENTER to move on to the next match! ");
                        Console.ReadLine();
                    }
                    else
                    {
                        accountBalance -= bet;
                        Lose(bet, accountBalance);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Press ENTER to move on to the next match! ");
                        Console.ReadLine();
                    }

                }
                else if (choice == "2" || choice == "not doubles")
                {

                }
                else if (choice == "3" || choice == "even sum")
                {

                }
                else if (choice == "4" || choice == "odd sum")
                {

                }
                else if (choice == "q" || choice == "quit")
                {
                    Console.WriteLine("Thanks for playing!");
                    Thread.Sleep(2500);
                    done= true;
                }
                //else
                //{
                //    Console.WriteLine("Incorrect betting option. ");
                //}






            }







        }
    }
}
