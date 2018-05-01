using System;
using AppTeste.Core.Helpers;

namespace AppTeste.iOS.Helpers
{
    public class LogPlataform : ILogPlataform
    {
        public void Log2Plataform(string header, string message)
        {
            message = string.Format("{0}::{1} => {2}", "App Teste", header, message);
            Console.WriteLine(message);
        }
    }
}
