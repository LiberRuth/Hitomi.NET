using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitomi.NET
{
    internal class HitomiWebp
    {
        public static int threads { get; set; } = 1;


        public static async Task HitomiDownload(int number) 
        {
            int i = 1;
            List<Task> tasks = new List<Task>();
            List<string> downloadedFiles = new List<string>();

            var lists = await ImageRoute.List_Hash(number);
            string UA = RandomUA.UserAgent();

            foreach (var item in lists)
            {
                tasks.Add(Task.Run(async () =>
                {

                    var Files = ImageRoute.Image_Hash(item);
                    await ImageRoute.GG.GgJS();
                    string urls = $"https://a.hitomi.la/webp/{await ImageRoute.GG.B()}{Files}/{item}.webp";
                    var server_number = await ImageRoute.SubdomainFromUrl(urls);
                    string str_server = server_number[0].ToString();
                    urls = urls.Insert(8, str_server);

                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Add("User-Agent", UA);
                        httpClient.DefaultRequestHeaders.Referrer = new Uri("https://hitomi.la/");
                        HttpResponseMessage response = await httpClient.GetAsync(urls);
                        response.EnsureSuccessStatusCode();
                        byte[] content = await response.Content.ReadAsByteArrayAsync();

                        string folderPath = $@"C:\Users\{Environment.UserName}\Downloads\{number}";
                        DirectoryInfo di = new DirectoryInfo(folderPath);
                        if (di.Exists == false)
                        {
                            di.Create();
                        }
                        System.IO.File.WriteAllBytes($@"C:\Users\{Environment.UserName}\Downloads\{number}\{number}-{i++}.png", content);
                    }

                    Console.WriteLine(urls);
                    //Thread.Sleep(500);
                }));

                if (tasks.Count >= threads) 
                {
                    await Task.WhenAll(tasks);
                    tasks.Clear();
                }
            }

            await Task.WhenAll(tasks); 
        } 
    }
}
