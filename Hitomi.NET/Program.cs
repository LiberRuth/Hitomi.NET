using System;

namespace Hitomi.NET
{
    internal class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await HitomiWebp.HitomiDownload(1767019);
        }
    }
}