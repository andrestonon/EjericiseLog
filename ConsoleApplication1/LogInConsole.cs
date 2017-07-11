using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    public class LogInConsole : ILogIn
    {


        public void LogMessage(string message, TypeLog type)
        {
          
                Console.ForegroundColor = GetColor(type);
                Console.WriteLine(DateTime.Now.ToShortDateString().Replace("/", "-") + message);
                Console.Read();
       
        }

        private ConsoleColor GetColor(TypeLog type)
        {
            switch (type)
            {
                case TypeLog.Message:
                    return ConsoleColor.White;
                case TypeLog.Warning:
                    return ConsoleColor.Yellow;
                case TypeLog.Error:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Black;
            }

        }


    }
}
