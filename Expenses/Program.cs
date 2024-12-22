using Spectre.Console;

namespace Expenses
{

    public static class Program
    {

        static List<Expense> expenses = [];

        public static void Main(string[] args)
        {
            var selectedMenuOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What do you need?")
                .PageSize(10)
                .MoreChoicesText("[grey](Navigate with arrows)[/]")
                .AddChoices(Options.menuOptions)
            );
        }
    }
}
