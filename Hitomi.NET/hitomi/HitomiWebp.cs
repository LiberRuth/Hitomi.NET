using System;

namespace Hitomi.NET
{
    public class HitomiWebp
    {
        ImageRoute imageRoute = new ImageRoute();
        ImageRoute.GG GG = new ImageRoute.GG();

        public async Task<List<string>> HitomiImageList(int number) 
        {
            var mangaListReply = new List<string>();
            var mangaList = await imageRoute.List_Hash(number);

            await GG.GgJS();

            foreach (var item in mangaList)
            {
                var Files = imageRoute.Image_Hash(item);
                string mangaUrl = $"https://w.gold-usergeneratedcontent.net/{await GG.B()}{Files}/{item}.webp";
                string server_number = await imageRoute.SubdomainFromUrl(mangaUrl);
                string str_server = server_number[0].ToString();

                if (str_server == "a") str_server = "1";
                if (str_server == "b") str_server = "2";

                mangaListReply.Add(mangaUrl.Insert(9, str_server));

            }

            return mangaListReply;
        }
    }
}
