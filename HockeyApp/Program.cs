using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Text;

namespace HockeyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            startCrawlerasync();
            Console.ReadLine();

        }

        private static async Task startCrawlerasync()   
        {
            var url = "https://www.difhockey.se/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var dates = new List<Game>();

            var divs =
                htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("rmss_c-header-games__day")).ToList();
            foreach(var div in divs)
            {
                var game = new Game
                {
                    WeekDay = div.Descendants("span").FirstOrDefault().Descendants("span").FirstOrDefault().InnerText,
                    Day = div.Descendants("span").FirstOrDefault().InnerText,
                    Month = div.Descendants("span").FirstOrDefault().Descendants("span").FirstOrDefault().InnerText
                };
                dates.Add(game);
            }
        }
    }
}
