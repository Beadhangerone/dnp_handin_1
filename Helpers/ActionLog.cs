using System;

namespace h1.Helpers
{
    public class ActionLog
    {
        public static void Log(string log)
        {
            Console.WriteLine($"[{DateTime.Now}] {log}");
        }
    }
}