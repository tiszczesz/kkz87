# Jak utworzyć projekt konsolowy z użyciem .NET CLI i otworzyć go w VS Code

- Otwórz terminal / wiersz poleceń.
- Przejdź do folderu, w którym chcesz utworzyć projekt.
- Wpisz polecenie, aby utworzyć nowy projekt konsolowy:
  ```bash
  dotnet new console -n NazwaProjektu
  ```
- Przejdź do utworzonego katalogu projektu:
  ```bash
  cd NazwaProjektu
  ```
- Otwórz projekt w Visual Studio Code:
  ```bash
  code .
  ```
- Jeśli VS Code nie otwiera się z poziomu terminala, upewnij się, że polecenie `code` jest dostępne w systemie.
- Po otwarciu projektu możesz uruchomić aplikację poleceniem:
  ```bash
  dotnet run
  ```
- Domyślny plik programu znajduje się zwykle w `Program.cs`.
- Możesz tam edytować kod i od razu testować zmiany przez `dotnet run`.
