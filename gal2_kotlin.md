# Zmiana zdjęcia z `drawable` po naciśnięciu przycisku (Kotlin)

W tym przykładzie obrazy znajdują się w zasobach aplikacji, w folderze `res/drawable`. Po każdym naciśnięciu przycisku wyświetlane jest następne zdjęcie.

## 1. Dodaj pliki ze zdjęciami

Skopiuj obrazy do folderu `app/src/main/res/drawable`, na przykład:

```text
app/src/main/res/drawable/photo_one.jpg
app/src/main/res/drawable/photo_two.png
app/src/main/res/drawable/photo_three.webp
```

Nazwy plików zasobów mogą zawierać małe litery, cyfry i podkreślenia; nie używaj spacji ani wielkich liter. W kodzie Kotlin odwołuj się do nich przez `R.drawable.nazwa_pliku`, bez rozszerzenia.

## 2. Przygotuj widok

Dodaj `ImageView` oraz `Button` do `app/src/main/res/layout/activity_main.xml`. Jeśli plik ma już układ ekranu, umieść te elementy w jego istniejącym kontenerze.

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical"
    android:padding="16dp">

    <ImageView
        android:id="@+id/photoView"
        android:layout_width="match_parent"
        android:layout_height="0dp"
        android:layout_weight="1"
        android:contentDescription="Zdjęcie"
        android:scaleType="centerCrop" />

    <Button
        android:id="@+id/changePhotoButton"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text="Zmień zdjęcie" />
</LinearLayout>
```

## 3. Zmieniaj obraz w Kotlinie

W `MainActivity.kt` dodaj lub dopasuj poniższy kod. Zastąp nazwę pakietu własną. Jeżeli pliki mają inne nazwy, odpowiednio zmień elementy tablicy `images`.

```kotlin
package com.example.myapplication

import android.os.Bundle
import android.widget.Button
import android.widget.ImageView
import androidx.activity.ComponentActivity

class MainActivity : ComponentActivity() {
    private val images = intArrayOf(
        R.drawable.photo_one,
        R.drawable.photo_two,
        R.drawable.photo_three
    )
    private var currentImageIndex = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val photoView = findViewById<ImageView>(R.id.photoView)
        photoView.setImageResource(images[currentImageIndex])

        findViewById<Button>(R.id.changePhotoButton).setOnClickListener {
            currentImageIndex = (currentImageIndex + 1) % images.size
            photoView.setImageResource(images[currentImageIndex])
        }
    }
}
```

`images` przechowuje identyfikatory zdjęć z `drawable`. Indeks zwiększa się po kliknięciu, a operator `%` powoduje powrót do pierwszego zdjęcia po ostatnim. `setImageResource()` ustawia wybrany zasób w `ImageView` — nie trzeba odczytywać pliku z pamięci urządzenia ani prosić o uprawnienia do galerii.

## 4. Uruchom i sprawdź

Uruchom aplikację. Pierwsze zdjęcie pojawi się od razu, a każde naciśnięcie **Zmień zdjęcie** pokaże następny obraz. Po ostatnim zdjęciu cykl zacznie się ponownie od pierwszego.
