using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Hitomi.NET
{
    public class HitomiWebp
    {
        public static int threads { get; set; } = 1;

        //public static string dir { get; set; } = $@"C:\Users\{Environment.UserName}\Downloads";
       
        public static string dir {
            get {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    return $@"C:\Users\{Environment.UserName}\Downloads";
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                } else {
                    return Directory.GetCurrentDirectory();
                }
            }
            set { 
            }          
        }
        
        

        public static async Task HitomiDownload(int number)
        {
            var lists = await ImageRoute.List_Hash(number);
            string UA = RandomUA.UserAgent();

            List<Task> tasks = new List<Task>();
            SemaphoreSlim semaphore = new SemaphoreSlim(threads);

            foreach (var item in lists)
            {
                await semaphore.WaitAsync();

                var task = Task.Run(async () =>
                {
                    try
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
                            httpClient.DefaultRequestHeaders.Referrer = new Uri($"https://hitomi.la/reader/{number}.html");
                            HttpResponseMessage response = await httpClient.GetAsync(urls);
                            response.EnsureSuccessStatusCode();
                            byte[] content = await response.Content.ReadAsByteArrayAsync();

                            string folderPath = $@"{dir}\{number}";
                            DirectoryInfo di = new DirectoryInfo(folderPath);
                            if (di.Exists == false)
                            {
                                di.Create();
                            }
                            File.WriteAllBytes($@"{dir}\{number}\{number}-{lists.IndexOf(item)}.png", content);
                        }

                        Console.WriteLine(urls);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });

                tasks.Add(task);

                if (tasks.Count >= threads)
                {
                    await Task.WhenAny(tasks);
                    tasks.RemoveAll(x => x.IsCompleted);
                }
            }

            await Task.WhenAll(tasks);
        }

    }
}
