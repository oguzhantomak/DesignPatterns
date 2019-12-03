﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemManager manager = new SystemManager(new LoggerFactory1());
            manager.Save();
            Console.ReadKey();
        }
        public interface ILogger
        {
            void Log();
        }
        public class SystemLogger:ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged with SysytemLogger");
            }
        }

        public class DatabaseLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged with DatabaseLogger");
            }
        }

        public interface ILoggerFactory { ILogger CreateLogger(); }
        public class LoggerFactory1 : ILoggerFactory
        {
            public ILogger CreateLogger()
            {
                SystemLogger systemLogger = new SystemLogger();
                systemLogger.Log();
                return new SystemLogger();
            }
        }
        public class LoggerFactory2 : ILoggerFactory
        {
            public ILogger CreateLogger()
            {
                DatabaseLogger databaseLogger = new DatabaseLogger();
                databaseLogger.Log();
                return new DatabaseLogger();
            }
        }

        public class SystemManager
        {
            private ILoggerFactory _loggerFactory;
            public SystemManager(ILoggerFactory loggerFactory)
            {
                this._loggerFactory = loggerFactory;
            }
            public void Save()
            {
                Console.WriteLine("Saved...!!");
                ILogger logger = new LoggerFactory1().CreateLogger();
            }
        }
    }
}
