namespace Expenses
{
    public static class Program
    {
        static List<Expense> expenses = [];
        static String amountCurrency = "zl";

        public static void Main(string[] args)
        {
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Expenses");
                Console.WriteLine("Select an option (using arrows, enter to select):");

                for (var i = 0; i < Options.menuOptions.Count; i++)
                {
                    var menuOption = Options.menuOptions[i];
                    if (selectedOption == i)
                    {
                        Console.Write("> ");
                    }

                    Console.WriteLine(menuOption);
                }

                var userInteraction = Console.ReadKey().Key;

                switch (userInteraction)
                {
                    case ConsoleKey.DownArrow:
                        if (Options.menuOptions.Count - 1 > selectedOption) selectedOption++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedOption > 0) selectedOption--;
                        break;
                    case ConsoleKey.Enter:
                        HandleMenuSelection(selectedOption);
                        break;
                }
            }
        }
        
        private static void HandleMenuSelection(int selectedOption)
        {
            Console.Clear();

            switch (selectedOption)
            {
                case 0:
                    AddNewExpense();
                    break;
                case 1:
                    ShowStats();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        
        private static void AddNewExpense()
        {
            Console.WriteLine("Add new expense");
            
            Console.WriteLine("Enter the title:");
            var title  = Console.ReadLine() ?? "Unknown";
            
            Console.WriteLine($"Enter the amount: ({amountCurrency})");
            var amount = double.TryParse(Console.ReadLine(), out var result) ? result : 0;
            
            Console.WriteLine("Enter the category:");
            var category = Console.ReadLine() ?? "";
            
            Console.WriteLine("Enter the date:");
            var date = Console.ReadLine() ?? "";
            
            expenses.Add(new Expense(title, amount, category, date));
            
            Console.WriteLine("Expense added successfully");
            PressAnyKeyToContinue();
        }
        
        private static void ShowStats()
        {
            Console.WriteLine("Stats");
            Console.WriteLine("Total expenses: " + expenses.Count);
            Console.WriteLine("Total amount: " + expenses.Sum(expense => expense.Amount) + amountCurrency);

            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to show");
                PressAnyKeyToContinue();
                return;
            }
            
            Console.WriteLine("===== Full list of expenses =====");
            foreach (var expense in expenses)
            {

                Console.WriteLine(expense.Title + " - " + expense.Amount + " - " + expense.Date + " - " + expense.Tag);
            }
            
            PressAnyKeyToContinue();
        }
        
        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}