using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistence;
using Cms.Domain.Entities;

namespace Cms.Infrastructure.SeedData
{
    public class DbSeeder(AppDbContext dbContext) : IDbSeeder
    {
        public async Task SeedAsync()
        {
            if (await dbContext.Users.AnyAsync()) return;

            // Kullanıcılar
            var user1 = new User { Id = Guid.NewGuid(), FullName = "Ali Veli", Email = "ali@example.com" };
            var user2 = new User { Id = Guid.NewGuid(), FullName = "Ayşe Yılmaz", Email = "ayse@example.com" };
            var user3 = new User { Id = Guid.NewGuid(), FullName = "Mehmet Kaya", Email = "mehmet@example.com" };

            // Kategoriler
            var techCategory = new Category { Id = Guid.NewGuid(), Name = "Teknoloji" };
            var healthCategory = new Category { Id = Guid.NewGuid(), Name = "Sağlık" };
            var designCategory = new Category { Id = Guid.NewGuid(), Name = "Tasarım" };

            // İçerikler
            var contents = new List<Content>
            {
                // user1 - 3 içerik
                new Content
                {
                    Id = Guid.NewGuid(),
                    Title = "Yapay Zeka Nedir?",
                    Description = "Yapay zeka hakkında temel bilgiler.",
                    Language = "tr",
                    Category = techCategory,
                    User = user1,
                    Variants = new List<ContentVariant>
                    {
                        new ContentVariant { Id = Guid.NewGuid(), VariantName = "Türkçe", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" },
                        new ContentVariant { Id = Guid.NewGuid(), VariantName = "Türkçe", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" }
                    }
                },
                new Content
                {
                    Id = Guid.NewGuid(),
                    Title = "Mobil Geliştirme",
                    Description = "Flutter vs React Native karşılaştırması.",
                    Language = "tr",
                    Category = techCategory,
                    User = user1,
                    Variants = new List<ContentVariant>
                    {
                        new ContentVariant { Id = Guid.NewGuid(), VariantName = "Sunum", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" }
                    }
                },
                new Content
                {
                    Id = Guid.NewGuid(),
                    Title = "UI/UX Tasarım İlkeleri",
                    Description = "Kullanıcı deneyimi tasarımı nedir?",
                    Language = "tr",
                    Category = designCategory,
                    User = user1,
                    Variants = new List<ContentVariant>
                    {
                        new ContentVariant { Id = Guid.NewGuid(), VariantName = "PDF", ImageUrl = "https://dotbadges.com/wp-content/uploads/2023/01/UXUI-510x510.webp" }
                    }
                },

                // user2 - 9 içerik
                new Content { Id = Guid.NewGuid(), Title = "Sağlıklı Yaşam", Description = "Egzersiz ve beslenme ipuçları.", Language = "EN", Category = healthCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "EN", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Vitaminlerin Önemi", Description = "Hangi vitamin ne işe yarar?", Language = "tr", Category = healthCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "İnfografik", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Dijital Detoks", Description = "Ekran bağımlılığına çözüm.", Language = "EN", Category = healthCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Blog", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Grafik Tasarım Temelleri", Description = "Tipografi, renk, denge.", Language = "EN", Category = designCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "İllustrasyon", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Renk Psikolojisi", Description = "Renkler duyguları nasıl etkiler?", Language = "tr", Category = designCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Poster", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Figma ile Prototipleme", Description = "Prototip nasıl oluşturulur?", Language = "EN", Category = designCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Demo", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Web Geliştirme 101", Description = "HTML, CSS ve JS temelleri.", Language = "tr", Category = techCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Kod", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Veritabanı Normalizasyonu", Description = "1NF, 2NF, 3NF açıklamaları.", Language = "EN", Category = techCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Makale", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "C# ile Programlama", Description = "Giriş seviyesinde dersler.", Language = "tr", Category = techCategory, User = user2, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Ders Notu", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },

                // user3 - 6 içerik
                new Content { Id = Guid.NewGuid(), Title = "Sağlık ve Teknoloji", Description = "Giyilebilir teknolojiler", Language = "EN", Category = healthCategory, User = user3, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Video", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Tasarımda Yenilik", Description = "Yeni trendler.", Language = "tr", Category = designCategory, User = user3, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Konferans", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Kodlama Kampı", Description = "Yoğun öğrenme süreci.", Language = "EN", Category = techCategory, User = user3, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Kurs", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Sağlıklı Uyku", Description = "Uyku kalitesini artırma.", Language = "tr", Category = healthCategory, User = user3, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Rehber", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Tasarım Araçları", Description = "Sketch, Adobe XD vs.", Language = "EN", Category = designCategory, User = user3, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Karşılaştırma", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } },
                new Content { Id = Guid.NewGuid(), Title = "Makine Öğrenmesi", Description = "Model eğitimi ve test.", Language = "tr", Category = techCategory, User = user3, Variants = new List<ContentVariant> { new ContentVariant { Id = Guid.NewGuid(), VariantName = "Araştırma", ImageUrl = "https://i0.wp.com/tinasbotanicals.com/wp-content/uploads/2025/01/No-Product-Image-Available.png?fit=800%2C800&ssl=1" } } }
            };

            await dbContext.Users.AddRangeAsync(user1, user2, user3);
            await dbContext.Categories.AddRangeAsync(techCategory, healthCategory, designCategory);
            await dbContext.Contents.AddRangeAsync(contents);
            await dbContext.SaveChangesAsync();
        }
    }
}
