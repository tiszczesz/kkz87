# RecyclerView: lista zadań Todo w Kotlinie

W tym przykładzie utworzymy przewijaną listę zadań w `Activity` przy użyciu klasycznych widoków Androida (XML), bez Jetpack Compose. Każde zadanie ma identyfikator, treść, informację o wykonaniu i datę realizacji. Zadania można dodawać, edytować i usuwać, a także zmieniać ich stan wykonania. Wszystkie zmiany są przechowywane tylko w pamięci.

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
<string name="todo_add">Dodaj zadanie</string>
<string name="todo_edit">Edytuj zadanie</string>
<string name="todo_content_hint">Treść zadania</string>
<string name="todo_date_hint">Data realizacji (RRRR-MM-DD)</string>
<string name="todo_content_required">Podaj treść zadania</string>
<string name="todo_date_invalid">Podaj poprawną datę w formacie RRRR-MM-DD</string>
<string name="todo_save">Zapisz</string>
<string name="todo_cancel">Anuluj</string>
<string name="todo_delete">Usuń</string>
<string name="todo_delete_title">Usunąć zadanie?</string>
<string name="todo_delete_message">Czy na pewno usunąć zadanie: %1$s?</string>
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
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical">

    <Button
        android:id="@+id/buttonAddTodo"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text="@string/todo_add" />

    <androidx.recyclerview.widget.RecyclerView
        android:id="@+id/recyclerTodos"
        android:layout_width="match_parent"
        android:layout_height="0dp"
        android:layout_weight="1"
        android:clipToPadding="false"
        android:padding="8dp" />
</LinearLayout>
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
    private val todos: List<Todo>,
    private val onEdit: (Int) -> Unit,
    private val onDelete: (Int) -> Unit
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

        holder.itemView.setOnClickListener {
            val currentPosition = holder.bindingAdapterPosition
            if (currentPosition != RecyclerView.NO_POSITION) onEdit(currentPosition)
        }
        holder.itemView.setOnLongClickListener {
            val currentPosition = holder.bindingAdapterPosition
            if (currentPosition != RecyclerView.NO_POSITION) {
                onDelete(currentPosition)
                true
            } else {
                false
            }
        }
    }

    override fun getItemCount(): Int = todos.size
}
```

- `onCreateViewHolder()` tworzy widok wiersza, gdy jest potrzebny.
- `onBindViewHolder()` wypełnia wiersz danymi zadania. Wiersze są ponownie wykorzystywane podczas przewijania, dlatego za każdym razem ustawiamy wszystkie pola.
- Przed ustawieniem checkboxa usuwamy poprzedni listener, aby programowe ustawienie stanu nie zmieniło wcześniej przypisanego zadania. Następnie listener aktualizuje aktualnie powiązany obiekt.
- Kliknięcie wiersza wywołuje edycję, a długie przytrzymanie rozpoczyna usuwanie. `bindingAdapterPosition` sprawdza aktualną pozycję wiersza, która może się zmienić po usunięciu elementu.
- `getItemCount()` zwraca liczbę elementów listy.

## 8. Podłącz dane w Activity

Zastąp zawartość `MainActivity.kt`:

```kotlin
package com.example.todolist

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.LinearLayout
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import java.time.LocalDate
import java.time.format.DateTimeParseException

class MainActivity : AppCompatActivity() {
    private val todos = mutableListOf(
        Todo(1, "Kupić mleko", false, LocalDate.of(2026, 12, 1)),
        Todo(2, "Przygotować prezentację", true, LocalDate.of(2026, 12, 5)),
        Todo(3, "Oddać książkę", false, LocalDate.of(2026, 12, 10))
    )
    private var nextId = 4
    private lateinit var adapter: TodoAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val recyclerView = findViewById<RecyclerView>(R.id.recyclerTodos)
        recyclerView.layoutManager = LinearLayoutManager(this)
        adapter = TodoAdapter(todos, ::editTodo, ::confirmDeleteTodo)
        recyclerView.adapter = adapter

        findViewById<Button>(R.id.buttonAddTodo).setOnClickListener {
            showTodoDialog()
        }
    }

    private fun editTodo(position: Int) {
        showTodoDialog(position)
    }

    private fun showTodoDialog(position: Int? = null) {
        val todo = position?.let { todos[it] }
        val contentInput = EditText(this).apply {
            setHint(R.string.todo_content_hint)
            setSingleLine()
            setText(todo?.content ?: "")
        }
        val dateInput = EditText(this).apply {
            setHint(R.string.todo_date_hint)
            setSingleLine()
            setText((todo?.dateRealize ?: LocalDate.now()).toString())
        }
        val padding = (16 * resources.displayMetrics.density).toInt()
        val fields = LinearLayout(this).apply {
            orientation = LinearLayout.VERTICAL
            setPadding(padding, 0, padding, 0)
            addView(contentInput)
            addView(dateInput)
        }

        val dialog = AlertDialog.Builder(this)
            .setTitle(if (todo == null) R.string.todo_add else R.string.todo_edit)
            .setView(fields)
            .setPositiveButton(R.string.todo_save, null)
            .setNegativeButton(R.string.todo_cancel, null)
            .create()

        dialog.setOnShowListener {
            dialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener {
                val content = contentInput.text.toString().trim()
                if (content.isEmpty()) {
                    contentInput.error = getString(R.string.todo_content_required)
                    return@setOnClickListener
                }
                val date = try {
                    LocalDate.parse(dateInput.text.toString().trim())
                } catch (exception: DateTimeParseException) {
                    dateInput.error = getString(R.string.todo_date_invalid)
                    return@setOnClickListener
                }

                if (todo == null) {
                    todos.add(Todo(nextId++, content, false, date))
                    adapter.notifyItemInserted(todos.lastIndex)
                } else {
                    val currentPosition = todos.indexOfFirst { it.id == todo.id }
                    check(currentPosition != -1)
                    todos[currentPosition] = todo.copy(content = content, dateRealize = date)
                    adapter.notifyItemChanged(currentPosition)
                }
                dialog.dismiss()
            }
        }
        dialog.show()
    }

    private fun confirmDeleteTodo(position: Int) {
        val todo = todos[position]
        AlertDialog.Builder(this)
            .setTitle(R.string.todo_delete_title)
            .setMessage(getString(R.string.todo_delete_message, todo.content))
            .setPositiveButton(R.string.todo_delete) { _, _ ->
                val currentPosition = todos.indexOfFirst { it.id == todo.id }
                check(currentPosition != -1)
                todos.removeAt(currentPosition)
                adapter.notifyItemRemoved(currentPosition)
            }
            .setNegativeButton(R.string.todo_cancel, null)
            .show()
    }
}
```

`LinearLayoutManager` układa zadania pionowo. Adapter łączy listę obiektów z widokami wierszy. Formularz sprawdza, czy treść nie jest pusta i czy data ma format `RRRR-MM-DD`. Edycja zachowuje identyfikator i stan wykonania zadania. Po dodaniu, zmianie lub usunięciu elementu wywoływane jest odpowiednio `notifyItemInserted`, `notifyItemChanged` lub `notifyItemRemoved`. Operacje na liście i powiadomienia adaptera wykonujemy na głównym wątku.

## 9. Uruchom i sprawdź

Uruchom aplikację na emulatorze lub urządzeniu z Androidem 8.0 (API 26) albo nowszym. Powinny pojawić się trzy zadania z datami i polami wyboru. Dodaj zadanie przyciskiem, kliknij wiersz, aby zmienić jego treść lub datę, a następnie przytrzymaj wiersz, aby potwierdzić jego usunięcie. Sprawdź również, że pusta treść i niepoprawna data nie zostaną zapisane oraz że edycja zachowuje stan checkboxa. Zaznacz zadanie; po przewinięciu poza ekran i powrocie jego stan powinien pozostać widoczny.

Stan w tym przykładzie istnieje tylko w pamięci: po odtworzeniu `Activity`, np. podczas obrotu ekranu, lista zostanie utworzona ponownie, a zmiany znikną. W rzeczywistej aplikacji przechowuj zadania np. w bazie Room i udostępniaj je przez `ViewModel`.
