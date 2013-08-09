using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace FeedzillaConsumer
{
    internal class FeedzillaConsumer
    {
        static async void PrintArticles(HttpClient httpClient, string queryString)
        {
            var response = await httpClient.GetAsync(string.Format("v1/articles/search.json?q={0}", queryString));

            var articlesFound = response.Content.ReadAsStringAsync().Result;

            var data = JsonConvert.DeserializeObject<ArticlesCollection>(articlesFound);
            
            Console.WriteLine();

            foreach (var article in data.Articles)
            {
                var newsArticle = JsonConvert.DeserializeObject<NewsArticle>(article.ToString());
                Console.WriteLine(
                    "Title:\n{0}\nUrl:\n{1}\n",
                    newsArticle.Title,
                    newsArticle.Url);
            }
        }

        private static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/");

            Console.WriteLine("Query String: ");
            string queryString = Console.ReadLine();

            PrintArticles(httpClient, queryString);
            Console.ReadLine();
        }
    }
}
