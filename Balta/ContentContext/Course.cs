using Balta.ContentContext.Enums;

namespace Balta.ContentContext
{
    public class Course : Content
    {
        public Course(string title, string url, EContentLevel level) : base(title, url)
        {
            Level = level;
            Modules = new List<Module>();
        }

        public string Tag { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
        public IList<Module> Modules { get; set; }
    }


}