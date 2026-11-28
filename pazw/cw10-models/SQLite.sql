-- SQLite
CREATE TABLE Students(
  id Integer ,
  firstname VARCHAR(50),
  lastname VARCHAR(50),
  age Integer
  );

INSERT INTO Students (id, firstname, lastname, age) VALUES
  (1, 'Jan', 'Kowalski', 20),
  (2, 'Anna', 'Nowak', 22),
  (3, 'Piotr', 'Wiśniewski', 21),
  (4, 'Maria', 'Wójcik', 19),
  (5, 'Krzysztof', 'Kozłowski', 23),
  (6, 'Katarzyna', 'Jankowska', 20),
  (7, 'Tomasz', 'Mazur', 24),
  (8, 'Magdalena', 'Krawczyk', 21),
  (9, 'Paweł', 'Piotrowski', 22),
  (10, 'Aleksandra', 'Grabowska', 19);

