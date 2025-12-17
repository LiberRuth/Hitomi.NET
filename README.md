# Hitomi.NET
Hitomi.la (Hitomi) Informal API
* Extract image path
* Windows, macOS, Linux, Android, iOS All available
# Screenshots
![imgNET](https://user-images.githubusercontent.com/124418235/224525550-22720250-64e2-4f74-a957-4817d1ca81e4.PNG)
# Example
```cs
HitomiWebp hitomiWebp = new HitomiWebp();

List<string> data = await hitomiWebp.HitomiImageList(123456);

foreach (string item in data) 
{
  Console.WriteLine(item);
}
```
