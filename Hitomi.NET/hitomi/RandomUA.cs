using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitomi.NET
{
    public class RandomUA
    {
        static Random rnd = new Random();

        private static string[] UserAgentList = new string[] {
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko; Google Web Preview) Chrome/27.0.1453 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:30.0) Gecko/20100101 Firefox/30.0", 
            "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; MATBJS; rv:11.0) like Gecko",
            "Mozilla/5.0 (X11; CrOS x86_64 7077.95.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.90 Safari/537.36",
            "Mozilla/5.0 (Linux; Android 4.4.2; SM-T217S Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.84 Safari/537.36",
            "Mozilla/5.0 (X11; FreeBSD i386) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0 Safari/605.1.15 Epiphany/605.1.15",
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Brave/701.0.3626.121Safari/537.36",
            "Mozilla/5.0 (Linux; Android 6.0.1) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/95.0.4638.74 Mobile DuckDuckGo/35 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:108.0) Gecko/20100101 Firefox/108.0", 
            "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko EdgeClient/7222.2022.0715.1500",
            "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko EdgeClient/7232.2022.1019.0458",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Brave/107.0.5179.186 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Brave/107", 
            "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.17 (KHTML, like Gecko) BlueChrome/24.0.1312.52 Safari/537.17", 
            "Mozilla/18.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/533+ (KHTML, like Gecko) BlueChrome/8.2.4152.45 Safari/533+", 
            "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/533+ (KHTML, like Gecko) BlueChromeBrw/16.0.2245.10 Safari/537.17",
            "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko EdgeClient/7220.2022.0308.1349",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36", 
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:63.0) Gecko/20100101 Firefox/63.0", 
            "Mozilla/5.0 (X11; Linux x86_64; en-US) Gecko/20002614 Firefox/110.0", 
            "Mozilla/5.0 (Windows NT 11.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5548.224 Safari/537.36", 
            "Mozilla/5.0 (X11; Linux x86_64; en-US) Gecko/20161911 Firefox/113.0",
            "Mozilla/5.0 (Windows NT 11.0; WOW64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.5510.206 Safari/537.36 Edg/113.0.1511.47",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5526.209 Safari/537.36", 
            "Mozilla/5.0 (Windows NT 10.0; WOW64; x64; rv:116.0esr) Gecko/20000101 Firefox/116.0esr", 
            "Mozilla/5.0 (X11; U; Linux x86_64) Gecko/20010201 Firefox/113.0esr", 
            "Mozilla/5.0 (X11; U; Linux i686; rv:115.0esr) Gecko/20161404 Firefox/115.0esr", 
            "Mozilla/5.0 (Windows NT 10.0; WOW64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.5496.221 Safari/537.36 Edg/111.0.1545.36", 
            "Mozilla/5.0 (Windows NT 10.0; Win64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.5529.221 Safari/537.36", 
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5540.209 Safari/537.36 Edg/110.0.1573.59", 
            "Mozilla/5.0 (Windows NT 11.0; WOW64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.5511.211 Safari/537.36", 
            "Mozilla/5.0 (X11; U; Linux i686) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.5504.197 Safari/537.36"}; 

        public static string UserAgent() 
        {
            return UserAgentList[rnd.Next(0, UserAgentList.Length)];
        }
        
    }
}
