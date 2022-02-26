using RainyManager.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RainyManager.Services
{
    public interface ILoggerService
    {
        void InitializeConsole(TextBlock textBox);
        void Write(string text);
        void WriteLine(string text);
    }

    public class LoggerService : ILoggerService
    {
        ConsoleWriter LocalConsole { get; set; }

        public void InitializeConsole(TextBlock textBox)
        {
            LocalConsole = new(textBox);
            Console.SetOut(LocalConsole);
            Console.WriteLine("App Initialized");
        }

        public void Write(string text) => LocalConsole.Write(text);
        public void WriteLine(string text) => LocalConsole.WriteLine(text);
    }

}
