# Hitomi.NET
Hitomi.la (히토미) API 비공식 다운로더
# Screenshots
![imgNET](https://user-images.githubusercontent.com/124418235/224525550-22720250-64e2-4f74-a957-4817d1ca81e4.PNG)
# Getting started
솔루션 > 추가 > 기존 프로젝트 > Hitomi.NET 프로젝트 추가 > 프로젝트 > 프로젝트 참조 추가
# Example
```cs
HitomiWebp.threads = 4;
HitomiWebp.dir = $@"C:\Users\{Environment.UserName}\Downloads\filestest";
await HitomiWebp.HitomiDownload(12345);
```
