using System;
using Cucumber.Core.Base;
using log4net;
using System.Reflection;
using System.IO;
using log4net.Config;

namespace Cucumber.Service.Log
{
    public class Logger : ILogger
    {
        private static ILog logger;
        public bool IsInfoEnabled
        {
            get
            {
                return logger.IsInfoEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return logger.IsWarnEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return logger.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return logger.IsFatalEnabled;
            }
        }

        public Logger()
        {
            if (logger == null)
            {
                logger = GetLogger("CucumberApp.Logger", "CucumberApp_LogConfig.config");
            }
        }

        public static ILog GetLogger(string name, string configFileName)
        {
            ILog log = LogManager.Exists(Assembly.GetCallingAssembly(), name);
            if (log == null)
            {
                string localPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                string directoryName = Path.GetDirectoryName(localPath);
                if (!string.IsNullOrWhiteSpace(directoryName) && Directory.Exists(directoryName))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
                    if (directoryInfo.Exists && directoryInfo.Parent != null)
                    {
                        string fileName = Path.Combine(directoryInfo.Parent.FullName, "App_Config", configFileName);
                        FileInfo fileInfo = new FileInfo(fileName);
                        if (fileInfo.Exists)
                        {
                            XmlConfigurator.ConfigureAndWatch(fileInfo);
                        }
                    }
                }
                log = LogManager.GetLogger(Assembly.GetCallingAssembly(), name);
            }
            return log;
        }



        public void Info(object message)
        {
            logger.Info(message);
        }

        public void Info(object message, System.Exception exception)
        {
            logger.Info(message, exception);
        }


        public void Warn(object message)
        {
            logger.Warn(message);
        }

        public void Warn(object message, System.Exception exception)
        {
            logger.Warn(message, exception);
        }



        public void Error(object message)
        {
            logger.Error(message);
        }

        public void Error(object message, System.Exception exception)
        {
            logger.Error(message, exception);
        }


        public void Fatal(object message)
        {
            logger.Fatal(message);
        }

        public void Fatal(object message, System.Exception exception)
        {
            logger.Fatal(message, exception);
        }
    }
}
