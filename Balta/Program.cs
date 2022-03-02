using Balta.ContentContext;
using Balta.ContentContext.Enums;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var articles = new List<Article>();
            articles.Add(new Article("Artigo Sobre POO", "progracao-orientacao-objetos"));
            articles.Add(new Article("Artigo Sobre C#", "csharp"));
            articles.Add(new Article("Artigo Sobre .NET", "dotnet"));

            var courses = new List<Course>();

            var courseOOP = new Course("Fundamentos de POO", "fundamentos-poo", EContentLevel.Beginner);
            var courseCsharp = new Course("Fundamentos de C#", "fundamentos-csharp", EContentLevel.Fundamental);
            var courseDotnet = new Course("Fundamentos de .NET", "fundamentos-dotnet", EContentLevel.Intermediary);
            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseDotnet);

            var careers = new List<Career>();
            var careerDotnet = new Career("Especialista .NET", "especialista-dotnet");
            var careerItem2 = new CareerItem(2, "Segundo Nível", "", courseCsharp);
            var careerItem1 = new CareerItem(1, "Comece por aqui", "", courseOOP);
            var careerItem3 = new CareerItem(3, "Terceiro Nivel", "", courseDotnet);
            careerDotnet.Items.Add(careerItem2);
            careerDotnet.Items.Add(careerItem3);
            careerDotnet.Items.Add(careerItem1);
            careers.Add(careerDotnet);

            foreach (var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach (var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course.Level);
                }
            }
        }
    }
}