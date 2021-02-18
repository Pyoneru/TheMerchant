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
        }

        private static CLI instance;

        public static CLI GetInstance()
        {
            if (instance == null)
            {
                instance = new CLI();
            }
            return instance;
        }

        public void WriteMenu(CLIMenu Menu, string selectedOption)
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            for (int rowIndex = cursorTop; rowIndex > 0; rowIndex--)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, 0);

            if (!Menu.Title.Equals(""))
                Console.WriteLine("{0}{1}", Menu.Title, Environment.NewLine);
            if (!Menu.Description.Equals(""))
                Console.WriteLine("{0}{1}", Menu.Description, Environment.NewLine);

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
            while (true)
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
        }

        public string GetLine(string command = "")
        {
            int cursorBaseLeft = Console.CursorLeft;
            int cursorBaseTop = Console.CursorTop;
            if (command != "")
                Console.Write(command);
            string input = Console.ReadLine();
            Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
            Console.Write(new string(' ', input.Length + command.Length));
            Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
            return input;
        }

        public Decimal GetDecimal(string command = "")
        {
            Decimal value = 0;
            while (true)
            {
                int cursorBaseLeft = Console.CursorLeft;
                int cursorBaseTop = Console.CursorTop;
                if (command != "")
                    Console.Write(command);
                string input = Console.ReadLine();
                Console.SetCursorPosition(cursorBaseLeft, cursorBaseTop);
                Console.Write(new string(' ', input.Length + command.Length));
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
