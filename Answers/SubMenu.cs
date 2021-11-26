namespace Answers
{
    internal class SubMenu
    {
        internal static void Show(string answer)
        {
            var menuItems = GetMenuItems();
            int index = 0;
            WriteMenu(menuItems, menuItems[index], answer);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < menuItems.Count)
                    {
                        index++;
                        WriteMenu(menuItems, menuItems[index], answer);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(menuItems, menuItems[index], answer);
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

        private static List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem(0, "Main menu", () => MainMenu.Show()),
                new MenuItem(0, "Exit", () => Environment.Exit(0))
            };
        }

        private static void WriteMenu(List<MenuItem> menuItems, MenuItem selected, string answer)
        {
            Console.Clear();

            Console.WriteLine($"Answer: {answer}\n");

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
    }
}
