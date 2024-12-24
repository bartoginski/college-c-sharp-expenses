
namespace Expenses
{
    class Expense
    {
        public string Title;
        public double Amount;
        public string Date;
        public string Tag;

        public Expense(string title, double amount, string date = "", string tag = "")
        {
            Title = title;
            Amount = amount;
            Date = date != "" ? date : DateTime.Now.ToString("dd-MM-yyyy");
            Tag = tag;
        }
    }
}