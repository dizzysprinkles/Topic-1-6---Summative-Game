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

        public static void Win(double bet, double balance, string winnings)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("WOW! Congrats! You won your bet!");
            Console.WriteLine($"You bet {bet.ToString("C")} and gained {winnings}it back!");
            Console.WriteLine($"Your new balance is {balance.ToString("C")}. ");

        }
        static void Main(string[] args)
        {
            Console.Title = "Casino Italiano";
            double bet, accountBalance;
            string choice, winnings;
            int sumDies, round;
            accountBalance = 100;
            Boolean done = false;
            Die die1, die2;
            die1 = new Die();
            die2 = new Die();
            round = 1;
            

            Console.WriteLine("Hello and Welcome to Casino Italiano! Here you can bet on the outcome of two dice. \nPlease wait for the game to begin...");
            Thread.Sleep(4000);
            while (!done)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Clear();
                winnings = "";
                die1.RollDie();
                die2.RollDie();
                Console.WriteLine($"Current round: {round}.");
                Console.WriteLine($"Your current account balance is: {accountBalance.ToString("C")} ");
                Console.WriteLine();
                Console.WriteLine("The possible outcomes you can bet on are, how much you would gain back, and the odds: ");
                Console.WriteLine();
                Console.WriteLine("1 - Doubles          [Win double your bet!]      Odds: 17%");
                Console.WriteLine("2 - Not Doubles      [Win half your bet!]        Odds: 83%");
                Console.WriteLine("3 - Even Sum         [Win your bet!]             Odds: 50%");
                Console.WriteLine("4 - Odd Sum          [Win your bet!]             Odds: 50%");
                Console.WriteLine("5 - Sum of Seven     [Win triple your bet!]      Odds: 17%");
                Console.WriteLine("Q - Quit             [Quit the game]");
                Console.WriteLine();
            
                Console.WriteLine("What would you like to bet on? Type the number OR the name: \n**Incorrect selections will result in a loss of your bet**. ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine().ToLower().Trim();

                if (choice == "q" || choice == "quit")
                { 
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine();
                    Console.WriteLine("Thanks for playing!");
                    Thread.Sleep(2500);
                    done = true;
                }

                else
                {
                    round += 1;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("How much money would you like to bet? ");
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!Double.TryParse(Console.ReadLine(), out bet) || bet > accountBalance || bet < 0 || bet == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"Incorrect bet. Please try again. You can only bet between $0.01 and {accountBalance.ToString("C")}.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

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
                            winnings = "double of ";
                            accountBalance = accountBalance + (2*bet);
                            Win(bet, accountBalance, winnings);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }
                        else
                        {
                            accountBalance -= bet;
                            Lose(bet, accountBalance);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }

                    }
                    else if (choice == "2" || choice == "not doubles")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        die1.DrawDie();
                        die2.DrawDie();
                        Console.WriteLine();
                        if (die1.Roll != die2.Roll)
                        {
                            winnings = "half of ";
                            accountBalance = accountBalance + (bet/2);
                            Win(bet, accountBalance, winnings);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
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
                    else if (choice == "3" || choice == "even sum")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        die1.DrawDie();
                        die2.DrawDie();
                        Console.WriteLine();
                        sumDies = die1.Roll + die2.Roll;
                        if (sumDies % 2 == 0)
                        {
                            accountBalance += bet;
                            Win(bet, accountBalance, winnings);
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
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }
                    }
                    else if (choice == "4" || choice == "odd sum")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        die1.DrawDie();
                        die2.DrawDie();
                        Console.WriteLine();
                        sumDies = die1.Roll + die2.Roll;
                        if (sumDies % 2 != 0)
                        {
                            accountBalance += bet;
                            Win(bet, accountBalance, winnings);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }
                        else
                        {
                            accountBalance -= bet;
                            Lose(bet, accountBalance);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }

                    }
                    else if (choice == "5" || choice == "sum of seven")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        die1.DrawDie();
                        die2.DrawDie();
                        Console.WriteLine();
                        sumDies = die1.Roll + die2.Roll;
                        if (sumDies == 7)
                        {
                            winnings = "triple of ";
                            accountBalance = accountBalance + (3*bet);
                            Win(bet, accountBalance, winnings);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }
                        else
                        {
                            accountBalance -= bet;
                            Lose(bet, accountBalance);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Press ENTER to move on to the next round! ");
                            Console.ReadLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Incorrect betting option. Your bet of {bet.ToString("C")} will now be subtracted from your account.");
                        accountBalance -= bet;
                        Console.WriteLine($"Your new balance is {accountBalance.ToString("C")}");
                        Console.WriteLine();
                        Console.WriteLine("Press ENTER to move on to the next round!");
                        Console.ReadLine();
                    }

                }
                
            }
        }
    }
}
