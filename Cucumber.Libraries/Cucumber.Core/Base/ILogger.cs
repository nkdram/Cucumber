

namespace Cucumber.Core.Base
{
    public interface ILogger
    {

        bool IsInfoEnabled
        {
            get;
        }

        bool IsWarnEnabled
        {
            get;
        }

        bool IsErrorEnabled
        {
            get;
        }

        bool IsFatalEnabled
        {
            get;
        }

        void Info(object message);

        void Info(object message, System.Exception exception);

        void Warn(object message);

        void Warn(object message, System.Exception exception);

        void Error(object message);

        void Error(object message, System.Exception exception);

        void Fatal(object message);

        void Fatal(object message, System.Exception exception);

    }
}
