using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Table_maker
{
    static class Template
    {
        public static Dictionary<string, string> icons = new Dictionary<string, string>()
        {
            { "Yes", "🟢" }, // green circle
            { "Meh", "🟡" }, // yellow circle
            { "No", "🔴" } // red circle
        };

        public static string HTML = "";

        static Template ()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileName = "Table_maker.HTML.txt";
            if (assembly.GetManifestResourceStream(fileName) is Stream stream 
                && new StreamReader(stream) is StreamReader reader)
            {
                HTML = reader.ReadToEnd();
            }
        }
    }
}
