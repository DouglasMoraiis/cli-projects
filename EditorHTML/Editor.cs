using System;
using System.Text;

namespace EditorHTML
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("--------------------");
            Start();
        }
        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            HandleOptionSave(file.ToString());
        }

        public static void HandleOptionSave(string file)
        {
            Viewer.Show(file.ToString());
            Console.WriteLine("--------------------");
            Console.WriteLine("Deseja salvar o arquivo? (s/n)");
            char option = char.Parse(Console.ReadLine().ToLower());
            if (option == 's')
            {
                Save(file);
                Console.WriteLine("O arquivo foi salvo");
            }
            else if (option == 'n')
            {
                Console.WriteLine("O arquivo foi descartado!");
            }
            else
            {
                Console.WriteLine("Comando não reconhecido!");
                HandleOptionSave(file);
            }
            Thread.Sleep(2000);
            Menu.Show();
        }

        public static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine("Arquivo salvo!");
        }
    }
}