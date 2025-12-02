
# BetteRFlow

En modern webbapplikation för att effektivisera informationsflödet mellan bostadsrättsföreningar (BRF) och mäklare.

## 📋 Projektöversikt

BetteRFlow är ett system som förenklar processen när mäklare behöver fastighetsdata från BRF:er. Systemet ersätter manuell hantering av formulär med en digital lösning där BRF:er fyller i strukturerad information som mäklare sedan kan köpa tillgång till.

### Huvudfunktioner

- **BRF-portal**: Styrelsemedlemmar kan registrera sig och fylla i omfattande formulär om sina fastigheter
- **Mäklarportal**: Mäklare kan söka efter fastigheter och köpa tillgång till detaljerad information
- **Adminpanel**: Hantering av användare, inbjudningar och systemöversikt

## 🏗️ Systemarkitektur

Projektet är byggt med en modern arkitektur som separerar frontend, backend och delad kod:

```
BetteRFlowSolutions/
├── BetteRFlow.Shared/          # Delad kod (Models, DTOs, Enums)
│   ├── Models/                 # Databasmodeller
│   ├── DTOs/                   # Data Transfer Objects
│   └── Data/                   # DbContext
├── BetteRFlowWebAPI/           # Backend (REST API)
│   └── Controllers/            # API endpoints
└── BetteRFlowWebApp/           # Frontend (Blazor Web App)
    └── Components/
        └── Pages/              # Razor-sidor

```

## 🛠️ Teknologier

### Backend

- **.NET 8** - Modern C# framework
- [**ASP.NET](http://asp.net/) Core Web API** - RESTful API
- **Entity Framework Core** - ORM för databashantering
- **SQLite** (utveckling) / **Azure SQL** (produktion)

### Frontend

- **Blazor Web App (.NET 8)** - C#-baserad frontend
- **MudBlazor** - UI-komponentbibliotek
- **Bootstrap** - Responsiv design

### Verktyg

- **Visual Studio 2022** - IDE
- **Git & GitHub** - Versionshantering
- **Swagger** - API-dokumentation
- **Azure** - Cloud hosting (planerat)
- **GitBook** - Dokumentationsplattform
- **Azure** - Cloud hosting
- **Azure SQL** - Produktionsdatabas

## 📊 Datamodell

### Kärnmodeller

**User** - Användare (BRF-medlem, Mäklare, Admin)

- Autentisering och roller
- Koppling till BRF eller mäklarfirma

**Brf** - Bostadsrättsförening

- Organisationsinformation
- Koppling till fastigheter

**Fastighet** - Enskild byggnad

- Adress och teknisk information
- Koppling till BRF

**Form** - Formulärmall

- 50+ frågor om fastigheten
- Kategoriserad information

**FormSubmission** - Ifyllt formulär

- BRF:s svar på alla frågor
- Koppling till specifik fastighet

**Purchase** - Mäklarköp

- Tillgång till fastighetsdata
- Betalningsinformation

**Invitation** - Inbjudan till BRF

- Unik länk för registrering
- Spårning av status
