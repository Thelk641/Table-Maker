using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Xml;
using Newtonsoft.Json;

namespace Table_maker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Game> gameList = ParseRawData(args[0]);

            File.WriteAllText(args[1], ParseHTML(gameList));
        }

        static private List<Game> ParseRawData(string path)
        {
            string toParse = File.ReadAllText(path);

            List<Game> gameList = new List<Game>();

            foreach (var item in toParse.Split("\n"))
            {
                Game toAdd = new Game();
                string[] cut = item.Split("/");
                toAdd.name = cut[0].Trim();
                toAdd.implemented = cut[1].Trim();
                toAdd.url = cut[2].Trim();
                toAdd.comment = cut[3].Trim().TrimEnd('\r');

                gameList.Add(toAdd);
            }

            return gameList;
        }

        static private string ParseHTML(List<Game> toParse)
        {
            string output = Template.HTML;

            foreach (var item in toParse)
            {
                output += "<tr>\n";
                output += "<td>" + item.name + "</td>\n";
                output += "<td>" + Template.icons[item.implemented] + "</td>\n";
                output += "<td>" + "<a href = \"" + item.url + "\" >Link</a>" + "</td>\n";
                output += "<td>" + item.comment + "</td>\n";
                output += "</tr>\n";
            }

            output += "</table>\n</body>\r\n</html>";
            return output;
        }
    }
}