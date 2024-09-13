# Hitomi.NET
Hitomi.la (히토미) 비공식 API 
* 이미지 경로 추출
* 다운로드 기능
* Windows, macOS, Linux 지원합니다
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
