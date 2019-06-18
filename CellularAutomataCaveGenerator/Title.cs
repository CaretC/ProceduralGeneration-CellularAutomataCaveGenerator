using System;
using System.Collections.Generic;
using System.Text;

namespace CellularAutomataCaveGenerator
{
    class Title
    {
        public void PrintTitle()
        {
            // Title ASCII art for the application.
            string titleArt = @"
   
    ▄████▄   ▄▄▄    ██▒   █▓▓█████      ▄████ ▓█████  ███▄    █ ▓█████  ██▀███   ▄▄▄     ▄▄▄█████▓ ▒█████   ██▀███  
   ▒██▀ ▀█  ▒████▄ ▓██░   █▒▓█   ▀     ██▒ ▀█▒▓█   ▀  ██ ▀█   █ ▓█   ▀ ▓██ ▒ ██▒▒████▄   ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒
   ▒▓█    ▄ ▒██  ▀█▄▓██  █▒░▒███      ▒██░▄▄▄░▒███   ▓██  ▀█ ██▒▒███   ▓██ ░▄█ ▒▒██  ▀█▄ ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒
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

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Hello, let's generate a cave.");
            Console.WriteLine("Press any key to start...");
        }



        



    }
}
