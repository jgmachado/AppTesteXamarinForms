using Android.Util;
using AppTeste.Core.Helpers;

namespace AppTeste.Droid.Helpers
{
    public class LogPlataform : ILogPlataform
    {
        public void Log2Plataform(string header, string message)
        {
            message = string.Format("{0} :=> {1}", header, message);
            Log.WriteLine(LogPriority.Debug, "App Teste", message);
        }
    }
}