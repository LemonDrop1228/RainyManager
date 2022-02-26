using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RainyManager.Misc
{
    public class ConsoleWriter : TextWriter
    {        
        private TextBlock consoleTB;
        public ConsoleWriter(TextBlock richTextBox)
        {
            this.consoleTB = richTextBox;
        }

        public override void Write(char value)
        {
            consoleTB.Text += value;
        }

        public override void Write(string value)
        {
            consoleTB.Dispatcher.BeginInvoke((Action)(() => {
                var sourceContent = consoleTB.Text;
                string[] collection = sourceContent.Split(new string[] { Environment.NewLine },
                           StringSplitOptions.None);
                var contentSplit = collection.ToList();
                contentSplit[contentSplit.FindIndex(n => n == contentSplit.Last())] = $"{DateTime.Now.ToString("MM.dd.yyyy-hh:mm:ss")} | <Log>: {value}";
                var contentUpdated = String.Join(Environment.NewLine, contentSplit);
                consoleTB.Text = contentUpdated;

            }));
        }

        public override void WriteLine(string value)
        {
            consoleTB.Dispatcher.BeginInvoke((Action)(() => {
                if (!consoleTB.Text.NullOrEmpty())
                    consoleTB.Text += Environment.NewLine;
                consoleTB.Text += $"{DateTime.Now.ToString("MM.dd.yyyy-hh:mm:ss")} | <Log>: {value}";
            }));
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
