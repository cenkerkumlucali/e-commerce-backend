using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Repository;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository,xmlDocument["log4net"]);
            _log = LogManager.GetLogger(loggerRepository.Name,name);
        }

        public bool isInfoEnabled => _log.IsInfoEnabled;
        public bool isDebugEnabled => _log.IsDebugEnabled;
        public bool isWarnEnabled => _log.IsWarnEnabled;
        public bool isFatalEnabled => _log.IsFatalEnabled;
        public bool isErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if(isInfoEnabled)
            _log.Info(logMessage);
        }
        public void Debug(object logMessage)
        {
            if (isDebugEnabled)
                _log.Info(logMessage);
        }
        public void Warn(object logMessage)
        {
            if (isWarnEnabled)
                _log.Info(logMessage);
        }
        public void Fatal(object logMessage)
        {
            if (isFatalEnabled)
                _log.Info(logMessage);
        }
        public void Error(object logMessage)
        {
            if (isErrorEnabled)
                _log.Info(logMessage);
        }
    }
}