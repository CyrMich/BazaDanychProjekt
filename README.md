Autor: Michał Cyran Technologia ASP.NET Core MVC

1. Wymagania systemowe
   - System operacyjny: Windows 10/11 (rekomendowany).
   - Środowisko programistyczne: Visual Studio 2022 (z zainstalowanym workloadem "ASP.NET and web development").
   - Platforma: .NET SDK 9.0.
   - Baza danych: Microsoft SQL Server Express LocalDB (instalowana domyślnie z Visual Studio).

2. Instrukcja instalacji i uruchomienia.
   - Pobierz repozytorium projektu z GitHub lub rozpakuj dostarczone archiwum ZIP.
   - Uruchom plik rozwiązania Projekt.sln w Visual Studio.
   - Inicjalizacja Bazy Danych: Otwórz konsolę: Narzędzia (Tools) - Menedżer pakietów NuGet - Konsola menedżera pakietów. Wpisz polecenie: Update-Database. System automatycznie utworzy bazę danych oraz tabele na podstawie migracji.
   - Uruchom aplikację przyciskiem "Start" lub klawiszem F5.

3. Konfiguracja
   - Aplikacja korzysta z domyślnego połączenia do lokalnej bazy danych (LocalDB). Łańcuch połączenia znajduje się w pliku appsettings.json

4. Testowi Użytkownicy
   - Konto Administratora (Pełne uprawnienia) Login: admin@admin.pl Hasło: !Admin123. Uprawnienia: wszystkie
   - Konto przykładowe można założyć swoje poprzez link "Zarejestruj" w prawym górnym rogu. Uprawnienia: Tylko odczyt danych, brak dostępu do klucz edycji i usuwania

Opis działania aplikacji
System służy do zarządzania systemem rezerwacji samochodów.

Główne moduły:

Dashboard (Statystyki) Prezentuje kluczowe wskaźniki agencji: liczbę pracowników, aktywnych umów oraz liczbę klientów
Moduł Pracownicy: Wyświetla listę zatrudnionych osób Pozwala na filtrowanie listy po nazwisku i imieniu CRUD - Administrator może dodawać edytować i usuwać pracowników. Zwykły użytkownik ma dostęp tylko do podglądu. Podczas dodawania pracownika system wymusza przypisanie mu pierwszej umowy
Moduł Umowy i Klienci Pozwala na wyświetlanie wszystkich umów aby kontrolować czy się nie przedawniły Zarządzanie bazą klientów
Bezpieczeństwo i Role Zastosowano ASP.NET Core Identity System blokuje dostęp do danych dla niezalogowanych użytkowników Przyciski funkcyjne "Edytuj" i "Usuń" są ukrywane dla osób bez Administratora
API Aplikacja wystawia dane w formacie JSON pod adresem /api/PracownicyApi co umożliwia integracje z zewnętrznymi systemami
