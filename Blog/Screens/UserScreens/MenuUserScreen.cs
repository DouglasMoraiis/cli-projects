namespace Blog.Screens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("User management");
            Console.WriteLine("-------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - User list");
            Console.WriteLine("2 - Register user");
            Console.WriteLine("3 - Update user");
            Console.WriteLine("4 - Remove user");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: ListUsersScreen.Load(); break;
                case 2: CreateUserScreen.Load(); break;
                case 3: UpdateUserScreen.Load(); break;
                case 4: DeleteUserScreen.Load(); break;
                default: Load(); break;
            }
        }
    }
}