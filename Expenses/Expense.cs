
namespace Expenses
{
    class Expense
    {
        public string Title;
        public double Amount;
        public string Date;
        public string Tag;
        public bool IsHidden;

        public Expense(string title, double amount, string date, string tag = "", bool isHidden = false)
        {
            Title = title;
            Amount = amount;
            Date = date;
            Tag = tag;
            IsHidden = isHidden;
        }
    }
}