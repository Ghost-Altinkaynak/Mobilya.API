# 🪑 Cihan Mobilya — Özel Ölçü Mobilya Atölyesi Web Sitesi

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-5C2D91)
![EF Core](https://img.shields.io/badge/EF%20Core-10.0-512BD4)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT-000000?logo=jsonwebtokens)
![License](https://img.shields.io/badge/License-MIT-green)

Özel ölçü mobilya yapan bir atölye için geliştirilmiş **tek sayfalık tanıtım sitesi** ve onu yöneten **admin paneli**. Site, tek bir ASP.NET Core uygulaması olarak çalışır: hem REST API'yi hem de ön yüzü (HTML / CSS / JS) aynı projeden sunar. Sitedeki tüm içerik veritabanından gelir ve admin panelden düzenlenir, yazı değiştirmek için kod açmaya gerek kalmaz.

> 🌐 Canlı site: **https://cihanmobilya.com**

---

## 📸 Ekran Görüntüleri

### Ana Sayfa

![Ana sayfa](docs/images/ana-sayfa.png)

### Hizmetler ve Süreç

| Hizmetler | Süreç |
|-----------|-------|
| ![Hizmetler](docs/images/hizmetler.png) | ![Süreç](docs/images/surec.png) |

### Galeri ve Keşif Talep Formu

| Galeri | Talep formu |
|--------|-------------|
| ![Galeri](docs/images/galeri.png) | ![Talep formu](docs/images/talep-formu.png) |

### Mobil Görünüm

![Mobil görünüm](docs/images/mobil.png)

### Admin Paneli

| Giriş | Genel bakış |
|-------|-------------|
| ![Admin giriş](docs/images/admin-giris.png) | ![Admin genel bakış](docs/images/admin-genel-bakis.png) |

| Galeri yönetimi | Gelen talepler |
|-----------------|----------------|
| ![Galeri yönetimi](docs/images/admin-galeri.png) | ![Gelen talepler](docs/images/admin-talepler.png) |

---

## ✨ Özellikler

### 🌍 Ziyaretçi tarafı

| Bölüm | Açıklama |
|-------|----------|
| **Ana Başlık (Hero)** | Atölyenin başlığı, açıklaması ve öne çıkan güven maddeleri |
| **Hizmetler** | Gardırop, mutfak dolabı vb. hizmet kartları |
| **Süreç** | "Keşif → Tasarım → Üretim → Montaj" adımları |
| **Neden Biz** | Güven veren maddeler ve sayısal göstergeler (proje sayısı, tecrübe vb.) |
| **Galeri** | Hizmete göre filtrelenebilen örnek çalışmalar, fotoğraf yoksa renkli yer tutucu |
| **Keşif Talep Formu** | Ad soyad, telefon, bölge ve mesaj ile ücretsiz keşif talebi |
| **İletişim** | Telefon, e-posta, adres, WhatsApp ve harita |

### 🔐 Admin paneli (`/#admin`)

- **Genel bakış:** Sitenin ve gelen taleplerin özeti
- **İçerik yönetimi:** Ana başlık, hizmetler, süreç adımları, güven maddeleri, istatistikler ve iletişim bilgilerini ekle / düzenle / sil / sırala
- **Galeri:** Fotoğraf yükle, hizmete bağla, renk ve sıra belirle
- **Talepler:** Formdan gelen keşif taleplerini görüntüle ve "işlendi" olarak işaretle
- **Ayarlar:** Yönetici şifresini değiştir

### 🛡️ Güvenlik

- JWT (Bearer) ile kimlik doğrulama, yönetim uçları `[Authorize]` ile korunur
- Parolalar **BCrypt** ile hash'lenerek saklanır
- Giriş denemelerine **hız sınırı** (rate limiting) uygulanır
- Yükleme uç noktasında uzantı kontrolü (`jpg`, `jpeg`, `png`, `webp`) ve boyut sınırı (10 MB)
- CORS yalnızca izin verilen alan adlarına açıktır
- Gizli bilgiler (JWT anahtarı, yönetici şifresi) koda yazılmaz, ortam ayarından okunur

---

## 🛠️ Kullanılan Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| Arka uç | C#, ASP.NET Core Web API (.NET 10) |
| Veri erişimi | Entity Framework Core 10 (Code First + Migrations) |
| Veritabanı | Microsoft SQL Server |
| Kimlik doğrulama | JWT Bearer, BCrypt.Net-Next |
| API dokümantasyonu | Swagger / Swashbuckle (yalnızca geliştirme ortamında) |
| Ön yüz | HTML5, CSS3, Vanilla JavaScript (`fetch`) |

---

## 🗄️ Veritabanı Tabloları

`AnaSayfaManset` · `Hizmetler` · `SurecAdimlari` · `NedenBizMaddeleri` · `GuvenMaddeleri` · `Istatistikler` · `GaleriOgeleri` · `IletisimBilgileri` · `IletisimMaddeleri` · `Talepler` · `Yoneticiler`

Uygulama ilk açılışta migration'ları otomatik uygular ve tablolar boşsa örnek verilerle doldurur (`DbInitializer`).

---

## 📁 Proje Yapısı

```
Moilya.API/
├── Controllers/        # REST uç noktaları (Auth, Hizmetler, Galeri, Talepler, ...)
├── Context/
│   ├── AppDbContext.cs     # EF Core DbContext
│   └── DbInitializer.cs    # Migration + örnek veri + ilk yönetici
├── Entities/           # Veritabanı modelleri
├── Dtos/               # Giriş, token ve şifre değiştirme modelleri
├── Services/
│   └── JwtTokenService.cs  # Token üretimi
├── Migrations/         # EF Core migration dosyaları
├── wwwroot/
│   ├── index.html          # Site + admin paneli arayüzü
│   ├── js/                 # site.js, admin.js, api.js, modal.js
│   └── uploads/            # Yüklenen galeri fotoğrafları
├── docs/
│   └── images/             # README ekran görüntüleri
├── Program.cs          # Servisler, JWT, CORS, rate limiter, middleware
├── appsettings.json    # Gizli olmayan ayarlar
└── Moilya.API.csproj
```

---

## 🔌 API Uç Noktaları

Herkese açık okuma (`GET`) uçları ziyaretçi sitesini besler. Yazma uçları yönetici girişi gerektirir.

| Uç nokta | Yöntemler | Not |
|----------|-----------|-----|
| `/api/AnaSayfa` | `GET` · `PUT /manset` 🔒 | Tüm ana sayfa içeriği tek istekte |
| `/api/Hizmetler` | `GET` · `POST` `PUT` `DELETE` 🔒 | |
| `/api/SurecAdimlari` | `GET` · `POST` `PUT` `DELETE` 🔒 | |
| `/api/NedenBiz` | `GET` · `POST` `PUT` `DELETE` 🔒 | |
| `/api/GuvenMaddeleri` | `GET` · `POST` `PUT` `DELETE` 🔒 | |
| `/api/Istatistikler` | `GET` · `POST` `PUT` `DELETE` 🔒 | |
| `/api/Galeri` | `GET` · `POST` `PUT` `DELETE` 🔒 | `POST /yukle` 🔒 ile fotoğraf yükleme |
| `/api/Iletisim` | `GET` · `PUT` 🔒 | |
| `/api/IletisimMaddeleri` | `GET` · `POST` `PUT` `DELETE` 🔒 | |
| `/api/Talepler` | `POST` (herkese açık) · `GET` `PUT` `DELETE` 🔒 | Keşif talepleri |
| `/api/Auth` | `POST /login` · `POST /sifre-degistir` 🔒 | JWT üretir |

🔒 = Bearer token gerekir.

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express, LocalDB ya da tam sürüm) ve isteğe bağlı SSMS
- Visual Studio 2022+ veya VS Code

### 1. Projeyi indir

```bash
git clone https://github.com/<kullanici-adi>/<repo-adi>.git
cd <repo-adi>
```

### 2. Veritabanı bağlantısını ayarla

`appsettings.Development.json` dosyasına kendi bilgisayarına uygun bağlantıyı yaz:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=MoilyaDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Gizli ayarları gir (User Secrets)

Gizli bilgiler **projeye yazılmaz**, User Secrets ile saklanır:

```bash
dotnet user-secrets set "Jwt:Key" "en-az-32-karakterlik-rastgele-uzun-bir-metin"
dotnet user-secrets set "Admin:InitialPassword" "ilk-yonetici-sifresi"
```

### 4. Çalıştır

```bash
dotnet run --launch-profile http
```

İlk çalıştırmada veritabanı ve tablolar otomatik oluşur, örnek veriler yüklenir. Sonra:

- Site: `http://localhost:5062`
- Admin paneli: `http://localhost:5062/#admin` (kullanıcı adı `admin`, şifre: `Admin:InitialPassword`)
- Swagger: `http://localhost:5062/swagger` (yalnızca geliştirme ortamında)

---

## ☁️ Yayınlama (IIS / Plesk Windows)

```bash
dotnet publish -c Release -o C:\Yayin\cihanmobilya
```

1. Çıkan klasörün **içindekileri** sunucudaki `httpdocs` dizinine yükle.
2. Sunucuda **.NET 10 Hosting Bundle** kurulu olmalı (ya da self-contained yayınla).
3. Sunucudaki `appsettings.json` dosyasına canlı bağlantı dizesini, `Jwt:Key` ve `Admin:InitialPassword` değerlerini yaz. **Bu dosyayı GitHub'a gönderme.**
4. `wwwroot/uploads` klasörüne uygulama havuzu için **yazma izni** ver (fotoğraf yükleme için gerekir).
5. Alan adı için SSL sertifikası (Let's Encrypt) etkinleştir ve HTTP → HTTPS yönlendirmesini aç.
6. Yeniden yayınlarken `wwwroot/uploads` klasörünü **ezme**, yüklenen fotoğraflar orada duruyor.

---

## 🔒 Güvenlik Notları

- `appsettings.json` içine gerçek şifre, JWT anahtarı veya canlı bağlantı dizesi **yazma**.
- Yerel geliştirmede User Secrets, sunucuda ortam değişkeni ya da sunucuya özel ayar dosyası kullan.
- Bir şifre yanlışlıkla GitHub'a gittiyse dosyayı düzeltmek yetmez, git geçmişinde kalır. Şifreyi mutlaka **değiştir**.
- `Admin:InitialPassword` yalnızca yönetici tablosu boşken ilk hesabı oluşturmak için kullanılır. Panele girince şifreni **Ayarlar** bölümünden değiştir.

---

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile paylaşılmıştır.

---

<p align="center">
 <b>Mustafa Altınkaynak tarafından kullanılmaktadır </b>
</p>
