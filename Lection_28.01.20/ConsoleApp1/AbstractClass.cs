using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class BaseLogger
    {
        private readonly string _userLogin;
        public BaseLogger(string userLogin)
        {
            _userLogin = userLogin;
        }

        public void Info(string massage) => WriteLogMessage(massage);
        public void Warm(string massage)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteLogMessage(massage);
            Console.ResetColor();
        }
        public void Error(string massage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WriteLogMessage(massage);
            Console.ResetColor();
        }

        protected abstract void LogMessage(string massage);
        protected abstract string GetMetadata();

        private void WriteLogMessage(string massage)
        {
            string meta = string.Join(";", _userLogin, GetMetadata());
            string composedMessage = $"[{meta}]:{massage}";
            LogMessage(composedMessage);
        }
    }

    public class ConsoleLogger : BaseLogger
    {
        private readonly string _ipAddress;

        public ConsoleLogger(string ipAddress, string userLogin)
            :base(userLogin)
        {
            _ipAddress = ipAddress;
        }

        protected override string GetMetadata()
        {
            return _ipAddress;
        }

        protected override void LogMessage(string massage)
        {
            Console.WriteLine(massage);
        }
    }

    public class IpDemo
    {
        internal protected void Method ()
        {
        }
    }

    public class PpDemo
    {
        private protected void Method()
        {
        }
    }

    public class PpDemoChild : PpDemo
    {
        public PpDemoChild()
        {
            this.Method();
        }
    }

    public class TimetampLogger : ConsoleLogger
    {
        public TimetampLogger(string ipAddress, string userLogin) : base(ipAddress, userLogin)
        {
        }

        protected override string GetMetadata()
        {
            return String.Join (" ; ", DateTime.UtcNow.ToString("o"), base.GetMetadata());
        }
    }

    class AbstractClass
    {
        public static void ShowDemo()
        {
            //var ip = new IpDemo();
            //ip.Method();

            //var pp = new PpDemo();
            var logger = new TimetampLogger("UserName", "127.0.0.1");
            logger.Info("Text");
            logger.Warm("So so");
            logger.Error("Error");
        }
    }
}
