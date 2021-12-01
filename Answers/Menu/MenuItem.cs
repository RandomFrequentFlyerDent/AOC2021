namespace Answers.Menu
{
    internal class MenuItem
    {
        internal int Order { get; }
        internal string Title { get; }
        internal Action OnSelected { get; }

        internal MenuItem(int order, string title, Action onSelected)
        {
            Order = order;
            Title = title;
            OnSelected = onSelected;
        }
    }
}
