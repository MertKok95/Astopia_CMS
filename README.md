# CMS Projesi

Bu proje, .NET 9 üzerinde geliştirilen, Clean Architecture prensiplerine uygun, katmanlı mimaride bir İçerik Yönetim Sistemi (CMS) uygulamasıdır. Kullanıcıların içeriklerle etkileşime geçebildiği, varyantları görüntüleyebildiği ve kategorilere, dillere göre filtreleme yapabildiği bir sistemdir.

---

## Kullanılan Teknolojiler

- .NET 9
- C#
- ASP.NET Core MVC
- Clean Architecture (Domain, Application, Infrastructure, Web katmanları)
- Entity Framework Core (Code First)
- Mapster (DTO dönüşümleri için)
- Microsoft.Extensions.Caching.Memory (In-Memory Cache)
- SQL Server / LocalDB
- Git (versiyon kontrol için)

---

## Projenin Özellikleri

- Kullanıcı bazlı içerik yönetimi
- İçerik varyantlarının yönetimi ve seçimi (stateful varyant yönetimi)
- Kategori ve dil bazlı içerik filtreleme
- Performans için 15 dakikalık In-Memory cache kullanımı
- Repository Pattern veri erişimi
- Async/Await ile asenkron veri işlemleri
- Katmanlı ve SOLID prensiplerine uygun mimari

---

## Kurulum ve Çalıştırma Adımları

### 1. Gereksinimler

- .NET 9 SDK yüklü olmalıdır. ([İndir](https://dotnet.microsoft.com/en-us/download/dotnet/9.0))
- SQL Server Express veya LocalDB kurulmalıdır.
- (İsteğe bağlı) Visual Studio 2022 veya Visual Studio Code kurulabilir.

### 2. Proje Dosyalarını İndir

```bash
git clone https://github.com/kullaniciadi/proje-adi.git
cd proje-adi


### 3. Proje Çalıştırma (vs code)

- cd Cms.Web
- dotnet run