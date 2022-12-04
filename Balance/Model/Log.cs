using System;
using System.Windows.Controls;

namespace Balance.Model
{
    sealed internal class Log
    {
        private static TextBlock _log;
        public Log(string warning)
        {
            Warning = warning;
        }
        public Log(string warning, DateTime date)
        {
            Warning = warning;
            Date = date;
        }
        public static void SetLogTextBlock(TextBlock text)
        {
            if (_log != null)
                throw new ArgumentException();

            _log = text;
        }
        public static string LogText
        {
            get { return _log.Text; }
            set { _log.Text = value; }
        }

        public string Warning { get; set; }
        public DateTime Date { get; set; }
        
        public void SendMessage()
        {
            string message = Date == DateTime.MinValue ? Warning : $"{Date}: {Warning}";
            LogText = message;
        }
        public static void SendMessage(string message)
        {
            LogText = message;
        }
    }
}
