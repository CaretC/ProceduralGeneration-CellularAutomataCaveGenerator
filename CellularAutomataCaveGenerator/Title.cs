using System;
using System.Collections.Generic;
using System.Text;

namespace CellularAutomataCaveGenerator
{
    class Title
    {
        private void printTitle()
        {
            // ======= Private Methods =======
            // Title ASCII art for the application.
            string titleArt = @"
   
    ▄████▄   ▄▄▄    ██▒   ████████      ▄████ ██████  ███▄    █ ██████  ██▀███   ▄▄▄     ████████▓ ▒█████   ██▀███  
   ▒██▀ ▀█  ▒████▄ ▓██░   ██▓█   ▀     ██▒ ▀█▒██   ▀  ██ ▀█   █ ██   ▀ ▓██ ▒ ██▒▒████▄   ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒
   ▒▓█    ▄ ▒██  ▀█▄▓██  █▒░▒███      ▒██░▄▄▄░████   ▓██  ▀█ ██▒████   ▓██ ░▄█ ▒▒██  ▀█▄ ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒
   ▒▓▓▄ ▄██▒░██▄▄▄▄██▒██ █░░▒▓█  ▄    ░▓█  ██▓▒▓█  ▄ ▓██▒  ▐▌██▒▒▓█  ▄ ▒██▀▀█▄  ░██▄▄▄▄██░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄  
   ▒ ▓███▀ ░ ▓█   ▓██▒▒▀█░  ░▒████▒   ░▒▓███▀▒░▒████▒▒██░   ▓██░░▒████▒░██▓ ▒██▒ ▓█   ▓██▒ ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒
   ░ ░▒ ▒  ░ ▒▒   ▓▒█░░ ▐░  ░░ ▒░ ░    ░▒   ▒ ░░ ▒░ ░░ ▒░   ▒ ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░ ▒▒   ▓▒█░ ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░
   ░  ▒     ▒   ▒▒ ░░ ░░   ░ ░  ░     ░   ░  ░ ░  ░░ ░░   ░ ▒░ ░ ░  ░  ░▒ ░ ▒░  ▒   ▒▒ ░   ░      ░ ▒ ▒░   ░▒ ░ ▒░
   ░          ░   ▒     ░░     ░      ░ ░   ░    ░      ░   ░ ░    ░     ░░   ░   ░   ▒    ░      ░ ░ ░ ▒    ░░   ░ 
   ░ ░            ░  ░   ░     ░  ░         ░    ░  ░         ░    ░  ░   ░           ░  ░            ░ ░     ░     
   ░                    ░                                                                                           
";

            // Loop through all the characters in titleArt and color characters to give required color output.
            foreach (char character in titleArt)
            {
                if (character.Equals('█') || character.Equals('▄') || character.Equals('▀'))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }

                Console.Write(character);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void printWelcomeMessage()
        {
            Console.SetCursorPosition(5, 13);
            Console.Write("Welcome to the ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cellular Automata Cave Generator ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("this console application generates random 'Cave Like' maps.");

            Console.SetCursorPosition(5, 15);
            Console.Write("To produce a map press the ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("key. Each time ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("is press a new map will be generated.");

            Console.SetCursorPosition(5, 17);
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("to generate the first map...");
        }

        // ======= Public Methods =======
        public void PrintWelcomeScreen()
        {
            printTitle();
            printWelcomeMessage();
        }

        



    }
}
