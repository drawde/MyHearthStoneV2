using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Configuration;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common
{
    public class Log
    {
        private static Log _defaultLog = new Log();
        public static Log Default
        {
            get
            {
                return _defaultLog;
            }
        }
        public enum LogType
        {
            Error = 1,
            Debug = 2,
            Info = 3,
            TaoWaiMai = 4
        }
        public void addLog(string method, string kind, string msg, LogType logType)
        {
            string localPath = "";
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "log/" + logType.ToString() + "/";
            localPath = string.Format(logPath + "{0:yyyyMMdd}.log", DateTime.Now);
            lock (localPath)
            {
                StreamWriter writer = null;
                try
                {
                    System.IO.FileInfo info = new FileInfo(localPath);
                    if (!info.Directory.Exists)
                        info.Directory.Create();

                    writer = new StreamWriter(localPath, true, System.Text.Encoding.UTF8);
                    writer.WriteLine(string.Format("{0}[{1:HH:mm:ss}] 方法{2} 用户：{3}[end]", kind, DateTime.Now, method, msg));
                }
                catch
                {
                    if (writer != null)
                        writer.Close();
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }


        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="e"></param>
        public void Error(System.Exception e, string methodName)
        {
            addLog(methodName, "堆栈", e.StackTrace, LogType.Error);
            addLog(methodName, "错误", e.ToString(), LogType.Error);
        }

        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="msg"></param>
        public void Error(string methodName, string msg)
        {
            addLog(methodName, "错误", msg, LogType.Error);
        }
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="msg"></param>
        public void Error(string msg)
        {
            addLog("", "错误", msg, LogType.Error);
        }

        public void Error(Exception ex)
        {
            Error(ex, "");
        }

        public void Info(System.Exception e, string methodName)
        {
            addLog(methodName, "堆栈", e.StackTrace, LogType.Info);
            addLog(methodName, "错误", e.ToString(), LogType.Info);
        }

        public void Info(Exception message)
        {
            Info(message, "");
        }
        public void Info(string message)
        {
            addLog("", "Info", message, LogType.Info);
        }

        /// <summary>
        /// 添加Debug日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="e"></param>
        public void Debug(System.Exception e, string methodName)
        {
            addLog(methodName, "堆栈", e.StackTrace, LogType.Debug);
            addLog(methodName, "错误", e.ToString(), LogType.Debug);
        }

        /// <summary>
        /// 添加Debug日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="msg"></param>
        public void Debug(string methodName, string msg)
        {
            addLog(methodName, "错误", msg, LogType.Debug);
        }
        /// <summary>
        /// 添加Debug日志
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="msg"></param>
        public void Debug(string msg)
        {
            addLog("", "错误", msg, LogType.Debug);
        }
        public void TaoWaiMai(string msg)
        {
            addLog("", "错误", msg, LogType.TaoWaiMai);
        }

        public void Debug(Exception ex)
        {
            Debug(ex, "");
        }


        //public void Info(object message, Exception exception)
        //{
        //    Error(exception, message.ToString());
        //}

        //public void Info(object message, params object[] args)
        //{
        //    Info(string.Format(message.ToString(), args));
        //}

        private void LogInfo()
        {
            if (HttpContext.Current != null)
            {
                Info(string.Format(@"当前请求页:{0}", HttpContext.Current.Request.Url.AbsoluteUri));
                Info(string.Format(@"请求IP来源:{0}", HttpContext.Current.Request.UserHostAddress));
            }
        }

        public void WebPageInfo()
        {
            if (HttpContext.Current != null)
            {
                Info("当前请求IP:" + HttpContext.Current.Request.UserHostAddress);
                Info("当前请求页:" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }
    }
}
