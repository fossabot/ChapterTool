﻿// ****************************************************************************
//Public Domain
// code from http://sourceforge.net/projects/gmkvextractgui/
// ****************************************************************************
using System;
using System.Text;

namespace ChapterTool.Util
{
    public delegate void LogLineAddedEventHandler(string lineAdded, DateTime actionDate);
    public class CTLogger
    {
        private static StringBuilder _Log = new StringBuilder();

        public static string LogText { get { return _Log.ToString(); } }

        public static event LogLineAddedEventHandler LogLineAdded;

        public static void Log(string message)
        {
            DateTime actionDate = DateTime.Now;
            string logMessage = string.Format("{0} {1}", actionDate.ToString("[yyyy-MM-dd][HH:mm:ss]"), message);
            _Log.AppendLine(logMessage);
            OnLogLineAdded(logMessage, actionDate);
        }

        protected static void OnLogLineAdded(string lineAdded, DateTime actionDate)
        {
            if (LogLineAdded != null)
            {
                LogLineAdded(lineAdded, actionDate);
            }
        }
    }
}