
# BetteRFlow

En modern webbapplikation för att digitalisera och effektivisera informationsutbytet mellan bostadsrättsföreningar (BRF) och fastighetsmäklare.

[![Live Demo](https://img.shields.io/badge/demo-live-success)](https://betterflow-3.onrender.com)
[![Backend API](https://img.shields.io/badge/api-swagger-blue)](https://betterflow-4.onrender.com)

---

## 📋 Projektöversikt

BetteRFlow ersätter manuella och ostrukturerade arbetsflöden (PDF-formulär, e-post) med ett centralt, databaserat system där BRF:er digitalt rapporterar fastighetsdata som mäklare sedan kan söka och köpa tillgång till.

Systemet säkerställer datakvalitet genom automatisk avvikelsedetektion och administrativ granskning innan information exponeras.

---

## ✨ Huvudfunktioner

### 🏢 BRF-portal
- Registrering med organisationsnummer
- Digitalt formulär med 50+ fält om föreningen och fastigheten
- Automatisk matchning mot grunddata
- Uppdatering av föreningsinformation över tid

### 🔍 Avvikelsesystem (Kärnfeature)
- Automatisk jämförelse mellan inlämnat formulär och grunddata
- Flaggar alla skillnader som avvikelser
- Förhindrar automatisk överskrivning av data
- Kräver administrativ granskning för kvalitetssäkring

### 🏘️ Mäklarportal
- Sök efter BRF:er (aktiva föreningar)
- Förhandsgranskning av grundinformation (gratis)
- Köp av detaljerad fastighetsdata (299 kr)
- Strukturerad data tillgänglig direkt efter köp

### 🛡️ Adminpanel
- Hantera BRF-grunddata (manuell inmatning eller Excel-import)
- Granska avvikelser (godkänn/avvisa ändringar)
- Översikt av användare (BRF:er och mäklare)
- Aktivera/inaktivera BRF:er
- Statistik över systemanvändning
- Spårbarhet av alla systemändringar

---

## 🏗️ Systemarkitektur

### Projektstruktur
```
BetteRFlowSolutions/
├── BetteRFlow.Shared/          # Delad kod mellan FE och BE
│   ├── Models/                 # Databasmodeller (EF Core entities)
│   │   ├── User.cs
│   │   ├── Brf.cs
│   │   ├── FormSubmission.cs
│   │   ├── Purchase.cs
│   │   ├── BrfAvvikelse.cs
│   │   ├── Maklare.cs
│   │   ├── PageView.cs
│   │   └── AppEvent.cs
│   ├── DTOs/                   # Data Transfer Objects
│   │   ├── UserDto.cs
│   │   ├── BrfDto.cs
│   │   ├── FormDto.cs
│   │   ├── LoginDto.cs
│   │   ├── RegisterDto.cs
│   │   └── PurchaseDto.cs
│   └── Data/                   
│       └── BetteRFlowContext.cs
│
├── BetteRFlowWebAPI/           # Backend (REST API)
│   ├── Controllers/
│   │   ├── AuthController.cs              # Registrering & inloggning
│   │   ├── BrfController.cs               # BRF CRUD & sökning
│   │   ├── FormSubmissionController.cs    # Formulär & avvikelser
│   │   ├── PurchaseController.cs          # Köpflöde
│   │   ├── UserController.cs              # Användarhantering
│   │   ├── AdminStatisticsController.cs   # Statistik
│   │   ├── AvvikelserController.cs        # Avvikelshantering
│   │   └── BrfImportController.cs         # Excel-import
│   ├── Program.cs
│   └── appsettings.json
│
└── BetteRFlowWebApp/           # Frontend (Blazor Server)
    ├── Components/
    │   ├── Layout/
    │   │   ├── MainLayout.razor
    │   │   └── NavMenu.razor
    │   ├── Pages/
    │   │   ├── Main/
    │   │   │   ├── Home.razor
    │   │   │   ├── Register.razor
    │   │   │   └── Login.razor
    │   │   ├── BrfPages/
    │   │   │   ├── Brf.razor
    │   │   │   └── BrfForm.razor
    │   │   ├── Maklare/
    │   │   │   ├── Maklare.razor
    │   │   │   ├── SokBrf.razor
    │   │   │   └── PurchaseBrf.razor
    │   │   └── Admin/
    │   │       ├── Admin.razor
    │   │       ├── AdminDashboard.razor
    │   │       ├── AdminStatistics.razor
    │   │       ├── AvvikelserOverview.razor
    │   │       ├── BrfCreate.razor
    │   │       ├── BrfEdit.razor
    │   │       ├── BrfImport.razor
    │   │       ├── BrfList.razor
    │   │       ├── FormList.razor
    │   │       ├── MaklareList.razor
    │   │       └── RegisterAdmin.razor
    │   └── wwwroot/
    └── Program.cs
```

### Kommunikationsflöde
```
Browser (User)
    ↓
Blazor Server (Frontend)
    ↓ HTTP REST Calls
ASP.NET Core Web API (Backend)
    ↓ Entity Framework Core
PostgreSQL Database
```

---

## 🛠️ Teknologier

### Backend
- **.NET 8** - Modern C# application framework
- **ASP.NET Core Web API** - RESTful API with controllers
- **Entity Framework Core 8** - ORM för databaskommunikation
- **BCrypt.Net** - Säker lösenordshashning
- **Swagger/OpenAPI** - Auto-genererad API-dokumentation

### Frontend
- **Blazor Server (.NET 8)** - C#-baserad frontend med server-side rendering
- **MudBlazor 7** - Material Design UI-komponentbibliotek
- **Bootstrap 5** - Responsiv design och layout

### Databas
- **SQLite** - Lokal utvecklingsmiljö (filbaserad)
- **PostgreSQL 16** - Produktion (Render.com managed database)
- **pgAdmin 4** - Databasadministration

### Infrastruktur & DevOps
- **Docker** - Containerbaserad deployment
- **Render.com** - Cloud hosting (Frontend + Backend + Database)
- **GitHub** - Versionshantering och CI/CD trigger
- **Visual Studio 2022** - Utvecklingsmiljö

---

## 📊 Datamodell

### Entity Relationship Diagram (förenklat)
```
User (1) ──────────── (1) Brf
  │                         │
  │                         │
  ├── (många) Purchase      ├── (många) FormSubmission
  │                         │
  │                         │
  └─────────────────────────┴── (många) BrfAvvikelse
```

### Kärnmodeller

#### **User** - Systemanvändare
- Autentisering med BCrypt-hashade lösenord
- Roller: `0` = BRF, `1` = Mäklare, `2` = Admin
- Fält: Id, Fornamn, Efternamn, Email, Password (hash), Role, IsActive, Firma (för mäklare)
- Admin skapas ENDAST manuellt i databas (säkerhet)

#### **Brf** - Bostadsrättsförening (grunddata)
- Referensdata som admin skapar (manuellt eller via Excel)
- Organisationsnummer (unikt, 10 siffror med eller utan utan bindestreck just nu)
- Grundläggande information: Namn, adress, kontaktuppgifter
- Status: `IsActive` (aktiveras automatiskt vid formulärmatchning)
- Navigation: FormSubmissions, BrfAvvikelser

#### **FormSubmission** - Inskickat formulär från BRF
- 50+ fält med detaljerad fastighets- och föreningsinformation
- Koppling till BRF via organisationsnummer
- Används för matchning mot grunddata och avvikelsedetektion
- Sparas som ny post vid varje inlämning (historik)
- CreatedAt timestamp för spårbarhet

#### **BrfAvvikelse** - Avvikelse mellan grunddata och formulär
- Skapas automatiskt vid formulärinlämning om data skiljer sig
- Fält: 
  - BrfId, FormSubmissionId (foreign keys)
  - Faltnamn (vilket fält som skiljer sig)
  - VardeGrunddata (värde i grunddata)
  - VardeFormular (värde i formulär)
  - Granskad (false tills admin hanterat)
- Kräver administrativ granskning för godkännande/avvisning
- Kärnfunktion för datakvalitetssäkring
  

#### **Purchase** - Mäklarköp av fastighetsdata
- Koppling: UserId (mäklare), FormSubmissionId
- Belopp, betalningsstatus, transaktions-ID
- Timestamp för köptillfälle
- Ger mäklare tillgång till fullständig information
- Förenklat betalningsflöde (demonstration, ingen extern integration)

#### **PageView & AppEvent** - Statistik
- Spårning av användaraktivitet
- Data för AdminStatistics dashboard

---

## 🔐 Säkerhet

### Autentisering
- **BCrypt.Net** för lösenordshashning (salt + cost factor)
- Lösenord lagras ALDRIG i klartext
- Session-hantering via localStorage (förenklad implementation)

### Auktorisering
- Rollbaserad åtkomstkontroll (RBAC)
- Backend verifierar roll vid varje skyddat API-anrop
- Frontend döljer UI baserat på roll (men backend är sanningskälla)
- Admin-funktioner INTE exponerade för BRF/Mäklare

### Designprinciper
- Minsta möjliga behörighet per roll
- Ingen känslig affärslogik i frontend
- Backend som enda sanningskälla
- Foreign keys säkerställer dataintegritet

### Kända begränsningar (planerade förbättringar)
- ⚠️ **JWT**: Förenklad auth (inte production-ready ASP.NET Identity)
- ⚠️ **localStorage**: Bör ersättas med HttpOnly cookies (XSS-skydd)
- ⚠️ **Token expiration**: Ingen automatisk logout vid session timeout

---

## 🚀 Deployment

### Produktion (Live)
- **Frontend**: https://betterflow-3.onrender.com
- **Backend API**: https://betterflow-4.onrender.com
- **Databas**: PostgreSQL (managed by Render)

### CI/CD Pipeline
1. Push till GitHub (devnew branch)
2. Render detekterar commit
3. Auto-build av Docker containers
4. Auto-deploy till produktion
5. ⚠️ Manuell databas-migration via pgAdmin (migrations körs EJ automatiskt)

### Miljökonfiguration
- **Development**: SQLite, localhost URLs
- **Production**: PostgreSQL, Render URLs, environment variables

### Viktigt vid deployment
- Första laddningen kan ta 30-60 sekunder (gratis Render-plan = "sleep mode")
- Hard refresh (`Ctrl+Shift+R`) kan behövas efter uppdateringar
- Browser cache kan hålla gamla localStorage-strukturer
- Användare måste logga ut/in vid större uppdateringar

---

## 💻 Lokal körning

### ⚠️ Viktigt meddelande
Projektet är primärt optimerat för produktion (Render). Lokal installation kan kräva felsökning och anpassningar. **För testning rekommenderas live-versionen: https://betterflow-3.onrender.com**

### Förutsättningar
- .NET 8 SDK
- Visual Studio 2022 (eller VS Code + C# extension)
- Git

### Installation
```bash
# Klona repository
git clone https://github.com/dittnamn/BetteRFlowSolutions.git
cd BetteRFlowSolutions

# Återställ NuGet-paket
dotnet restore

# Bygg solution
dotnet build
```

### Köra lokalt

#### Backend (API)
```bash
cd BetteRFlowWebAPI
dotnet run
# API körs på https://localhost:7001
# Swagger UI: https://localhost:7001/swagger
```

#### Frontend (WebApp)
```bash
cd BetteRFlowWebApp
dotnet run
# App körs på https://localhost:5001
```

#### Databas (lokal)
- SQLite-fil skapas automatiskt i `/BetteRFlowWebAPI/betterflow.db`
- Ingen installation behövs
- pgAdmin behövs INTE lokalt (bara för produktion)

### Första körningen
1. Kör Backend först (skapar databas)
2. Migrations kan behöva köras manuellt: `dotnet ef database update`
3. Starta Frontend
4. Registrera en BRF/Mäklare via UI
5. Skapa admin manuellt i SQLite (via DB Browser for SQLite):
```sql
   INSERT INTO Users (Fornamn, Efternamn, Email, Password, Role, IsActive)
   VALUES ('Admin', 'User', 'admin@betterflow.se', '[BCrypt-hash]', 2, 1);
```

### Kända problem vid lokal körning
- **Databas-skillnader**: SQLite (lokal) vs PostgreSQL (produktion) kan ge olika beteende
- **Migrations**: Måste köras manuellt lokalt
- **Connection strings**: Kan behöva anpassas i appsettings.json
- **Testdata**: Saknas lokalt, måste skapas manuellt eller importeras

**Vid problem:** Använd live-versionen, fungerar till 31/1 -2026, eller kontakta utvecklaren för support.


## 📚 API-dokumentation

### Swagger UI
- **Lokal**: https://localhost:7001/swagger
- **Produktion**: https://betterflow-4.onrender.com/swagger

### Viktiga Endpoints

#### Autentisering
- `POST /api/Auth/register` - Registrera BRF/Mäklare
- `POST /api/Auth/login` - Logga in

#### BRF-hantering
- `GET /api/Brf` - Hämta alla BRF:er
- `GET /api/Brf/{id}` - Hämta specifik BRF
- `POST /api/Brf` - Skapa ny BRF (admin)
- `PUT /api/Brf/{id}` - Uppdatera BRF (admin)
- `POST /api/BrfImport/upload` - Excel-import (admin)

#### Formulär
- `POST /api/FormSubmission` - Skicka in formulär
- `GET /api/FormSubmission` - Hämta alla formulär

#### Avvikelser
- `GET /api/Avvikelser` - Hämta avvikelser
- `POST /api/Avvikelser/godkann/{id}` - Godkänn avvikelse
- `POST /api/Avvikelser/avvisa/{id}` - Avvisa avvikelse

#### Köp
- `POST /api/Purchase` - Genomför köp (mäklare)
- `GET /api/Purchase/user/{userId}` - Hämta användarens köp

#### Statistik
- `GET /api/AdminStatistics` - Hämta systemstatistik

---

## 🧪 Testning

### Manuell testning
- Registrering av olika roller
- Inloggningsflöden
- Formulärinlämning och avvikelsedetektion
- Köpflöde för mäklare
- Admin-granskning av avvikelser
- Excel-import

### Swagger-testning
- Direkt API-testning via Swagger UI
- Verifiering av HTTP-statuskoder
- Validering av request/response

### Testdata
Excel-fil för BRF-import finns i `/TestData/brfImportTemplate.xlsx`

### Kända begränsningar
- ⚠️ Inga automatiserade tester (unit/integration) implementerade
- ⚠️ Ingen belastningstestning utförd
- ⚠️ Prestandatester saknas

---

## ⚠️ Kända begränsningar

### Funktionella
- **Matchning**: Endast på exakt organisationsnummer (fuzzy matching ej implementerat)
- **Betalning**: Förenklat flöde utan Swish/Stripe (demonstration)
- **Migrations**: Måste köras manuellt mot produktionsdatabas
- **Formulär-versionshantering**: Saknas (problem vid schemaändringar)

### Tekniska
- **JWT**: Förenklad auth (inte ASP.NET Identity)
- **Blazor Server**: Begränsad skalbarhet (persistent SignalR-connections)
- **localStorage**: Bör ersättas med HttpOnly cookies
- **Error handling**: Grundläggande implementation

### Arkitektoniska
- **Skalbarhet**: Max ~5,000-10,000 samtidiga användare (Blazor Server)
- **CI/CD**: Migrations körs inte automatiskt
- **Monitoring**: Ingen logging/alerting i produktion

---

## 🚀 Framtida utveckling

Det finns flera möjliga förbättringar av systemet. De mest prioriterade är migration till Azure SQL med automatiska migrations, vilket skulle eliminera den manuella databas-hanteringen som varit problematisk under utvecklingen. Fuzzy matching för organisationsnummer skulle förbättra användarupplevelsen genom att matcha även vid stavfel. Mäklarhantering bör få samma struktur som BRF-hanteringen med grunddata, matchning och Excel-import.

På lite längre sikt skulle Swish-integration ersätta det förenklade betalningsflödet, och ett email-system där admin kan skicka inbjudningar direkt från dashboarden skulle förenkla onboarding-processen. ASP.NET Identity skulle ersätta den nuvarande förenklade autentiseringen för en mer robust och production-ready lösning. Automatiserade tester hade underlättat vidareutveckling och minskat risken för regression.

För långsiktig skalbarhet skulle en migration till Blazor WebAssembly för publika delar (mäklarsökning) möjliggöra stöd för betydligt fler samtidiga användare, medan admin-delen kan behålla Blazor Server. Integration med Bolagsverkets API är slutmålet för BRF-data - Excel-importen är en temporär lösning tills automatisk synkronisering mot externa register kan implementeras.

*Not: Långsiktiga utvecklingsförslag baseras delvis på diskussioner med AI-verktyg för att utforska tekniska möjligheter.*

---

## 📖 Dokumentation

### Tekniska rapporter
- **Del 1**: Arbete fram till 16/12 (initial implementation)
- **Del 2**: Arbete 17/12-10/1 (avvikelsesystem, deployment, förbättringar, statistik)

### Verktygsrapport 

### Versionering
- **v1.0**: Initial release med kärnfunktionalitet
- **v1.1**: Avvikelsesystem och automatisk aktivering
- **v1.2**: Mäklarlista, köpflödesförbättringar och statistik

---

## 👥 Författare

**Maria Schillström**
- YH-student, Molnutveckling .NET
- Campus Mölndal
  

---

## 📄 Licens

Detta är ett utbildningsprojekt utan kommersiell licens.

---

## 🙏 Tack till

- **Handledare & mentor**: Teknisk support och feedback
- **Kurskamrater**: Testning och användarfeedback
- **MudBlazor-communityn**: UI-komponentbibliotek
- **Stack Overflow**: Felsökning och lösningar

---

## 📞 Kontakt

För frågor eller feedback, kontakta:
- **Email**: [mariaschillstrom@hotmail.com]
- **GitHub Issues**: https://github.com/dittnamn/BetteRFlowSolutions/issues

---

**Senast uppdaterad**: 2026-01-12
