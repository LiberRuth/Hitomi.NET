using System;
using System.Runtime.InteropServices;

namespace Hitomi.NET
{
    public class HitomiWebp
    {
        public int thread { get; set; } = 1;
        ImageRoute imageRoute = new ImageRoute();
        ImageRoute.GG gG = new ImageRoute.GG();

        private string? _path;
        public string path
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        _path = $@"C:\Users\{Environment.UserName}\Downloads";
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    }
                    else
                    {
                        _path = Directory.GetCurrentDirectory();
                    }
                }
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public async Task HitomiDownload(int number)
        {
            var lists = await imageRoute.List_Hash(number);
            string UA = RandomUA.UserAgent();

            List<Task> tasks = new List<Task>();
            SemaphoreSlim semaphore = new SemaphoreSlim(thread);

            foreach (var item in lists)
            {
                await semaphore.WaitAsync();

                var task = Task.Run(async () =>
                {
                    try
                    {
                        var Files = imageRoute.Image_Hash(item);
                        await gG.GgJS();
                        string urls = $"https://a.hitomi.la/webp/{await gG.B()}{Files}/{item}.webp";
                        var server_number = await imageRoute.SubdomainFromUrl(urls);
                        string str_server = server_number[0].ToString();
                        urls = urls.Insert(8, str_server);

                        using (HttpClient httpClient = new HttpClient())
                        {
                            httpClient.DefaultRequestHeaders.Add("User-Agent", UA);
                            httpClient.DefaultRequestHeaders.Referrer = new Uri($"https://hitomi.la/reader/{number}.html");
                            HttpResponseMessage response = await httpClient.GetAsync(urls);
                            response.EnsureSuccessStatusCode();
                            byte[] content = await response.Content.ReadAsByteArrayAsync();

                            string folderPath = $@"{_path}\{number}";
                            DirectoryInfo di = new DirectoryInfo(folderPath);
                            if (di.Exists == false)
                            {
                                di.Create();
                            }
                            File.WriteAllBytes($@"{_path}\{number}\{number}_p{lists.IndexOf(item)}.png", content);
                        }

                        Console.WriteLine(urls);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });

                tasks.Add(task);

                if (tasks.Count >= thread)
                {
                    await Task.WhenAny(tasks);
                    tasks.RemoveAll(x => x.IsCompleted);
                }
            }

            await Task.WhenAll(tasks);
        }

    }
}
