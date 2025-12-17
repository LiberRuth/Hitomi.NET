using Hitomi.NET;

namespace ConsoleAppTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HitomiWebp hitomiWebp = new HitomiWebp();

            hitomiWebp.thread = 4;

            List<string> data = await hitomiWebp.HitomiImageList(1767027);

            foreach (string item in data) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
