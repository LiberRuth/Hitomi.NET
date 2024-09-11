using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hitomi.NET
{
    public class HitomiWebp
    {
        public int thread { get; set; } = 1;
        public string? path { get; set; }

        ImageRoute imageRoute = new ImageRoute();
        ImageRoute.GG gG = new ImageRoute.GG();

        public async Task HitomiDownload(int number)
        {
            var mangaList = await imageRoute.List_Hash(number);
            string UA = RandomUA.UserAgent();

            List<Task> tasks = new List<Task>();
            SemaphoreSlim semaphore = new SemaphoreSlim(thread);

            foreach (var item in mangaList)
            {
                await semaphore.WaitAsync();

                var task = Task.Run(async () =>
                {
                    try
                    {
                        var Files = imageRoute.Image_Hash(item);
                        await gG.GgJS();
                        string mangaUrl = $"https://a.hitomi.la/webp/{await gG.B()}{Files}/{item}.webp";
                        var server_number = await imageRoute.SubdomainFromUrl(mangaUrl);
                        string str_server = server_number[0].ToString();
                        mangaUrl = mangaUrl.Insert(8, str_server);

                        using (HttpClient httpClient = new HttpClient())
                        {
                            httpClient.DefaultRequestHeaders.Add("User-Agent", UA);
                            httpClient.DefaultRequestHeaders.Referrer = new Uri($"https://hitomi.la/reader/{number}.html");
                            HttpResponseMessage response = await httpClient.GetAsync(mangaUrl);
                            response.EnsureSuccessStatusCode();
                            byte[] content = await response.Content.ReadAsByteArrayAsync();

                            string folderPath = $@"{path}/{number}";
                            DirectoryInfo di = new DirectoryInfo(folderPath);
                            if (di.Exists == false)
                            {
                                di.Create();
                            }
                            File.WriteAllBytes($@"{path}/{number}/{number}_p{mangaList.IndexOf(item)}.png", content);
                        }

                        Console.WriteLine(mangaUrl);
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

        public async Task<List<string>> HitomiImageList(int number)
        {
            var mangaListReply = new List<string>();
            var mangaList = await imageRoute.List_Hash(number);

            List<Task> tasks = new List<Task>();
            SemaphoreSlim semaphore = new SemaphoreSlim(thread);

            foreach (var item in mangaList)
            {
                var Files = imageRoute.Image_Hash(item);
                await gG.GgJS();
                string mangaUrl = $"https://a.hitomi.la/webp/{await gG.B()}{Files}/{item}.webp";
                string server_number = await imageRoute.SubdomainFromUrl(mangaUrl);
                string str_server = server_number[0].ToString();
                mangaListReply.Add(mangaUrl.Insert(8, str_server));

            }
            
            return mangaListReply;
        }

        public async Task<List<string>> HitomiImageSingleList(int number) 
        {
            var mangaListReply = new List<string>();
            var mangaList = await imageRoute.List_Hash(number);

            List<Task> tasks = new List<Task>();
            SemaphoreSlim semaphore = new SemaphoreSlim(thread);

            await gG.GgJS();

            foreach (var item in mangaList)
            {
                var Files = imageRoute.Image_Hash(item);
                string mangaUrl = $"https://a.hitomi.la/webp/{await gG.B()}{Files}/{item}.webp";
                string server_number = await imageRoute.SubdomainFromUrl(mangaUrl);
                string str_server = server_number[0].ToString();
                mangaListReply.Add(mangaUrl.Insert(8, str_server));

            }

            return mangaListReply;
        }
    }
}
