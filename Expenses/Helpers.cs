namespace Expenses
{
    static class Helpers
    {
        public static readonly List<string> MenuOptions =
        [
            "Stats",
            "Add new expenses",
            "Remove expenses",
            "Edit expenses",
            "Exit",
        ];

        public static int GetInteractiveMenu(List<string> options, string title = "", bool disableExit = false)
        {
            var selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(title);

                Console.WriteLine(disableExit
                    ? "(Navigate with up and down arrows, select with Enter)"
                    : "(Navigate with up and down arrows, select with Enter, Tab to return to the main menu)");

                for (var i = 0; i < options.Count; i++)
                {
                    var menuOption = options[i];
                    if (selectedOption == i)
                    {
                        Console.Write("> ");
                    }

                    Console.WriteLine(i + 1 + ". " + menuOption);
                }

                var userInteraction = Console.ReadKey().Key;

                switch (userInteraction)
                {
                    case ConsoleKey.DownArrow:
                        if (selectedOption < options.Count - 1) selectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedOption > 0) selectedOption--;
                        break;
                    case ConsoleKey.Enter:
                        return selectedOption;
                    case ConsoleKey.Tab when ! disableExit:
                        // Return -1 to indicate that the user wants to return to the main menu (should be handled by the caller)
                        return -1;
                }
            }
        }
    }
}