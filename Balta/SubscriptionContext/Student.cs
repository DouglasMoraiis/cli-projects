using Balta.NotificationContext;
using Balta.SharedContext;

namespace Balta.SubstringContext
{
    public class Student : Base
    {
        public Student()
        {
            Subscriptions = new List<Subscription>();
        }

        public User User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);
        public IList<Subscription> Subscriptions { get; set; }

        public void CreateSubscription(Subscription subscription)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "O aluno já é usuário premium!"));
                return;
            }
            else
            {
                Subscriptions.Add(subscription);
            }
        }
    }
}