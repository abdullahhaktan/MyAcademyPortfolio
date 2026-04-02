# 💼 ASP.NET Core 9 Portfolio Management System

> ASP.NET Core 9.0 MVC ile geliştirilmiş, Admin Panel destekli dinamik portföy yönetim sistemi  
> A dynamic portfolio management system built with ASP.NET Core 9.0 MVC and an integrated Admin Panel

[![.NET](https://img.shields.io/badge/.NET-9.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://learn.microsoft.com/dotnet/csharp/)
[![Architecture](https://img.shields.io/badge/Pattern-MVC-blueviolet.svg)]()
[![Database](https://img.shields.io/badge/Database-SQL_Server-CC2927.svg)](https://www.microsoft.com/sql-server)
[![UI Theme](https://img.shields.io/badge/UI-Mantis_Bootstrap-7952B3?logo=bootstrap)](https://getbootstrap.com/)

---

## 🚀 Özellikler / Features

| 🇹🇷 Türkçe | 🇬🇧 English |
|-----------|------------|
| ASP.NET Core 9.0 MVC mimarisi | ASP.NET Core 9.0 MVC architecture |
| Admin panel üzerinden tam yönetim | Full management via Admin panel |
| Dinamik veri tabanlı portföy içerikleri | Dynamic database-driven portfolio content |
| Entity Framework Core ile ORM yönetimi | ORM management with Entity Framework Core |
| ViewComponent ile modüler UI yapısı | Modular UI structure using ViewComponents |
| Responsive Bootstrap arayüz | Responsive Bootstrap interface |
| Razor View Engine ile güçlü view yönetimi | View management with Razor View Engine |

---

## 🏗️ Mimari / Architecture

```
Net9PortfolioProject/
├── Controllers/
│
├── Models/
│
├── ViewComponents/
│
├── Views/
│
├── Data/
│
├── Migrations/
│
└── wwwroot/
```

ASP.NET Core MVC katmanlı yapısı sayesinde sürdürülebilir ve genişletilebilir bir proje mimarisi sağlanmıştır.

Provides a maintainable and scalable architecture using ASP.NET Core MVC layered structure.

---

## 🧩 Kullanılan Tasarım Yaklaşımları / Design Approaches

### MVC Architecture

Model-View-Controller mimarisi ile uygulama katmanları ayrıştırılmıştır.

Separates application layers using the Model-View-Controller architecture.

---

### ViewComponent Structure

Tekrarlayan UI bileşenleri yeniden kullanılabilir hale getirilmiştir.

Reusable UI components implemented via ViewComponents.

---

### Entity Framework Core (Code First)

Migration yönetimi ile veritabanı kontrolü sağlanmaktadır.

Database lifecycle managed via EF Core migrations.

---

## 🛠️ Kullanılan Teknolojiler / Tech Stack

| Katman / Layer | Teknoloji |
|---------------|-----------|
| Backend | ASP.NET Core 9.0 MVC |
| ORM | Entity Framework Core |
| UI Framework | Bootstrap (Mantis Template) |
| View Engine | Razor |
| Database | SQL Server |
| Language | C# |

---

## ⚙️ Kurulum / Setup

### Gereksinimler / Requirements

- .NET 9 SDK
- SQL Server
- Visual Studio 2022+

---

### Adımlar / Steps

```bash
git clone https://github.com/abdullahhaktan/MyAcademyPortfolio.git
cd MyAcademyPortfolio
```

**Connection string ayarını güncelleyin / Update connection string**

`appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PortfolioDb;Trusted_Connection=True;"
  }
}
```

**Migration işlemlerini çalıştırın / Run migrations**

```bash
add-migration InitialMigration
update-database
```

**Projeyi başlatın / Run the project**

```bash
dotnet run
```

---

## 📸 Ekran Görüntüleri / Screenshots

<img src="https://github.com/user-attachments/assets/4d99e845-1120-4a62-b7c9-db8678367ecd" />

---

<img src="https://github.com/user-attachments/assets/2166edd4-19bf-4d9b-a8c6-1b79a26a74a4" />

---

<img src="https://github.com/user-attachments/assets/2fcf192b-d434-4e44-b3b1-63911d935e4e" />

---

<img src="https://github.com/user-attachments/assets/4f3dc721-e838-41f9-bef9-b2b63f0dcb03" />

---

<img src="https://github.com/user-attachments/assets/4e0033c1-fb83-4a38-b27e-d9d574b23a7d" />

---

<img src="https://github.com/user-attachments/assets/d515afe8-4811-4e8c-a886-682ab2df241b" />

---

<img src="https://github.com/user-attachments/assets/f81be027-e56f-40f0-aece-b93942f31a7e" />

---

<img src="https://github.com/user-attachments/assets/128a601d-e9bd-40ab-9745-573583b2e77a" />

---

<img src="https://github.com/user-attachments/assets/150b675c-0f76-4394-9776-05a23272e532" />

---

## 👨‍💻 Geliştirici / Developer

**Abdullah Haktan**

GitHub → https://github.com/abdullahhaktan
