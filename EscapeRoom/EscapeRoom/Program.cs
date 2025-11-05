using System.Reflection.Metadata.Ecma335;

namespace EscapeRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowTitle();
            ShowIntro();
            StartGame();
        }

        static void ShowTitle()
        {
            Console.Clear();
            Console.WriteLine(@"
 ___                         ___
| __|___ __ __ _ _ __  ___  | _ \___  ___ _ __
| _|(_-</ _/ _` | '_ \/ -_) |   / _ \/ _ \ '  \
|___/__/\__\__,_| .__/\___| |_|_\___/\___/_|_|_|
                |_|
================================================
");
        }

        static void ShowIntro()
        {
            Console.WriteLine("Solve the puzzles before time runs out!");
            Console.WriteLine("Press enter to start your adventure...");
            Console.ReadLine();
        }

        static void ShowColoredText(string text, ConsoleColor color, bool appendLine = false)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            if (appendLine)
            {
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void ShowStatus(int timeLeft, bool keypadSolved, bool riddleSolved)
        {
            ShowColoredText($"Time left: {timeLeft} minutes", ConsoleColor.Blue, true);
            ShowColoredText($"Keypad: {(keypadSolved ? "solved" : "unsolved")}", ConsoleColor.Blue, true);
            ShowColoredText($"Riddle: {(riddleSolved ? "solved" : "unsolved")}", ConsoleColor.Blue, true);
            Console.WriteLine();
        }

        static void ShowMenu()
        {
            ShowColoredText("Choose an action:", ConsoleColor.White, true);
            ShowColoredText("  1) Try keypad", ConsoleColor.White, true);
            ShowColoredText("  2) Solve riddle", ConsoleColor.White, true);
            ShowColoredText("  3) Open final door", ConsoleColor.White, true);
            ShowColoredText("  9) Give up", ConsoleColor.White, true);
            ShowColoredText("Your choice: ", ConsoleColor.White, false);
        }

        static int ReadAction()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                return choice;
            }
            return -1;
        }

        static int ApplyPenalty(int timeLeft, int penalty)
        {
            int newTime = timeLeft - penalty;
            if (newTime < 0)
            {
                newTime = 0;
            }
            ShowColoredText($"Time penalty: -{penalty} minute(s).", ConsoleColor.DarkYellow, true);
            return newTime;
        }

        static bool TryKeypad()
        {
            ShowColoredText("Enter 3-digit keypad code: ", ConsoleColor.Magenta);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int code) == false)
            {
                ShowColoredText("Invalid code (not a number).", ConsoleColor.DarkRed, false);
            }
            else
            {
                if (code != 314)
                {
                    ShowColoredText("Wrong code.", ConsoleColor.Red, false);
                    return true;
                }
                else
                {
                    ShowColoredText("Keypad unlocked!", ConsoleColor.Green, true);
                }
            }

            return false;
        }

        static bool SolveRiddle()
        {
            ShowColoredText("Riddle: Speak friend and enter...", ConsoleColor.Magenta, true);
            ShowColoredText("Type the secret word: ", ConsoleColor.Magenta);

            string answer = Console.ReadLine();

            if (answer.Trim().ToLower() == "open-sesame")
            {
                ShowColoredText("The wall slides aside.", ConsoleColor.Green, true);
                return true;
            }
            else
            {
                ShowColoredText("The wall remains silent.", ConsoleColor.Red, false);
                return false;
            }
        }

        static bool FinalDoor(bool keypadSolved, bool riddleSolved)
        {
            if (!keypadSolved && !riddleSolved)
            {
                ShowColoredText("The final door won’t budge. Solve the other puzzles first.", ConsoleColor.Red, false);
            }

            ShowColoredText("Final number (1..5): ", ConsoleColor.Magenta);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int id) || id > 5 || id < 1)
            {
                ShowColoredText("That is not between 1 and 5.", ConsoleColor.DarkRed, false);
            }
            else if (id != 3)
            {
                ShowColoredText("A buzzer sounds. Wrong!", ConsoleColor.Red, false);
            }
            else
            {
                ShowColoredText("You hear the lock click!", ConsoleColor.Green, true);
            }
            return false;
        }

        public static void StartGame()
        {
            int timeLeft = 15;
            bool keypadSolved = false;
            bool riddleSolved = false;
            bool escaped = false;

            while (timeLeft > 0 && !escaped)
            {
                ShowTitle();
                ShowStatus(timeLeft, keypadSolved, riddleSolved);
                ShowMenu();
                int choice = ReadAction();

                if (choice == 1)
                {
                    if (keypadSolved || TryKeypad())
                    {
                        keypadSolved = true;
                    }
                    else
                    {
                        timeLeft = ApplyPenalty(timeLeft, 2);
                    }
                }
                else if (choice == 2)
                {
                    if (riddleSolved || SolveRiddle())
                    {
                        riddleSolved = true;
                    }
                    else
                    {
                        timeLeft = ApplyPenalty(timeLeft, 2);
                    }
                }
                else if (choice == 3)
                {
                    if (FinalDoor(keypadSolved, riddleSolved))
                    {
                        escaped = true;
                    }
                    else
                    {
                        timeLeft = ApplyPenalty(timeLeft, 1);
                    }
                }
                else if (choice == 9)
                {
                    ShowColoredText("You give up...", ConsoleColor.Blue, true);
                    break;
                }
                else
                {
                    ShowColoredText("Invalid choice!", ConsoleColor.DarkRed, true);
                    timeLeft = ApplyPenalty(timeLeft, 2);
                }

                Console.ReadLine();
            }

            if (escaped)
            {
                ShowColoredText("You escaped!", ConsoleColor.DarkGreen, true);
            }
            else if (timeLeft <= 0)
            {
                ShowColoredText("Time is up. The door remains locked.", ConsoleColor.Red, true);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
}
