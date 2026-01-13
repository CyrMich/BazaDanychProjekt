Autor: Michał Cyran Technologia ASP.NET Core MVC

1. Wymagania systemowe
   - System operacyjny: Windows 10/11 (rekomendowany).
   - Środowisko programistyczne: Visual Studio 2022 (z zainstalowanym workloadem "ASP.NET and web development").
   - Platforma: .NET SDK 9.0.
   - Baza danych: Microsoft SQL Server Express LocalDB (instalowana domyślnie z Visual Studio).

2. Instrukcja instalacji i uruchomienia.
   - Pobierz repozytorium projektu z GitHub lub rozpakuj dostarczone archiwum ZIP.
   - Uruchom plik rozwiązania Projekt.sln w Visual Studio.
   - Inicjalizacja Bazy Danych: Otwórz konsolę: Narzędzia (Tools) -> Konsola menedżera pakietów. Następnie wpisz polecenie: Update-Database. System automatycznie utworzy bazę danych oraz tabele na podstawie migracji.
   - Uruchom aplikację przyciskiem "Start" lub klawiszem F5.

3. Konfiguracja
   - Aplikacja korzysta z domyślnego połączenia do lokalnej bazy danych (LocalDB). Łańcuch połączenia znajduje się w pliku appsettings.json.

4. Testowi Użytkownicy
   - Konto Administratora. Login: admin@admin.pl Hasło: !Admin123. Uprawnienia: wszystkie.
   - Konto przykładowe można założyć swoje poprzez link "Zarejestruj" w prawym górnym rogu. Uprawnienia: Tylko odczyt danych, brak dostępu do klucz edycji i usuwania.

Opis działania aplikacji:

System służy do zarządzania systemem rezerwacji samochodów.

Główne moduły:

Samochody: Wyświetla listę dostępnych samochodów wraz z marką, modelem, rokiem produkcji, ceną za dzień oraz kategorią. Administrator ma możliwość dodawania, edycji i usuwania samochodów. Zwykły użytkownik ma dostęp wyłącznie do podglądu danych.
Kategorie samochodów: Umożliwia zarządzanie kategoriami pojazdów (np. Sedan, SUV). Kategorie są wykorzystywane przy tworzeniu i edycji samochodów.
Rezerwacje: Pozwala zalogowanym użytkownikom na tworzenie rezerwacji samochodów poprzez wybór pojazdu oraz zakresu dat. System automatycznie przypisuje rezerwację do zalogowanego użytkownika oraz blokuje możliwość rezerwacji samochodu, który jest już zajęty w wybranym terminie.
Bezpieczeństwo i role: Zastosowano ASP.NET Core Identity. System blokuje dostęp do tworzenia rezerwacji dla niezalogowanych użytkowników. Funkcje administracyjne (dodawanie, edycja i usuwanie danych) dostępne są wyłącznie dla administratora.
API: Aplikacja udostępnia API CRUD dla głównej encji systemu (samochodów), umożliwiające komunikację z zewnętrznymi systemami w formacie JSON.
