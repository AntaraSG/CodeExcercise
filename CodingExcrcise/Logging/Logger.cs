using NLog;
using System;
using System.Diagnostics;
using System.Reflection;
using NLogLogger = NLog.Logger;

namespace CodingExcrcise.Logging
{
    public sealed class Logger
    {
        #region Fields
        private readonly NLogLogger _nLoglogger;
        private readonly string _loggerClassName;
        #endregion

        private Logger()
        {
            _nLoglogger = LogManager.GetLogger("logToFile");
            _loggerClassName = (new StackTrace()).GetFrame(0).GetMethod().DeclaringType.FullName;
            
            LogStarting();
        }


        #region Singleton
        private static Logger _instance = null;
        public static Logger Instance
        {
            get
            {
                if (_instance == null) _instance = new Logger();
                return _instance;
            }
        }
        #endregion

        #region Properties
        public string LoggerName { get { return _nLoglogger.Name; } }
        #endregion

        #region Methods

        private void LogStarting()
        {
            LogMessage("++++++++++++++++++++++++++++++++++++++++++");

            LogMessage("[" + Process.GetCurrentProcess().ProcessName + "] process started");
        }
        private void LogStopping()
        {
            LogMessage("[" + Process.GetCurrentProcess().ProcessName + "] process stopped");
            LogMessage("------------------------------------------");
        }

        public void LogMessage(string message, MessageType messageType = MessageType.Info)
        {
            try
            {
                StackTrace stack = new StackTrace();
                foreach (StackFrame frame in stack.GetFrames())
                {
                    MethodBase method = frame.GetMethod();
                    string className = method.DeclaringType.FullName;
                    string methodName = method.Name;
                    if (className == _loggerClassName)
                    {
                        if (methodName == ".ctor" || methodName == "Dispose") break;
                    }
                    else
                    {
                        message = className + "." + method.Name + "| " + message;
                        break;
                    }
                }
            }
            catch
            {
            }

            switch (messageType)
            {
                case MessageType.Trace:
                    _nLoglogger.Trace(message);
                    break;
                case MessageType.Debug:
                    _nLoglogger.Debug(message);
                    break;
                case MessageType.Info:
                    _nLoglogger.Info(message);
                    break;
                case MessageType.Warn:
                    _nLoglogger.Warn(message);
                    break;
                case MessageType.Error:
                    _nLoglogger.Error(message);
                    break;
                case MessageType.Fatal:
                    _nLoglogger.Fatal(message);
                    break;
                case MessageType.Off:
                    // Don't log message
                    break;
                default:
                    LogException(new ArgumentException(
                        "Can't correctly log message because [" + messageType.ToString() + "] is unknown king of MessageType. Original message:" + Environment.NewLine + message, 
                        "MessageType"));
                    break;
            }
        }
        public void LogException(Exception exception)
        {
            LogMessage(exception.ToString(), MessageType.Error);
        }

        #endregion
    }
}
