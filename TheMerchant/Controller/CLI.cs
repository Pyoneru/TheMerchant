using System;
using System.Collections.Generic;
using System.Text;
using TheMerchant.Model;

namespace TheMerchant.Controller
{
    public class CLI
    {
        private int selectedOptionIndex;
        private ConsoleKeyInfo pressedKey;
        public CLIMenu Menu { get; set; }

        private CLI()
        {
            Console.CursorVisible = false;
            selectedOptionIndex = 0;
            Menu = new CLIMenu();
        }

        private static CLI instance;

        public static CLI GetInstance()
        {
            if(instance == null)
            {
                instance = new CLI();
            }
            return instance;
        }

        public void WriteMenu(CLIMenu Menu, string selectedOption)
        {
            Console.SetCursorPosition(0, 0);

            if(!Menu.Title.Equals(""))
                Console.WriteLine("{0}\n",Menu.Title);
            if (!Menu.Description.Equals(""))
                Console.WriteLine("{0}\n",Menu.Description);

            for (int i = 0; i < Menu.Count; i++)
            {
                if (Menu.GetOptionName(i).Equals(selectedOption))
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(Menu.GetOptionName(i));
            }
        }

        public string GetSelectedMenuOption()
        {
            WriteMenu(Menu, Menu.GetOptionName(selectedOptionIndex));
            while (pressedKey.Key != ConsoleKey.Escape)
            {
                pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    selectedOptionIndex = (selectedOptionIndex + 1) % Menu.Count;
                    WriteMenu(Menu, Menu.GetOptionName(selectedOptionIndex));
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    selectedOptionIndex = (int)((selectedOptionIndex - 1) - Menu.Count * Math.Floor((double)(selectedOptionIndex - 1) / Menu.Count));
                    WriteMenu(Menu, Menu.GetOptionName(selectedOptionIndex));
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    return Menu.GetOptionName(selectedOptionIndex);
                }
            }
            return null;
        }

        public static string GetLine(string command = "")
        {
            int cursorBaseLeft = Console.CursorLeft;
            int cursorBaseTop = Console.CursorTop;
            Console.Write(command);
            string input = Console.ReadLine();
            Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
            char[] filler = new char[input.Length + command.Length];
            for (int i = 0; i < filler.Length; i++)
            {
                filler[i] = ' ';
            }
            Console.Write(filler);
            Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
            return input;
        }

        public static Decimal GetDecimal(string command = "")
        {
            Console.Write(command);
            int cursorBaseLeft = Console.CursorLeft;
            int cursorBaseTop = Console.CursorTop;
            Decimal value = 0;
            while (true)
            {
                string input = Console.ReadLine();
                Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
                char[] filler = new char[input.Length];
                for (int i = 0; i < filler.Length; i++)
                {
                    filler[i] = ' ';
                }
                Console.Write(filler);
                Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
                try
                {
                    value = Convert.ToDecimal(input);
                    break;
                }
                catch { }
            }
            return value;
        }
    }
}
