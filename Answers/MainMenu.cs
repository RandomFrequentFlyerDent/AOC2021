namespace Answers
{
    internal class MainMenu
    {
        internal static void Show()
        {
            var menuItems = GetMenuItems();
            int index = 0;
            WriteMenu(menuItems, menuItems[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < menuItems.Count)
                    {
                        index++;
                        WriteMenu(menuItems, menuItems[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(menuItems, menuItems[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    menuItems[index].OnSelected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }

        private static void WriteMenu(List<MenuItem> menuItems, MenuItem selected)
        {
            Console.Clear();

            foreach (MenuItem menuItem in menuItems)
            {
                if (menuItem == selected)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(menuItem.Title);
            }
        }

        private static List<MenuItem> GetMenuItems()
        {
            var answerTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(t => t.GetInterfaces()
            .Contains(typeof(IAnswer)))
            .ToList();

            var menuItems = new List<MenuItem>();
            answerTypes.ForEach(t =>
            {
                if (Activator.CreateInstance(t) is IAnswer instance)
                    menuItems.Add(new MenuItem(instance.GetOrder(), instance.GetTitle(), () => SubMenu.Show(instance.Get())));
            });
            menuItems.Add(new MenuItem(-1, "Exit", () => Environment.Exit(0)));
            return menuItems.OrderByDescending(m => m.Order).ToList();
        }
    }
}
