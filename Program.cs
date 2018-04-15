//|==============================================================|//
// Made by IntSPstudio
// Quess The Number
// Thank you for using this game!
// Version: 0.0.1.20180415
// ID: 650004001
//
// Twitter: @IntSPstudio
//|==============================================================|//

//IMPORT
using System;

namespace QuessTheNumber
{
    class Program
    {
        //MASTER
        static void Main(string[] args)
        {
            //SETTINGS
            StSe();
            //START
            OnePlayerGame();
        }
        /*
            SETTINGS 
        */
        //COMMON VARIABLES
        public static class Globals
        {
            //VISUALS
            public static string lineStMark = "=]";
            //NUMBER TO BE QUESSED
            public static int correctNumber = 0;
            //RANDOM NUMBER BETWEEN LN AND HN
            public static int correctNumberLN = 1;
            public static int correctNumberHN = 10;
            public static int correctNumberRange = correctNumberHN - correctNumberLN;
            //COM MESSAGES
            public static string messageWrongNumber = "Wrong number, please try again";
            public static string messageCorrectNumber = "You are correct! Number of tries: ";
            public static string messageCoHiNumber = "Number need to be bigger";
            public static string messageCoLoNumber = "Number need to be smaller";
            public static string messageInvalidInput = "Please use only a numbers";
            public static string messageQuessNumberBetween = "Quess a number";
            public static string messagePlayAgain = "Do you want to play again? Yes/No";
            //USER DATA
            public static int userAfNumQuess = 0;
        }
        /*
            FUNCTIONS
        */
        //START PROCESS
        static void StSe()
        {
            //CREATE RANDOM NUMBER WITH INSTRUCTIONS
            Random random = new Random();
            Globals.correctNumberHN = random.Next(10, 100);
            Globals.correctNumber = random.Next(Globals.correctNumberLN, Globals.correctNumberHN);
            Globals.correctNumberRange = Globals.correctNumberHN - Globals.correctNumberLN;
            //TEXT UPDATE
            Globals.messageQuessNumberBetween = "Quess a number between " + Globals.correctNumberLN.ToString() + " and " + Globals.correctNumberHN.ToString();
            Console.Title = "Quess The Number";
            //RESET
            Globals.userAfNumQuess = 1;
        }
        //PRINT TO CONSOLE
        static void ConsolePrint(int printMode, string rawInput)
        {
            //MARK
            Console.Write(Globals.lineStMark);
            //COLOR
            switch (printMode)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }
            //PRINT
            Console.WriteLine(rawInput);
            //RESET
            Console.ResetColor();
        }
        /*
            GAME OPTIONS
        */
        //ONE PLAYER GAME
        static void OnePlayerGame()
        {
            //SETTINGS
            int userGuess = 0;
            string rawInput = "";
            //START
            ConsolePrint(1, Globals.messageQuessNumberBetween);
            //LOOP
            while(userGuess != Globals.correctNumber)
            {
                //RAW INPUT
                Console.Write(Globals.lineStMark);
                rawInput = Console.ReadLine();
                rawInput = rawInput.ToLower();
                if (rawInput == "exit")
                {
                    return;
                }
                else
                {
                    //FORMAT
                    if (!int.TryParse(rawInput, out userGuess))
                    {
                        //ERROR MESSAGE
                        ConsolePrint(3, Globals.messageInvalidInput);
                        continue;
                    }
                    userGuess = Int32.Parse(rawInput);
                    //CHECK
                    if (userGuess != Globals.correctNumber)
                    {
                        //ADDER
                        Globals.userAfNumQuess += 1;
                        //MESSAGE
                        ConsolePrint(3, Globals.messageWrongNumber);
                        //HELP
                        if(Globals.correctNumberRange >= 10)
                        {
                            if(userGuess > Globals.correctNumber)
                            {
                                ConsolePrint(4, Globals.messageCoLoNumber);
                            }
                            else
                            {
                                ConsolePrint(4, Globals.messageCoHiNumber);
                            }
                        }
                    }
                }
            }
            //CONTINUE
            string output = Globals.messageCorrectNumber + Globals.userAfNumQuess.ToString();
            ConsolePrint(2, output);
            //PLAY AGAIN
            ConsolePrint(1, Globals.messagePlayAgain);
            rawInput = Console.ReadLine();
            //FORMAT
            rawInput = rawInput.ToLower();
            if (rawInput == "yes")
            {
                StSe();
                Console.Clear();
                OnePlayerGame();
            }
        }
    }
}