using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAutomation.Util
{
    public enum LogType
    {
        DEBUG, ERROR, FATAL, INFO, WARN
    }

    public static class Logger
    {
        // path of the log file
        private static string PATH = @"C:\AutoSwipe\application.log";

        // format:
        // [date time] logType : [user][machineName] [class >> method()] - message
        private static string FORMAT = "[{1}][{0}] [{2}]:  [{3}][{4} >> {5}()] - \"{6}\"";

        /// <summary>
        /// Formats the message based on the static format
        /// </summary>
        /// <param name="method"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string GetMessage(MethodBase method, string message, LogType logType)
        {
            return string.Format(FORMAT,
                DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                logType,
                "Paul Barcoma",
                // FrmMdiMain.userName,
                Environment.MachineName,
                method.DeclaringType.Name,
                method.Name,
                message);
        }

        /// <summary>
        /// Logs the message to the file
        /// </summary>
        /// <param name="message"></param>
        private static void Log(string message)
        {
            try
            {
                // if file does not exist
                // create the file
                // otherwise, append to file
                if (!System.IO.File.Exists(PATH))
                {
                    using (System.IO.StreamWriter writer = System.IO.File.CreateText(PATH))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
                }
                else
                {
                    using (System.IO.StreamWriter writer = System.IO.File.AppendText(PATH))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
                }
            }
            catch
            {
                // do nothing if exception occurred
                return;
            }
        }

        /// <summary>
        /// Writes a log message with INFO level
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message, MethodBase method = null)
        {
            if (null == method)
            {
                method = new StackTrace().GetFrame(1).GetMethod();
            }
            Log(GetMessage(method, message, LogType.INFO));
        }

        /// <summary>
        /// Writes a log message with WARN level
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message, MethodBase method = null)
        {
            if (null == method)
            {
                method = new StackTrace().GetFrame(1).GetMethod();
            }
            Log(GetMessage(method, message, LogType.WARN));
        }

        /// <summary>
        /// Writes a log message with ERROR level
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message, MethodBase method = null)
        {
            if (null == method)
            {
                method = new StackTrace().GetFrame(1).GetMethod();
            }
            Log(GetMessage(method, message, LogType.ERROR));
        }
    }
}