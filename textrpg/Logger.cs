using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Logger
    {  
        private enum Mode : byte
        {
            common, warning, error, fatal
        }
        static private string[] prefixes = { "LOG", "WARNING", "ERROR", "FATAL" };
        static private ConsoleColor[] colors = { ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.DarkRed};
        private static void WriteLog(object data, Mode mode)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = colors[(byte)mode];
            Console.WriteLine($"[{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}] [{prefixes[(byte)mode]}] {data}");
            Console.ForegroundColor = c;
        }
        public static void Log(object message)
            => WriteLog(message, Mode.common);
        public static void LogWarning(object message)
            => WriteLog(message, Mode.warning);
        public static void LogError(object message)
            => WriteLog(message, Mode.error);
        public static void LogFatal(object message)
            => WriteLog(message, Mode.fatal);
    }
}
