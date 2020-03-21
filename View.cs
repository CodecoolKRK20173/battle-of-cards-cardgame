using System;

namespace battle_of_cards_cardgame
{
    class View
    {
       public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public static void DisplayLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayLine()
        {
            Console.WriteLine();
        }

        public static void WaitForEnter()
        {
            Console.WriteLine(" (press Enter to continue)");
            Console.ReadLine();
        }

        public static string WaitForString()
        {
            return Console.ReadLine();
        }

        public static string WaitForString(string message)
        {
            System.Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}