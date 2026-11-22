# AlertDialog w Androidzie i Kotlinie

`AlertDialog` to okno dialogowe wyświetlane nad bieżącym ekranem. Pozwala poprosić użytkownika o decyzję, pokazać komunikat lub zebrać niewielką ilość danych. Do dłuższych formularzy lepiej wykorzystać osobny ekran.

Poniższe przykłady dotyczą klasycznych widoków Androida (XML), nie Jetpack Compose. Używają `androidx.appcompat.app.AlertDialog` i aktywności dziedziczącej po `AppCompatActivity`. Projekt powinien mieć zależność AppCompat oraz motyw zgodny z AppCompat lub Material Components. Nie pomyl tej klasy z `android.app.AlertDialog` ani z komponentem `AlertDialog` w Compose.

## Podstawowy przykład: potwierdzenie

W `MainActivity.kt` dodaj import:

```kotlin
import androidx.appcompat.app.AlertDialog
```

Wewnątrz `MainActivity` umieść metodę:

```kotlin
private fun pokazPotwierdzenieUsuniecia() {
    AlertDialog.Builder(this)
        .setTitle("Usunąć element?")
        .setMessage("Tej operacji nie można cofnąć.")
        .setPositiveButton("Usuń") { _, _ ->
            // Tutaj wykonaj usunięcie.
        }
        .setNegativeButton("Anuluj") { _, _ ->
            // Użytkownik zrezygnował.
        }
        .show()
}
```

Wywołaj ją np. z obsługi przycisku w `onCreate()`:

```kotlin
findViewById<Button>(R.id.buttonDelete).setOnClickListener {
    pokazPotwierdzenieUsuniecia()
}
```

Przykład zakłada, że układ aktywności zawiera przycisk o identyfikatorze `buttonDelete` i został już ustawiony przez `setContentView(...)`. Dodaj import `android.widget.Button`.

`Builder(this)` otrzymuje kontekst aktywności. `setTitle()` i `setMessage()` ustawiają treść, a `show()` tworzy i wyświetla okno. Lambdy przycisków otrzymują obiekt dialogu i identyfikator przycisku; `_` oznacza, że w tym przykładzie nie są używane.

## Przyciski i zamykanie okna

| Metoda | Typowe zastosowanie |
| --- | --- |
| `setPositiveButton()` | Potwierdzenie, np. „Zapisz” lub „Usuń” |
| `setNegativeButton()` | Rezygnacja, np. „Anuluj” |
| `setNeutralButton()` | Dodatkowa akcja, np. „Później” |

Każdy z tych typów można ustawić najwyżej raz. Standardowo kliknięcie przycisku zamyka okno po wywołaniu jego obsługi. Przycisk negatywny nie jest tym samym co anulowanie dialogu przez system: jego kliknięcie domyślnie zamyka okno, ale nie wywołuje `OnCancelListener`.

Użytkownik może też zwykle anulować dialog przyciskiem Wstecz lub dotknięciem poza oknem. `setOnCancelListener` reaguje na anulowanie, natomiast `setOnDismissListener` na każde zamknięcie, także po kliknięciu przycisku. `setCancelable(false)` blokuje anulowanie przyciskiem Wstecz i dotknięciem poza oknem; nadal zapewnij wtedy widoczny sposób zamknięcia dialogu.

W rzeczywistej aplikacji teksty przenieś do `res/values/strings.xml` i przekazuj identyfikatory zasobów, np. `.setTitle(R.string.delete_title)`. Ułatwia to tłumaczenie i utrzymanie aplikacji.

## Lista wyboru

`setItems()` wyświetla listę i automatycznie zamyka dialog po wybraniu pozycji:

```kotlin
private fun pokazKolory() {
    val kolory = arrayOf("Czerwony", "Zielony", "Niebieski")

    AlertDialog.Builder(this)
        .setTitle("Wybierz kolor")
        .setItems(kolory) { _, indeks ->
            val wybranyKolor = kolory[indeks]
            // Tutaj użyj wybranego koloru.
        }
        .setNegativeButton("Anuluj", null)
        .show()
}
```

Gdy wybór ma być zatwierdzony osobnym przyciskiem, użyj `setSingleChoiceItems()`:

```kotlin
private fun pokazWyborKoloru() {
    val kolory = arrayOf("Czerwony", "Zielony", "Niebieski")
    var wybranyIndeks = 0

    AlertDialog.Builder(this)
        .setTitle("Wybierz kolor")
        .setSingleChoiceItems(kolory, wybranyIndeks) { _, indeks ->
            wybranyIndeks = indeks
        }
        .setPositiveButton("OK") { _, _ ->
            val wybranyKolor = kolory[wybranyIndeks]
            // Tutaj użyj zatwierdzonego koloru.
        }
        .setNegativeButton("Anuluj", null)
        .show()
}
```

Pozycje w `setSingleChoiceItems()` nie zamykają okna po wybraniu. Dla wielu opcji dostępna jest metoda `setMultiChoiceItems()`; w obu przypadkach zadbaj o zapis stanu wyboru, jeżeli ma przetrwać odtworzenie ekranu.

## Własny widok i walidacja

Metoda `setView()` pozwala umieścić w oknie własny widok, np. pole tekstowe. Domyślna obsługa przycisku zamyka dialog nawet wtedy, gdy dane są niepoprawne. Aby pozostawić okno otwarte po błędzie, ustaw własny listener **po** wyświetleniu dialogu:

```kotlin
import android.text.InputType
import android.widget.EditText
import androidx.appcompat.app.AlertDialog
```

```kotlin
private fun pokazPoleNazwy() {
    val pole = EditText(this).apply {
        hint = "Nazwa"
        inputType = InputType.TYPE_CLASS_TEXT
    }

    val dialog = AlertDialog.Builder(this)
        .setTitle("Podaj nazwę")
        .setView(pole)
        .setPositiveButton("Zapisz", null)
        .setNegativeButton("Anuluj", null)
        .create()

    dialog.setOnShowListener {
        dialog.getButton(AlertDialog.BUTTON_POSITIVE).setOnClickListener {
            val nazwa = pole.text.toString().trim()
            if (nazwa.isEmpty()) {
                pole.error = "Podaj nazwę"
            } else {
                // Tutaj zapisz poprawną nazwę.
                dialog.dismiss()
            }
        }
    }
    dialog.show()
}
```

`create()` tworzy dialog bez wyświetlania. W `setOnShowListener` przycisk już istnieje, więc można zastąpić jego listener i samodzielnie zdecydować, kiedy wywołać `dismiss()`. Dla bardziej rozbudowanego układu można zamiast pojedynczego pola przekazać do `setView()` widok utworzony z pliku XML.

## Cykl życia i dobre praktyki

- Twórz dialog przy użyciu kontekstu aktualnej aktywności, nie kontekstu aplikacji. Nie przechowuj aktywności ani dialogu w obiektach o dłuższym cyklu życia, np. w polach statycznych.
- Zmiana konfiguracji, np. obrót ekranu, może odtworzyć aktywność. Dialog utworzony bezpośrednio przez `Builder` nie odtwarza się sam wraz z nową aktywnością. Do dialogów, których stan i widoczność mają być zarządzane wraz z cyklem życia, rozważ `DialogFragment` z AndroidX i zachowuj istotny stan osobno.
- Nie pokazuj dialogu, jeśli aktywność jest kończona lub niszczona. Nie wykonuj długich operacji w obsłudze przycisku na wątku głównym.
- Stosuj jasne etykiety działań, szczególnie przy operacjach nieodwracalnych. Nie blokuj anulowania bez uzasadnionej potrzeby.

## Dokumentacja

- [Okna dialogowe w Androidzie](https://developer.android.com/develop/ui/views/components/dialogs)
- [AlertDialog.Builder (AndroidX)](https://developer.android.com/reference/androidx/appcompat/app/AlertDialog.Builder)
