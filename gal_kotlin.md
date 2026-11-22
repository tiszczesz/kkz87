# Losowe zdjęcie z galerii w Androidzie (Kotlin)

Poniższy przykład wybiera losowo jedno ze zdjęć, do których aplikacja ma dostęp, i wyświetla je w `ImageView`. Ponieważ aplikacja sama przegląda kolekcję zdjęć, potrzebuje uprawnienia do odczytu obrazów. Użytkownik może odmówić dostępu; aplikacja powinna wtedy działać bez tej funkcji. Jeśli aplikacja ma pozwolić użytkownikowi wskazać pojedyncze zdjęcie, zamiast losować z całej kolekcji, użyj Android Photo Pickera.

## 1. Dodaj uprawnienia

W pliku `app/src/main/AndroidManifest.xml`, bezpośrednio wewnątrz `<manifest>` (przed `<application>`), dodaj:

```xml
<uses-permission
    android:name="android.permission.READ_EXTERNAL_STORAGE"
    android:maxSdkVersion="32" />
<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
```

`READ_EXTERNAL_STORAGE` jest używane na Androidzie 12L (API 32) i starszym, a `READ_MEDIA_IMAGES` na Androidzie 13 (API 33) i nowszym. Aplikacja musi też poprosić użytkownika o odpowiednie uprawnienie w czasie działania.

## 2. Przygotuj widok

W pliku `app/src/main/res/layout/activity_main.xml` umieść `ImageView` oraz przycisk. Jeśli układ zawiera już inne widoki, dodaj te elementy do istniejącego kontenera zamiast zastępować cały plik.

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
        android:contentDescription="Losowe zdjęcie z galerii"
        android:scaleType="centerCrop" />

    <Button
        android:id="@+id/randomPhotoButton"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:text="Pokaż losowe zdjęcie" />
</LinearLayout>
```

## 3. Odczytaj zdjęcia i ustaw losowe

W `MainActivity.kt` dodaj lub dopasuj poniższy kod. Zastąp nazwę pakietu własną. Przykład zakłada, że projekt używa `ComponentActivity` i układu `activity_main.xml`.

```kotlin
package com.example.myapplication

import android.content.ContentUris
import android.content.pm.PackageManager
import android.net.Uri
import android.os.Build
import android.os.Bundle
import android.provider.MediaStore
import android.widget.Button
import android.widget.ImageView
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.activity.result.contract.ActivityResultContracts

class MainActivity : ComponentActivity() {
    private lateinit var photoView: ImageView

    private val requestPermission = registerForActivityResult(
        ActivityResultContracts.RequestPermission()
    ) { granted ->
        if (granted) {
            showRandomPhoto()
        } else {
            Toast.makeText(this, "Brak uprawnienia do odczytu zdjęć", Toast.LENGTH_SHORT).show()
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        photoView = findViewById(R.id.photoView)
        findViewById<Button>(R.id.randomPhotoButton).setOnClickListener {
            loadRandomPhoto()
        }
    }

    private fun loadRandomPhoto() {
        val permission = if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
            "android.permission.READ_MEDIA_IMAGES"
        } else {
            "android.permission.READ_EXTERNAL_STORAGE"
        }

        if (checkSelfPermission(permission) == PackageManager.PERMISSION_GRANTED) {
            showRandomPhoto()
        } else {
            requestPermission.launch(permission)
        }
    }

    private fun showRandomPhoto() {
        val collection = MediaStore.Images.Media.EXTERNAL_CONTENT_URI
        val projection = arrayOf(MediaStore.Images.Media._ID)
        val photoUris = mutableListOf<Uri>()

        contentResolver.query(collection, projection, null, null, null)?.use { cursor ->
            val idColumn = cursor.getColumnIndexOrThrow(MediaStore.Images.Media._ID)
            while (cursor.moveToNext()) {
                val id = cursor.getLong(idColumn)
                photoUris.add(ContentUris.withAppendedId(collection, id))
            }
        } ?: run {
            Toast.makeText(this, "Nie udało się odczytać zdjęć", Toast.LENGTH_SHORT).show()
            return
        }

        val randomPhoto = photoUris.randomOrNull()
        if (randomPhoto == null) {
            Toast.makeText(this, "Nie znaleziono dostępnych zdjęć", Toast.LENGTH_SHORT).show()
            return
        }

        photoView.setImageURI(randomPhoto)
    }
}
```

Po kliknięciu przycisku aplikacja prosi o zgodę, jeśli nie ma jeszcze uprawnienia. Po jej przyznaniu `MediaStore` zwraca identyfikatory dostępnych zdjęć, a `randomOrNull()` wybiera jedno z nich. `setImageURI()` zmienia obraz wyświetlany przez `ImageView`; obraz nie jest kopiowany do aplikacji.

W nowszych wersjach Androida użytkownik może ograniczyć dostęp do wybranych zdjęć. W takim przypadku losowanie odbywa się tylko wśród zdjęć dostępnych dla aplikacji. Jeśli potrzebujesz jedynie zdjęcia wskazanego przez użytkownika, użyj Photo Pickera — nie wymaga on uprawnienia do przeglądania całej galerii.

## 4. Uruchom i sprawdź

Uruchom aplikację na urządzeniu lub emulatorze zawierającym zdjęcia. Kliknij **Pokaż losowe zdjęcie** i przyznaj dostęp, gdy Android o to poprosi. Kolejne kliknięcie losuje następne zdjęcie. Jeśli kolekcja jest pusta albo użytkownik odmówi dostępu, aplikacja wyświetli komunikat zamiast kończyć działanie błędem.
