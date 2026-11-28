## Dodaj  w nowym kontrolerze Deps stronę pobierającą wszystkie wydziały z tabelki Departments(id,name,description)

```sql
CREATE TABLE Departments (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT
);

INSERT INTO Departments (id, name, description) VALUES
    (1, 'Administracja', 'Obsługa spraw administracyjnych i organizacyjnych'),
    (2, 'Finanse', 'Zarządzanie budżetem i finansami'),
    (3, 'Marketing', 'Promocja i działania marketingowe'),
    (4, 'Sprzedaż', 'Obsługa klientów i sprzedaż produktów'),
    (5, 'Kadry', 'Zarządzanie personelem i dokumentacją pracowniczą'),
    (6, 'IT', 'Administracja systemami i wsparcie techniczne'),
    (7, 'Produkcja', 'Planowanie i realizacja produkcji'),
    (8, 'Logistyka', 'Magazynowanie i organizacja dostaw'),
    (9, 'Obsługa klienta', 'Pomoc i kontakt z klientami'),
    (10, 'Badania i rozwój', 'Prowadzenie badań oraz rozwój nowych produktów');
```