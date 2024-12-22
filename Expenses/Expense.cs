
namespace Expenses
{
    class Expense
    {
        string Title;
        string Description;
        string Tag;
        bool IsHidden;


        public Expense(string title, string description, string tag, bool isHidden)
        {
            Title = title;
            Description = description;
            Tag = tag;
            IsHidden = isHidden;
        }
    }
}