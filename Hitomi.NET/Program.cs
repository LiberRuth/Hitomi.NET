using System;

namespace Hitomi.NET
{
    internal class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HitomiWebp.threads = 4;
            //HitomiWebp.dir = $@"C:\Users\{Environment.UserName}\Downloads\filestest";

            await HitomiWebp.HitomiDownload(1767019);
        }
    }
}