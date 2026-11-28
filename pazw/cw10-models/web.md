# Od aplikacji Web do MVC - Przewodnik krok po kroku

## 1. Przygotowanie środowiska

### 1.1 Instalacja wymaganych narzędzi

Przed rozpoczęciem upewnij się, że masz zainstalowane:

- **Visual Studio Code** (najnowsza wersja)
- **.NET SDK** (wersja 6.0 lub nowsza)
  ```bash
  dotnet --version  # Sprawdzenie zainstalowanej wersji
  ```
- **C# Dev Kit** - wtyczka dla VS Code
  - Otwórz VS Code
  - Przejdź do zakładki rozszerzeń (Extensions) `Ctrl+Shift+X`
  - Wyszukaj "C# Dev Kit"
  - Kliknij "Install"

### 1.2 Sprawdzenie instalacji C# Dev Kit

Po instalacji powinieneś zobaczyć:
- Nową zakładkę w pasku bocznym (C# Dev Kit icon)
- Interfejs do zarządzania projektami
- Obsługę debugowania

## 2. Struktura katalogów projektu MVC

### 2.1 Typowa struktura aplikacji ASP.NET MVC Core

```
MyWebApp/
├── Controllers/           # Kontrolery obsługujące żądania
│   ├── HomeController.cs
│   └── [OtherController].cs
├── Models/               # Modele danych
│   ├── User.cs
│   ├── Product.cs
│   └── [OtherModel].cs
├── Views/                # Widoki (szablony HTML)
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── About.cshtml
│   │   └── [OtherView].cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml        # Szablon główny
│   │   ├── _Navigation.cshtml    # Nawigacja
│   │   └── _Footer.cshtml        # Stopka
│   └── [OtherController]/
├── wwwroot/              # Pliki statyczne
│   ├── css/
│   │   ├── style.css
│   │   └── bootstrap.css
│   ├── js/
│   │   ├── app.js
│   │   └── jquery.js
│   ├── images/
│   └── lib/              # Biblioteki JavaScript/CSS
├── Data/                 # Klasy dostępu do bazy danych
│   ├── ApplicationDbContext.cs
│   └── [RepositoryClasses].cs
├── Program.cs            # Punkt wejścia aplikacji
├── appsettings.json      # Konfiguracja (baza danych, logging)
├── appsettings.Development.json  # Konfiguracja dla Dev
├── MyWebApp.csproj       # Plik projektu
└── README.md
```

### 2.2 Co zawiera każdy katalog

#### **Controllers/**
- Klasy obsługujące logikę biznesową
- Odpowiadają na żądania HTTP
- Zwracają widoki lub dane JSON

```csharp
// Przykład: Controllers/HomeController.cs
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

#### **Models/**
- Klasy reprezentujące dane aplikacji
- Mapowanie na tabele w bazie danych
- Walidacja danych

```csharp
// Przykład: Models/User.cs
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

#### **Views/**
- Szablony HTML z kodem Razor (`@` syntax)
- Wyświetlanie danych użytkownikowi
- Formularze do wprowadzania danych

```html
<!-- Przykład: Views/Home/Index.cshtml -->
@model List<User>
<h1>Użytkownicy</h1>
<ul>
    @foreach(var user in Model)
    {
        <li>@user.Name - @user.Email</li>
    }
</ul>
```

#### **wwwroot/**
- CSS, JavaScript, obrazy
- Pliki dostępne bezpośrednio z przeglądarki
- Bootstrap, jQuery itp.

#### **Data/**
- Entity Framework DbContext
- Repository pattern do dostępu do danych
- Migracje bazy danych

## 3. Tworzenie nowego projektu MVC

### 3.1 Utworzenie projektu z CLI

```bash
# Przejdź do katalogu, gdzie chcesz utworzyć projekt
cd C:\Users\Egzamin\Documents\GitHub\kkz87\pazw

# Utwórz nowy projekt ASP.NET MVC
dotnet new mvc -n MojaAplikacja -f net8.0
cd MojaAplikacja
```

Opcje:
- `-n` - nazwa projektu
- `-f` - framework (.NET 8.0, 7.0, 6.0 itp.)

### 3.2 Tworzenie projektu w VS Code z C# Dev Kit

1. **Otwórz paletę poleceń** (`Ctrl+Shift+P`)
2. **Wpisz** `C# Dev Kit: Create New Project`
3. **Wybierz** `ASP.NET Core MVC`
4. **Podaj nazwę** projektu i lokalizację
5. **Czekaj** aż projekt zostanie wygenerowany

## 4. Konfiguracja projektu

### 4.1 Program.cs - Rejestracja usług

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Dodanie MVC
builder.Services.AddControllersWithViews();

// Dodanie DbContext (Entity Framework)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();  // Obsługa plików ze wwwroot
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

### 4.2 appsettings.json - Połączenie z bazą danych

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=MojaAplikacjaDb;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```

## 5. Tworzenie komponentów MVC

### 5.1 Tworzenie Modelu

```bash
# Utwórz plik Models/Product.cs
```

```csharp
// Models/Product.cs
namespace MojaAplikacja.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
```

### 5.2 Tworzenie Kontrolera

```bash
# VS Code - Paletą poleceń (Ctrl+Shift+P)
# Wpisz: "C# Dev Kit: Create New Class"
# lub ręcznie utwórz Controllers/ProductController.cs
```

```csharp
// Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;
using MojaAplikacja.Models;

namespace MojaAplikacja.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
```

### 5.3 Tworzenie Widoku

```bash
# Utwórz strukturę Views/Product/
mkdir Views/Product
# Utwórz plik Views/Product/Index.cshtml
```

```html
<!-- Views/Product/Index.cshtml -->
@model List<Product>

@{
    ViewData["Title"] = "Produkty";
}

<div class="container">
    <h1>@ViewData["Title"]</h1>
    
    <p>
        <a asp-action="Create" class="btn btn-primary">Dodaj nowy produkt</a>
    </p>

    @if (Model.Count == 0)
    {
        <p>Brak produktów w bazie.</p>
    }
    else
    {
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Nazwa</th>
                    <th>Cena</th>
                    <th>Opis</th>
                    <th>Akcje</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var product in Model)
                {
                    <tr>
                        <td>@product.Name</td>
                        <td>@product.Price.ToString("C")</td>
                        <td>@product.Description</td>
                        <td>
                            <a asp-action="Details" asp-route-id="@product.Id" class="btn btn-sm btn-info">Szczegóły</a>
                            <a asp-action="Edit" asp-route-id="@product.Id" class="btn btn-sm btn-warning">Edytuj</a>
                            <a asp-action="Delete" asp-route-id="@product.Id" class="btn btn-sm btn-danger">Usuń</a>
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    }
</div>
```

## 6. Entity Framework - Praca z bazą danych

### 6.1 Utworzenie DbContext

```csharp
// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using MojaAplikacja.Models;

namespace MojaAplikacja.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja modeli
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(10, 2);
        }
    }
}
```

### 6.2 Dodanie migracji

```bash
# Wygenerowanie migracji początkowej
dotnet ef migrations add InitialCreate

# Zastosowanie migracji do bazy danych
dotnet ef database update
```

### 6.3 Rejestracja DbContext w Program.cs

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## 7. Praca z C# Dev Kit w VS Code

### 7.1 Uruchamianie aplikacji

**Metoda 1: Debugowanie z VS Code**
1. Otwórz plik `Program.cs`
2. Kliknij "Run" nad metodą `Main` lub `BuildWebHost`
3. VS Code uruchomi aplikację w trybie debugowania

**Metoda 2: Terminal**
```bash
dotnet run
# Aplikacja będzie dostępna na https://localhost:5001
```

**Metoda 3: C# Dev Kit**
1. Kliknij ikonę C# Dev Kit na pasku bocznym
2. Znajdź projekt w liście
3. Kliknij "Run" lub "Debug"

### 7.2 Debugowanie

- **Punkty przerwania**: Kliknij na numer linii w edytorze
- **Zmienne**: Podejrzyj wartości w panelu "Variables"
- **Console**: Wykonuj polecenia C# w konsoli debugera
- **Conditional Breakpoints**: Prawo-klik na punkt przerwania → "Add Conditional Breakpoint"

### 7.3 IntelliSense i Refactoring

- **Autocomplete**: `Ctrl+Space`
- **Rename Symbol**: `F2` lub prawo-klik → Rename
- **Go to Definition**: `F12` lub `Ctrl+Click`
- **Find All References**: `Shift+F12`
- **Quick Fix**: `Ctrl+.` - zobaczysz dostępne poprawki

## 8. Layout i Shared Views

### 8.1 _Layout.cshtml - Szablon główny

```html
<!-- Views/Shared/_Layout.cshtml -->
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Moja Aplikacja</title>
    
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="~/lib/bootstrap/bootstrap.min.css" />
    <!-- Custom CSS -->
    <link rel="stylesheet" href="~/css/style.css" />
</head>
<body>
    <!-- Nawigacja -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand" asp-controller="Home" asp-action="Index">Moja Aplikacja</a>
            <div class="collapse navbar-collapse">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a class="nav-link" asp-controller="Home" asp-action="Index">Strona główna</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" asp-controller="Product" asp-action="Index">Produkty</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" asp-controller="Home" asp-action="About">O nas</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Główna zawartość -->
    <main class="py-4">
        <div class="container">
            @RenderBody()
        </div>
    </main>

    <!-- Stopka -->
    <footer class="bg-dark text-white py-4">
        <div class="container text-center">
            <p>&copy; 2024 Moja Aplikacja. Wszystkie prawa zastrzeżone.</p>
        </div>
    </footer>

    <!-- Bootstrap JS -->
    <script src="~/lib/bootstrap/bootstrap.bundle.min.js"></script>
    <!-- Custom JS -->
    <script src="~/js/app.js"></script>
</body>
</html>
```

### 8.2 Powiązanie widoku z layoutem

```html
<!-- Views/Product/Index.cshtml -->
@{
    ViewData["Title"] = "Produkty";
    Layout = "_Layout";
}

<!-- Tutaj zawartość widoku -->
```

## 9. Routing w ASP.NET MVC

### 9.1 Domyślny routing (Program.cs)

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

**Znaczenie:**
- `{controller}` - nazwa kontrolera (bez "Controller")
- `{action}` - nazwa akcji (metody)
- `{id?}` - opcjonalny parametr
- Domyślnie: `HomeController` → `Index` akcja

### 9.2 Routing atrybutowy

```csharp
[Route("products")]
public class ProductController : Controller
{
    [Route("")]           // /products
    public IActionResult Index() { ... }

    [Route("{id}")]       // /products/5
    public IActionResult Details(int id) { ... }

    [Route("create")]     // /products/create
    public IActionResult Create() { ... }
}
```

## 10. Uruchomienie i testowanie

### 10.1 Uruchomienie aplikacji

```bash
cd C:\Users\Egzamin\Documents\GitHub\kkz87\pazw\MojaAplikacja
dotnet run
```

Powinieneś zobaczyć:
```
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started.
```

### 10.2 Dostęp do aplikacji

- Otwórz przeglądarkę
- Wejdź na `https://localhost:5001`

### 10.3 Testowanie kontrolerów

```bash
# GET - pobranie listy produktów
curl https://localhost:5001/api/products

# POST - utworzenie produktu
curl -X POST https://localhost:5001/api/products \
  -H "Content-Type: application/json" \
  -d '{"name":"Produkt","price":99.99}'
```

## 11. Checklist - Co powinniśmy mieć

- ✅ Projekt stworzony z szablonem MVC
- ✅ Struktura katalogów (Controllers, Models, Views, wwwroot)
- ✅ Zainstalowany C# Dev Kit
- ✅ Skonfigurowana baza danych (appsettings.json)
- ✅ DbContext zarejestrowany w Program.cs
- ✅ Co najmniej jeden Model, Kontroler i Widok
- ✅ _Layout.cshtml skonfigurowany
- ✅ Routing skonfigurowany
- ✅ Aplikacja uruchamia się bez błędów

## 12. Przydatne komendy

```bash
# Utworzenie projektu
dotnet new mvc -n MojaAplikacja

# Uruchomienie aplikacji
dotnet run

# Kompilacja
dotnet build

# Czyszczenie budów
dotnet clean

# Migracja bazy danych
dotnet ef migrations add MigrationName
dotnet ef database update

# Zainstalowanie pakietów
dotnet add package NazwaPakietu
```

## 13. Zasoby

- [Microsoft Learn - ASP.NET Core MVC](https://learn.microsoft.com/pl-pl/aspnet/core/mvc)
- [C# Dev Kit Documentation](https://github.com/microsoft/vscode-csharp)
- [Entity Framework Core](https://learn.microsoft.com/pl-pl/ef/core/)
- [Razor Syntax](https://learn.microsoft.com/pl-pl/aspnet/core/mvc/views/razor)

---

**Autor:** AI Assistant (Copilot SDK)  
**Data:** 2024  
**Wersja:** 1.0
