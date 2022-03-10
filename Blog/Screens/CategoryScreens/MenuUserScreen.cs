namespace Blog.Screens
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Category management");
            Console.WriteLine("-------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Category list");
            Console.WriteLine("2 - Register category");
            Console.WriteLine("3 - Update category");
            Console.WriteLine("4 - Remove category");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: ListCategorysScreen.Load(); break;
                case 2: CreateCategoryScreen.Load(); break;
                case 3: UpdateCategoryScreen.Load(); break;
                case 4: DeleteCategoryScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}