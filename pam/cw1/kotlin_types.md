# Typy Danych w Kotlin - Przewodnik

## Spis treści
1. [Wprowadzenie](#wprowadzenie)
2. [Typy Podstawowe](#typy-podstawowe)
3. [Typy Liczbowe](#typy-liczbowe)
4. [Typ String](#typ-string)
5. [Typ Boolean](#typ-boolean)
6. [Typ Char](#typ-char)
7. [Kolekcje](#kolekcje)
8. [Typy Nullable](#typy-nullable)
9. [Any i Nothing](#any-i-nothing)
10. [Konwersje Typów](#konwersje-typów)

---

## Wprowadzenie

Kotlin jest językiem **silnie typowanym**. Kompilator Kotlin jest inteligentny i potrafi samodzielnie określić typ zmiennej na podstawie przypisanej wartości (type inference). Mimo to, możemy również jawnie deklarować typy.

```kotlin
val x = 5                    // Type inference - Kotlin wnioskuje, że x to Int
val y: Int = 10             // Jawna deklaracja typu
val name: String = "Kotlin" // Jawna deklaracja typu
```

---

## Typy Podstawowe

W Kotlin każdy typ jest obiektem (w przeciwieństwie do Javy). Nie istnieją "typy pierwotne" w sensie Javy.

### Hierarchia Typów

```
Any
├── Number
│   ├── Byte
│   ├── Short
│   ├── Int
│   ├── Long
│   ├── Float
│   └── Double
├── Char
├── Boolean
└── String
```

---

## Typy Liczbowe

### Int (Liczby całkowite 32-bitowe)

Domyślny typ dla liczb całkowitych.

```kotlin
val age: Int = 43
val maxInt: Int = Int.MAX_VALUE      // 2147483647
val minInt: Int = Int.MIN_VALUE      // -2147483648

fun main() {
    val firstname: String = "Jan"
    val lastname: String = "Kowalski"
    val age: Int = 43
    println(Hello(firstname, lastname, age))
}

fun Hello(firstname: String, lastname: String, age: Int): String {
    return "Witaj: $firstname $lastname wiek: $age"
}
```

### Long (Liczby całkowite 64-bitowe)

Używaj dla większych liczb. Oznaczaj suffiksem `L`.

```kotlin
val bigNumber: Long = 9223372036854775807L
val maxLong: Long = Long.MAX_VALUE
val minLong: Long = Long.MIN_VALUE

val result = 100L + 200L  // Wynik to Long
```

### Short (Liczby całkowite 16-bitowe)

Rzadko używany, oszczędza pamięć.

```kotlin
val shortNumber: Short = 32767
val minShort: Short = Short.MIN_VALUE
```

### Byte (Liczby całkowite 8-bitowe)

Najmniejszy typ całkowity.

```kotlin
val byteNumber: Byte = 127
val minByte: Byte = Byte.MIN_VALUE
```

### Float (Liczby zmiennoprzecinkowe 32-bitowe)

Oznaczaj suffiksem `f` lub `F`.

```kotlin
val pi: Float = 3.14f
val temperature: Float = -5.5f
val maxFloat: Float = Float.MAX_VALUE
```

### Double (Liczby zmiennoprzecinkowe 64-bitowe)

Domyślny typ dla liczb zmiennoprzecinkowych.

```kotlin
val price: Double = 19.99
val diameter: Double = 3.14159265
val maxDouble: Double = Double.MAX_VALUE

// Bez suffiksu 'f' traktowane jest jako Double
val calculation = 10.5 + 20.3  // Wynik to Double
```

### Operacje na Liczbach

```kotlin
val x = 10
val y = 3

println(x + y)      // 13 - dodawanie
println(x - y)      // 7  - odejmowanie
println(x * y)      // 30 - mnożenie
println(x / y)      // 3  - dzielenie całkowite
println(x % y)      // 1  - reszta z dzielenia
```

---

## Typ String

Ciąg znaków (tekst). Niezmienialny (immutable).

### Deklaracja

```kotlin
val greeting: String = "Cześć, Kotlin!"
val empty: String = ""
val multiline: String = """
    To jest
    wielolinijkowy
    tekst
""".trimIndent()
```

### String Templates - Interpolacja

```kotlin
val name = "Jan"
val age = 43

// Proste interpolacje zmiennych
println("Mam na imię $name")
println("Mam $age lat")

// Wyrażenia w template'ach
println("Za rok będę mieć ${age + 1} lat")
println("Długość mojego imienia: ${name.length}")

// Przykład z funkcji Hello
val result = "Witaj: $name Kowalski wiek: $age"
```

### Operacje na String

```kotlin
val text = "Kotlin"

// Długość
println(text.length)        // 6

// Zmiana na wielkie/małe litery
println(text.uppercase())   // KOTLIN
println(text.lowercase())   // kotlin

// Pobranie znaku
println(text[0])            // K
println(text.first())       // K
println(text.last())        // n

// Zawieranie
println(text.contains("lin"))  // true

// Substring
println(text.substring(0, 3))  // Kot

// Zastąpienie
println(text.replace("Kotlin", "Java"))  // Java

// Dzielenie
val parts = "a,b,c".split(",")  // [a, b, c]

// Rozpoczyna/kończy się
println(text.startsWith("Kot"))  // true
println(text.endsWith("in"))     // true
```

---

## Typ Boolean

Wartość logiczna - `true` lub `false`.

```kotlin
val isAdult: Boolean = true
val isStudent: Boolean = false

// Operacje logiczne
val a = true
val b = false

println(a && b)    // false - AND (i)
println(a || b)    // true  - OR (lub)
println(!a)        // false - NOT (negacja)

// Porównania zwracają Boolean
val age = 43
println(age >= 18)           // true
println(age == 43)           // true
println(age != 30)           // true
println(age < 50)            // true
```

### Warunkowe Instrukcje

```kotlin
val age = 43

if (age >= 18) {
    println("Jesteś pełnoletni")
} else {
    println("Jesteś niepełnoletni")
}

// If jako wyrażenie
val status = if (age >= 18) "Pełnoletni" else "Niepełnoletni"
```

---

## Typ Char

Pojedynczy znak. Zaznaczany apostrofami `' '`.

```kotlin
val letter: Char = 'K'
val digit: Char = '5'
val symbol: Char = '@'
val space: Char = ' '

// Znaki specjalne
val newline: Char = '\n'
val tab: Char = '\t'
val backslash: Char = '\\'
val quote: Char = '\''

// Konwersja i operacje
println(letter.code)           // Kod ASCII/Unicode
println(letter.isLetter())     // true
println(digit.isDigit())       // true
```

---

## Kolekcje

### List (Lista)

Kolekcja uporządkowana, zmienialność zależy od typu.

```kotlin
// Lista niezmienialna (immutable)
val immutableList: List<Int> = listOf(1, 2, 3, 4, 5)
val names: List<String> = listOf("Jan", "Maria", "Piotr")

// Lista zmienialna (mutable)
val mutableList: MutableList<Int> = mutableListOf(1, 2, 3)
mutableList.add(4)
mutableList.remove(1)

// Dostęp do elementów
println(immutableList[0])      // 1
println(immutableList.first()) // 1
println(immutableList.last())  // 5
println(immutableList.size)    // 5

// Iteracja
for (item in immutableList) {
    println(item)
}
```

### Set (Zbiór)

Kolekcja bez duplikatów, nieuporządkowana.

```kotlin
val numbers: Set<Int> = setOf(1, 2, 3, 3, 4, 4, 5)
println(numbers)  // [1, 2, 3, 4, 5] - duplikaty usunięte

// Zmienialna wersja
val mutableSet: MutableSet<String> = mutableSetOf("a", "b", "c")
mutableSet.add("d")
mutableSet.remove("a")
```

### Map (Mapa)

Kolekcja par klucz-wartość.

```kotlin
// Niezmienialna mapa
val person: Map<String, Any> = mapOf(
    "name" to "Jan",
    "lastname" to "Kowalski",
    "age" to 43
)

println(person["name"])      // Jan
println(person["age"])       // 43

// Zmienialna mapa
val scores: MutableMap<String, Int> = mutableMapOf()
scores["Jan"] = 95
scores["Maria"] = 87
scores["Piotr"] = 92

for ((name, score) in scores) {
    println("$name: $score")
}
```

---

## Typy Nullable

Typ w Kotlin może być nullable (może zawierać `null`) lub non-nullable.

### Deklaracja Nullable

```kotlin
val name: String = "Jan"          // Non-nullable - nigdy nie będzie null
val age: Int? = null              // Nullable - może być null lub Int
val city: String? = "Warszawa"    // Nullable - ale ma wartość
```

### Bezpieczeństwo Null

```kotlin
val text: String? = "Kotlin"

// Ternary operator - sprawdzanie null
val length = if (text != null) text.length else 0

// Safe call operator - ?. 
println(text?.length)   // Kotlin - jeśli text != null

// Elvis operator - ?: (wartość domyślna)
val len: Int = text?.length ?: 0

// Non-null assertion - ! (ostrożnie!)
val forceLength: Int = text!!.length  // Rzuca NPE jeśli null
```

### Funkcja RegisterUser z Obsługą Nullable

```kotlin
fun main() {
    registerUser()
}

fun registerUser() {
    println("Podaj imię:")
    val firstName: String? = readLine()
    
    println("Podaj nazwisko:")
    val lastName: String? = readLine()
    
    println("Podaj wiek:")
    val ageInput: String? = readLine()
    
    // Konwersja na Int i sprawdzenie null
    val age: Int? = ageInput?.toIntOrNull()
    
    // Sprawdzenie poprawności
    if (firstName != null && lastName != null && age != null) {
        if (age >= 18) {
            println("Rejestracja na prawo jazdy zakończona sukcesem dla osoby $firstName $lastName w wieku $age lat")
        } else {
            println("Rejestracja na prawo jazdy nie powiodła się dla osoby $firstName $lastName")
        }
    } else {
        println("Błędne dane wejściowe")
    }
}
```

---

## Any i Nothing

### Any

Klasa bazowa dla wszystkich typów w Kotlin.

```kotlin
val anything: Any = "String"
val alsoanything: Any = 42
val morething: Any = true

// Sprawdzanie typu
if (anything is String) {
    println("To jest String: $anything")
}

// Rzutowanie (casting)
val text = anything as String
val number = alsoanything as Int
```

### Nothing

Typ reprezentujący "nigdy nie wróci" (zawsze wyrzuci wyjątek).

```kotlin
fun throwException(): Nothing {
    throw IllegalArgumentException("Coś poszło nie tak!")
}

fun infiniteLoop(): Nothing {
    while (true) {
        // Niesko��czona pętla
    }
}
```

---

## Konwersje Typów

### Konwersje Jawne

```kotlin
// String na Int
val numberString = "42"
val number: Int = numberString.toInt()
val numberOrNull: Int? = numberString.toIntOrNull()  // Bezpieczna konwersja

// Int na String
val text: String = 42.toString()

// String na Double
val price: Double = "19.99".toDouble()

// Boolean na String
val flag: String = true.toString()

// Konwersje między typami liczbowymi
val intValue: Int = 10
val longValue: Long = intValue.toLong()
val doubleValue: Double = intValue.toDouble()
val byteValue: Byte = intValue.toByte()

// Char na Int (kod ASCII)
val letter: Char = 'A'
val code: Int = letter.code

// Int na Char
val charFromCode: Char = 65.toChar()  // 'A'
```

### Type Checking

```kotlin
val value: Any = "Kotlin"

when (value) {
    is String -> println("String: $value")
    is Int -> println("Int: $value")
    is Double -> println("Double: $value")
    else -> println("Nieznany typ")
}
```

---

## Podsumowanie

| Typ | Rozmiar | Zakres | Przykład |
|-----|---------|--------|---------|
| Byte | 8 bit | -128 do 127 | `val b: Byte = 10` |
| Short | 16 bit | -32768 do 32767 | `val s: Short = 1000` |
| Int | 32 bit | -2^31 do 2^31-1 | `val age: Int = 43` |
| Long | 64 bit | -2^63 do 2^63-1 | `val big: Long = 1000000L` |
| Float | 32 bit | ±3.4E±38 | `val f: Float = 3.14f` |
| Double | 64 bit | ±1.7E±308 | `val d: Double = 3.14` |
| Char | 16 bit | Unicode | `val c: Char = 'K'` |
| Boolean | - | true/false | `val b: Boolean = true` |
| String | - | Ciąg znaków | `val s: String = "Kotlin"` |

---

## Praktyczne Przykłady

### Walidacja Danych

```kotlin
fun isValidAge(ageString: String?): Boolean {
    return ageString?.toIntOrNull()?.let { age ->
        age >= 0 && age <= 150
    } ?: false
}

fun main() {
    println(isValidAge("43"))    // true
    println(isValidAge("-5"))    // false
    println(isValidAge("200"))   // false
    println(isValidAge(null))    // false
    println(isValidAge("abc"))   // false
}
```

### Przetwarzanie Kolekcji

```kotlin
fun main() {
    val ages = listOf(18, 25, 17, 30, 16, 21)
    
    // Filter - tylko pełnoletni
    val adults = ages.filter { it >= 18 }
    println(adults)  // [18, 25, 30, 21]
    
    // Map - zwiększ wiek o 1
    val nextYear = ages.map { it + 1 }
    println(nextYear)  // [19, 26, 18, 31, 17, 22]
    
    // Średnia
    val average = ages.average()
    println(average)  // 21.166...
}
```

---

**Autor:** PAM CW1  
**Data:** 2026-09-12  
**Język:** Kotlin