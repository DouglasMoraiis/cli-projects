namespace Blog.Screens
{
    public static class MenuReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Reports");
            Console.WriteLine("-------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - List user/role");
            Console.WriteLine("2 - List categories/post count");
            Console.WriteLine("3 - List tags/post count");
            Console.WriteLine("4 - List posts (category)");
            Console.WriteLine("5 - List tags (category)");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: ListUserRoleScreen.Load(); break;
                case 2: ListCategoriesCountPostsScreen.Load(); break;
                case 3: ListTagsCountPostsScreen.Load(); break;
                case 4: ListPostsWithCategoryScreen.Load(); break;
                case 5: ListPostsWithTagsScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}