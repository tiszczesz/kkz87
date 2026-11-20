# RecyclerView: lista zadań Todo w Kotlinie

W tym przykładzie utworzymy przewijaną listę zadań w `Activity` przy użyciu klasycznych widoków Androida (XML), bez Jetpack Compose. Każde zadanie ma identyfikator, treść, informację o wykonaniu i datę realizacji. Zaznaczenie pola zmieni stan zadania w pamięci.

## 1. Utwórz projekt

W Android Studio utwórz projekt **Empty Views Activity** z językiem Kotlin i **Minimum SDK 26** lub wyższym. Przykład używa `LocalDate`, dostępnego od API 26. Możesz też dodać ten kod do istniejącego projektu z `AppCompatActivity`.

W przykładach używamy pakietu `com.example.todolist`. Zastąp go nazwą pakietu swojego projektu w plikach Kotlin. Pliki `Todo.kt` i `TodoAdapter.kt` umieść w tym samym pakiecie co `MainActivity.kt`.

## 2. Dodaj bibliotekę RecyclerView

W pliku modułu aplikacji `app/build.gradle.kts` dopisz zależność do istniejącego bloku `dependencies`:

```kotlin
implementation("androidx.recyclerview:recyclerview:1.3.2")
```

Wybierz **Sync Now**. Nie twórz drugiego bloku `dependencies`, jeśli już istnieje.

## 3. Utwórz model zadania

Dodaj plik `Todo.kt`:

```kotlin
package com.example.todolist

import java.time.LocalDate

data class Todo(
    val id: Int,
    val content: String,
    var isDone: Boolean,
    val dateRealize: LocalDate
)
```

`id` powinno być unikalne dla każdego zadania. `isDone` jest zmienne, ponieważ użytkownik może zaznaczyć lub odznaczyć zadanie.

## 4. Dodaj napisy

W istniejącym pliku `app/src/main/res/values/strings.xml` dodaj poniższe elementy wewnątrz `<resources>`:

```xml
<string name="todo_date">Data realizacji: %1$s</string>
<string name="todo_done">Wykonane</string>
```

## 5. Przygotuj widok pojedynczego wiersza

Utwórz plik `app/src/main/res/layout/item_todo.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:orientation="vertical"
    android:padding="16dp">

    <TextView
        android:id="@+id/textContent"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:textSize="18sp" />

    <TextView
        android:id="@+id/textDate"
        android:layout_width="match_parent"
        android:layout_height="wrap_content" />

    <CheckBox
        android:id="@+id/checkDone"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="@string/todo_done" />
</LinearLayout>
```

Ten układ opisuje **jeden** element listy, a nie cały ekran.

## 6. Dodaj RecyclerView do ekranu

Zastąp zawartość `app/src/main/res/layout/activity_main.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<androidx.recyclerview.widget.RecyclerView
    xmlns:android="http://schemas.android.com/apk/res/android"
    android:id="@+id/recyclerTodos"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:clipToPadding="false"
    android:padding="8dp" />
```

## 7. Utwórz adapter

Dodaj plik `TodoAdapter.kt`:

```kotlin
package com.example.todolist

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import java.time.format.DateTimeFormatter

class TodoAdapter(
    private val todos: List<Todo>
) : RecyclerView.Adapter<TodoAdapter.TodoViewHolder>() {

    private val dateFormatter = DateTimeFormatter.ofPattern("dd.MM.yyyy")

    class TodoViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val textContent: TextView = itemView.findViewById(R.id.textContent)
        val textDate: TextView = itemView.findViewById(R.id.textDate)
        val checkDone: CheckBox = itemView.findViewById(R.id.checkDone)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TodoViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_todo, parent, false)
        return TodoViewHolder(view)
    }

    override fun onBindViewHolder(holder: TodoViewHolder, position: Int) {
        val todo = todos[position]
        holder.textContent.text = todo.content
        holder.textDate.text = holder.itemView.context.getString(
            R.string.todo_date,
            todo.dateRealize.format(dateFormatter)
        )

        holder.checkDone.setOnCheckedChangeListener(null)
        holder.checkDone.isChecked = todo.isDone
        holder.checkDone.setOnCheckedChangeListener { _, isChecked ->
            todo.isDone = isChecked
        }
    }

    override fun getItemCount(): Int = todos.size
}
```

- `onCreateViewHolder()` tworzy widok wiersza, gdy jest potrzebny.
- `onBindViewHolder()` wypełnia wiersz danymi zadania. Wiersze są ponownie wykorzystywane podczas przewijania, dlatego za każdym razem ustawiamy wszystkie pola.
- Przed ustawieniem checkboxa usuwamy poprzedni listener, aby programowe ustawienie stanu nie zmieniło wcześniej przypisanego zadania. Następnie listener aktualizuje aktualnie powiązany obiekt.
- `getItemCount()` zwraca liczbę elementów listy.

## 8. Podłącz dane w Activity

Zastąp zawartość `MainActivity.kt`:

```kotlin
package com.example.todolist

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import java.time.LocalDate

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val todos = mutableListOf(
            Todo(1, "Kupić mleko", false, LocalDate.of(2026, 12, 1)),
            Todo(2, "Przygotować prezentację", true, LocalDate.of(2026, 12, 5)),
            Todo(3, "Oddać książkę", false, LocalDate.of(2026, 12, 10))
        )

        val recyclerView = findViewById<RecyclerView>(R.id.recyclerTodos)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = TodoAdapter(todos)
    }
}
```

`LinearLayoutManager` układa zadania pionowo. Adapter łączy listę obiektów z widokami wierszy.

## 9. Uruchom i sprawdź

Uruchom aplikację na emulatorze lub urządzeniu z Androidem 8.0 (API 26) albo nowszym. Powinny pojawić się trzy zadania z datami i polami wyboru. Zaznacz zadanie; po przewinięciu poza ekran i powrocie jego stan powinien pozostać widoczny. Aby łatwiej sprawdzić przewijanie, dodaj więcej obiektów do listy, używając różnych `id`.

Stan w tym przykładzie istnieje tylko w pamięci: po odtworzeniu `Activity`, np. podczas obrotu ekranu, lista zostanie utworzona ponownie, a zmiany znikną. W rzeczywistej aplikacji przechowuj zadania np. w bazie Room i udostępniaj je przez `ViewModel`.

## 10. Aktualizacja listy

Jeśli później dodasz zadanie do istniejącej listy, poinformuj adapter o nowym wierszu. Przykładowo, w `onCreate()` zachowaj adapter w zmiennej i użyj jej również do przypisania go do `RecyclerView`:

```kotlin
val adapter = TodoAdapter(todos)
recyclerView.adapter = adapter

todos.add(Todo(4, "Wysłać wiadomość", false, LocalDate.of(2026, 12, 12)))
adapter.notifyItemInserted(todos.lastIndex)
```

Ten fragment zastępuje wcześniejszą linię `recyclerView.adapter = TodoAdapter(todos)` i dodaje element od razu; w praktyce operacje te można wywołać w odpowiedzi na działanie użytkownika. Jeśli zmieniasz dane zadania poza adapterem, powiadom go o odpowiednim wierszu przez `notifyItemChanged(index)`. Zmiany listy i powiadomienia wykonuj na głównym wątku.
