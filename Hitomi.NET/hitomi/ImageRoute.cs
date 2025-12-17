using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Jint;
using Jint.Native;
using Jint.Native.Object;
using Jint.Native.Function;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hitomi.NET
{
    public class ImageRoute
    {
        public string Image_Hash(string h)
        {
            Match match = Regex.Match(h, @"(..)(.)$");
            int n = int.Parse(match.Groups[2].Value + match.Groups[1].Value, NumberStyles.HexNumber);
            return n.ToString();
        }

        public class GG
        {
            private static string? GGtext;

            public async Task GgJS()
            {
                HttpClient httpclient = new HttpClient();
                //HttpResponseMessage response = await httpclient.GetAsync("https://dotnet.microsoft.com/ko-kr/");
                HttpResponseMessage response = await httpclient.GetAsync("https://ltn.hitomi.la/gg.js");
                response.EnsureSuccessStatusCode();
                //HttpStatusCode status = response.StatusCode; //HTTP 200 이면 OK
                var script = "var gg = {}; ";
                script += await response.Content.ReadAsStringAsync();
                GGtext = script;
            }

            public async Task<string> B()
            {
                //var options = new Jint.Options().Strict();
                //var engine = new Engine(options);
                var engine = new Engine();
                var result = engine.Evaluate(GGtext!);
                var ggjs = result.AsObject();
                engine.Evaluate(GGtext!);
                return engine.Evaluate("gg.b").ToString();
            }

            public async Task<int> M(int m)
            {
                //var options = new Jint.Options().Strict();
                //var engine = new Engine(options);
                var engine = new Engine();
                engine.Execute(GGtext!);
                var result = engine.Evaluate($"gg.m({m})");
                return Convert.ToInt32(result.ToObject());
            }

        }

        public async Task<string> SubdomainFromUrl(string url, string baseValue = null!)
        {
            string retval = "b";
            if (!string.IsNullOrEmpty(baseValue))
            {
                retval = baseValue;
            }

            int b = 16;

            Regex r = new Regex(@"\/[0-9a-f]{61}([0-9a-f]{2})([0-9a-f])");
            Match m = r.Match(url);
            if (!m.Success)
            {
                return "a";
            }

            int g = Convert.ToInt32(m.Groups[2].Value + m.Groups[1].Value, b);
            if (!double.IsNaN(g))
            {
                GG gg = new GG();
                retval = Convert.ToChar(97 + await gg.M(g)).ToString() + retval;
            }

            return retval;
        }

        public async Task<List<string>> List_Hash(int number)
        {
            List<string> hash_name = new List<string>();
            
            HttpClient httpclient = new HttpClient();
            HttpResponseMessage response = await httpclient.GetAsync($"https://ltn.hitomi.la/galleries/{number}.js");
            response.EnsureSuccessStatusCode();
            var JSText = await response.Content.ReadAsStringAsync();
            JSText = JSText.Replace("var galleryinfo = ", "");
            JObject jobject = JObject.Parse(JSText);
            for (int i = 0; i < jobject["files"]!.Count(); i++)
            {
                hash_name.Add((string)jobject["files"]![i]!["hash"]!);
            }
            return hash_name;
        } 
    }
}
