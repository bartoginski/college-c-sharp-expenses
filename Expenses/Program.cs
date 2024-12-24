namespace Expenses
{
    public static class Program
    {
        private static List<Expense> _expenses =
        [
            new Expense("Groceries", 100, "24.12.2024", "Food"),
            new Expense("Power Bill", 623, "23.12.2024", "Bills"),
            new Expense("Xbox Game Pass", 67, "24.12.2024", "Entertainment"),
        ];

        private static string _amountCurrency = "zl";

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Expenses");

            // Main loop, we will keep showing the menu until the user decides to exit
            while (true)
            {
                int selectedOption = Helpers.GetInteractiveMenu(Helpers.MenuOptions, "Main menu");

                HandleMenuSelection(selectedOption);
            }
        }

        private static void HandleMenuSelection(int selectedOption)
        {
            Console.Clear();

            // user choice - 1 
            switch (selectedOption)
            {
                case -1:
                    break;
                case 0:
                    ShowStats();
                    break;
                case 1:
                    Console.WriteLine("Add new expense");
                    _expenses.Add(GetNewExpense());
                    break;
                case 2:
                    RemoveExpense();
                    break;
                case 3:
                    EditExpenseEntry();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        private static Expense GetNewExpense()
        {
            Console.WriteLine("Enter the title:");
            var title = Console.ReadLine()?.Trim() ?? "Unknown";

            Console.WriteLine($"Enter the amount: ({_amountCurrency})");
            var amount = double.TryParse(Console.ReadLine(), out var result) ? result : 0;

            Console.WriteLine("Enter the date (by default today date in format dd-MM-yyyy):");
            var date = Console.ReadLine()?.Trim() ?? "";
            
            Console.WriteLine("Enter the category:");
            var category = Console.ReadLine()?.Trim() ?? "Uncategorized";
            
            
            Console.WriteLine("Expense added successfully");
            PressAnyKeyToContinue();

            return new Expense(title, amount, date, category);
        }

        private static void ShowStats()
        {
            Console.WriteLine("Stats");
            Console.WriteLine("Total expenses: " + _expenses.Count);
            Console.WriteLine("Total amount: " + _expenses.Sum(expense => expense.Amount) + _amountCurrency);

            if (_expenses.Count == 0)
            {
                Console.WriteLine("No expenses to show");
                PressAnyKeyToContinue();
                return;
            }

            Console.WriteLine("===== Full list of expenses =====");
            foreach (var expense in _expenses)
            {
                string expenseSummary = "";

                if (expense.Title != "")
                {
                    expenseSummary += expense.Title;
                }

                expenseSummary += " - " + expense.Amount + _amountCurrency;
                
                if (expense.Date != "")
                {
                    expenseSummary += " - " + expense.Date;
                }
                
                if (expense.Tag != "")
                {
                    expenseSummary += " - " + expense.Tag;
                }

                Console.WriteLine(expenseSummary);
            }

            PressAnyKeyToContinue();
        }

        private static void RemoveExpense()
        {
            int indexOfExpense = Helpers.GetInteractiveMenu(_expenses
                .Select(expense => $"{expense.Title} - {expense.Amount}{_amountCurrency}").ToList(), "Select expense to remove");
            
            if (indexOfExpense == -1)
            {
                return;
            }
            
            Console.WriteLine($"Expense: {_expenses[indexOfExpense].Title} removed successfully");

            _expenses.RemoveAt(indexOfExpense);

            PressAnyKeyToContinue();
        }

        private static void EditExpenseEntry()
        {
            int indexOfExpense = Helpers.GetInteractiveMenu(_expenses
                .Select(expense => $"{expense.Title} - {expense.Amount}{_amountCurrency}").ToList(), "Select expense to edit");
            
            if (indexOfExpense == -1)
            {
                return;
            }
            
            Expense newExpense = GetNewExpense();
            _expenses[indexOfExpense] = newExpense;
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}