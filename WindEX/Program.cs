using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindEX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                var html = client.GetStringAsync("https://pastebin.com/raw/H7z9VcrA").Result;
                var lines = html.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    var key = line.Split('\t')[1];
                    System.Diagnostics.Process.Start("cmd.exe", "/c slmgr /ipk " + key);
                }
            }
        }
    }
}
