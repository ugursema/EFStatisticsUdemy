# Entity Framework İstatistik Projesi

## 📌 Proje Hakkında

Bu proje, Udemy eğitimi kapsamında C# Windows Forms ve Entity Framework (Database First) kullanılarak geliştirilmiş bir masaüstü uygulamasıdır.

Uygulama, SQL Server veritabanında bulunan veriler üzerinden çeşitli istatistiksel hesaplamalar gerçekleştirir. LINQ sorguları, ilişkisel veri işlemleri ve SQL komutları kullanılarak elde edilen sonuçlar Windows Forms arayüzünde kullanıcıya sunulur.

## 🖥️ Uygulamadan Görüntüler

![Entity Framework İstatistik Uygulaması](./images/FormScreen.png)

## 🚀 Proje Özellikleri

Uygulamada gerçekleştirilen başlıca işlemler:

- **Kayıt Sayıları:** Toplam kategori, ürün, müşteri ve sipariş sayılarının hesaplanması.
- **İstatistiksel Hesaplamalar:** Ürünlerin toplam stok miktarının ve ortalama fiyatının bulunması.
- **Koşullu Sorgulamalar:** Belirli kategorilere ait ürünlerin stok miktarlarının hesaplanması.
- **Ürün Filtreleme:** Aktif ürünlerin ve stok miktarı 20'nin altında olan ürünlerin listelenmesi.
- **İlişkisel Sorgulamalar:** Sipariş, ürün ve kategori tabloları arasında JOIN işlemlerinin gerçekleştirilmesi.
- **Satış İstatistikleri:** Belirli kategorilerdeki ürünlerin toplam satış tutarlarının hesaplanması.
- **SQL Sorguları:** Entity Framework üzerinden doğrudan SQL komutlarının çalıştırılması.
- **Sıralama İşlemleri:** En son eklenen ürünün ve son siparişi veren müşterinin bilgilerinin getirilmesi.
- **Tekil Kayıt İşlemleri:** Veritabanındaki farklı ülke sayısının hesaplanması.

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Kullanım Amacı |
|---|---|
| C# | Programlama dili |
| .NET Framework | Uygulama geliştirme platformu |
| Windows Forms | Masaüstü kullanıcı arayüzü |
| Entity Framework | ORM ve veritabanı işlemleri |
| Database First | Veritabanı yaklaşımı |
| Microsoft SQL Server | İlişkisel veritabanı |
| LINQ | Veri sorgulama ve filtreleme |
| SQL | Veritabanı sorguları |
| Git & GitHub | Versiyon kontrolü |

## 💻 Kullanılan LINQ ve SQL Metotları

Proje kapsamında aşağıdaki metot ve sorgulama teknikleri kullanılmıştır:

- `Count()` – Kayıt sayısını hesaplama
- `Sum()` – Toplam değer hesaplama
- `Average()` – Ortalama değer hesaplama
- `Where()` – Koşula bağlı filtreleme
- `Join()` – İlişkili tabloları birleştirme
- `OrderByDescending()` – Azalan şekilde sıralama
- `Distinct()` – Tekrarlayan kayıtları ayıklama
- `FirstOrDefault()` – İlk kaydı veya varsayılan değeri getirme
- `Database.SqlQuery()` – Entity Framework üzerinden SQL sorgusu çalıştırma

 

## 🎯 Projenin Amacı

Bu proje ile Entity Framework kullanarak veritabanı işlemlerini gerçekleştirme, LINQ sorguları oluşturma, ilişkisel tablolar üzerinde çalışabilme ve SQL sorgularını C# uygulamalarına entegre etme konularında pratik yapılmıştır.
