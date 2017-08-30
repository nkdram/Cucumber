
namespace Cucumber.Core.Infrastructure
{
    public class Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
    }
}