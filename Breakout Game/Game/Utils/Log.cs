using System;
using System.Drawing;

namespace Breakout_Game.Game.Utils{
    public enum LogType{
        Info, Error, Warn, Success
    }
    
    public static class Log{

        private static readonly ConsoleColor INFOCOLOR = ConsoleColor.White;
        private static readonly ConsoleColor ERRORCOLOR = ConsoleColor.DarkRed;
        private static readonly ConsoleColor WARNCOLOR = ConsoleColor.Yellow;
        private static readonly ConsoleColor SUCCESSCOLOR = ConsoleColor.Green;
        

        private static DateTime DateTime;
        
        public static void Send(string name, string value, LogType type){
            DateTime = DateTime.Now;

            Console.ForegroundColor = type switch {
                LogType.Info => INFOCOLOR,
                LogType.Error => ERRORCOLOR,
                LogType.Warn => WARNCOLOR,
                LogType.Success => SUCCESSCOLOR,
                _ => INFOCOLOR
            };
            
            Console.WriteLine("[" + DateTime.ToString("H:mm:ss") + "]" + "[" + type + "]" + "[" + name + "]" + " : " + value);
        }
    }
}