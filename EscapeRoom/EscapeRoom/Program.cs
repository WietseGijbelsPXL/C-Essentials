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

        //Dit is gewoon uitrpniten in de console
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

        //Dit is ook gewoon in de console printen
        static void ShowIntro()
        {
            Console.WriteLine("Solve the puzzles before time runs out!");
            Console.WriteLine("Press enter to start your adventure...");
            Console.ReadLine();
        }

        //string text = de tekst die ge wilt laten printen in de console
        //color = de kleur die ge wilt gebruiken voor de tekst
        //appendLine = of ge een nieuwe lijn wilt toevoegen na de tekst
        static void ShowColoredText(string text, ConsoleColor color, bool appendLine = false)
        {
            //de kleur voor de tekst word gezet
            Console.ForegroundColor = color;
            //de tekst word geschereven
            Console.Write(text);
            //als appendLinde true is , word er een nieuwe lijn toegevoegd
            if (appendLine)
            {
                Console.WriteLine();
            }
            //de kleur word teruggezet naar de standaard kleur
            Console.ResetColor();
        }

        //weer gewoon printen in de console
        static void ShowStatus(int timeLeft, bool keypadSolved, bool riddleSolved)
        {
            ShowColoredText($"Time left: {timeLeft} minutes", ConsoleColor.Blue, true);
            ShowColoredText($"Keypad: {(keypadSolved ? "solved" : "unsolved")}", ConsoleColor.Blue, true);
            ShowColoredText($"Riddle: {(riddleSolved ? "solved" : "unsolved")}", ConsoleColor.Blue, true);
            Console.WriteLine();
        }

        //weer gewoon printen in de console
        static void ShowMenu()
        {
            ShowColoredText("Choose an action:", ConsoleColor.White, true);
            ShowColoredText("  1) Try keypad", ConsoleColor.White, true);
            ShowColoredText("  2) Solve riddle", ConsoleColor.White, true);
            ShowColoredText("  3) Open final door", ConsoleColor.White, true);
            ShowColoredText("  9) Give up", ConsoleColor.White, true);
            ShowColoredText("Your choice: ", ConsoleColor.White, false);
        }

        //hier word uitgelezen wat de speler heeft ingevoerd
        //int betekent dat er een getal is als uitkomst van deze functie dus, ReadAction() geeft een getal
        static int ReadAction()
        {
            //Lees wat er getypt is en steek het in input
            string input = Console.ReadLine();
            //tryparse kijkt of het een getal is, zoja steek het in choice, zo nee geef -1 terug
            if (int.TryParse(input, out int choice))
            {
                return choice;
            }
            return -1;
        }

        //int is zelfde als vorige
        //hier word tijd berekend op basis van de tijd die er nog is en de penalty aka hoeveel er vanaf gaat
        //en dan gewoon uitgeprint
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

        //eerste raadsel
        static bool TryKeypad()
        {
            ShowColoredText("Enter 3-digit keypad code: ", ConsoleColor.Magenta);
            string input = Console.ReadLine();

            //check dat het een nummer is
            if (!int.TryParse(input, out int code))
            {
                ShowColoredText("Invalid code (not a number).", ConsoleColor.DarkRed, false);
                return false;
            }
            //check of het niet gelijk is aan 314
            if (code != 314)
            {
                ShowColoredText("Wrong code.", ConsoleColor.Red, false);
                return false;
            }
            //als de vorige falen beteknd da dat het in orde is en dat het juist is
            else
            {
                ShowColoredText("Keypad unlocked!", ConsoleColor.Green, true);
                return true;
            }
        }

        //tweede raadsel
        static bool SolveRiddle()
        {
            ShowColoredText("Riddle: Speak friend and enter...", ConsoleColor.Magenta, true);
            ShowColoredText("Type the secret word: ", ConsoleColor.Magenta);

            //haal antwoord uit de console
            string answer = Console.ReadLine();

            //check of het antwoord gelijk is aan open-sesame
            //trim verwijderd spaties voor en na de string
            //tolower maakt alles lowercase
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
            //check dat beide raadsels zijn opgelost
            //als een van beide nog niet is opgelost werkt het niet
            if (!keypadSolved || !riddleSolved)
            {
                ShowColoredText("The final door won’t budge. Solve the other puzzles first.", ConsoleColor.Red, false);
                return false;
            }

            ShowColoredText("Final number (1..5): ", ConsoleColor.Magenta);
            string input = Console.ReadLine();

            //check dat er een nummer is ingegeven en dat het nummer tussen 5 en 1 ligt
            if (!int.TryParse(input, out int id) || id > 5 || id < 1)
            {
                ShowColoredText("That is not between 1 and 5.", ConsoleColor.DarkRed, false);
                return false;
            }
            //als het niet gelijk is aan 3 dan is het fout
            else if (id != 3)
            {
                ShowColoredText("A buzzer sounds. Wrong!", ConsoleColor.Red, false);
                return false;
            }
            //anders ist juist, want dan is het 3
            else
            {
                ShowColoredText("You hear the lock click!", ConsoleColor.Green, true);
                return true;
            }
        }

        public static void StartGame()
        {
            //standaard start waarden
            int timeLeft = 15;
            bool keypadSolved = false;
            bool riddleSolved = false;
            bool escaped = false;

            //zolang er tijd over is en de speler niet is ontsnapt
            while (timeLeft > 0 && !escaped)
            {
                //print deze dingen
                ShowTitle();
                ShowStatus(timeLeft, keypadSolved, riddleSolved);
                ShowMenu();
                //steek de keuze die de speler doet in choice
                int choice = ReadAction();

                //als het 1 of 2 is
                //kijk of hiet nie als is opgelost (dan is kepadSolved of riddleSolved true)
                //of als het niet is opgelost probeer het dan op te lossen met TryKeypad() of SolveRiddle(), dit returned true als het juist is opgelost
                // als het fout is doet ge de tijd min 2
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
                //als het 3 is 
                //check dat het laatste raadsel goed word gedaan
                //dan is escaped true omdat het uitgespeeld is
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
                //9 is give up, dus dan doet ge break zodat ge uit de while loop spring
                else if (choice == 9)
                {
                    ShowColoredText("You give up...", ConsoleColor.Blue, true);
                    break;
                }
                //dit is als er iets anders is ingegeven dan 1,2,3 of 9
                else
                {
                    ShowColoredText("Invalid choice!", ConsoleColor.DarkRed, true);
                    timeLeft = ApplyPenalty(timeLeft, 2);
                }
                //wacht op enter voordat ge verder gaat
                Console.ReadLine();
            }

            //als ge uit de while loop ko;t door tijd op is of ge bent ontsnapt
            //check of ge ontsnapt zijt dan gewonne
            //anders check tijd op 0 dan verloren
            //als optie 9 is gekozen is er geen win of verlies bericht dan ist gewoon press any key to exit
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

