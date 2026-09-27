package com.example.cw3

data class Game(val name: String, val genre: String, val year: Int, val price: Double)

fun main() {
    val sampleGames = mutableListOf<Game>(
        Game("Echo Labiryntu", "Przygodowa", 2021, 59.99),
        Game("Kosmiczny Kurier", "Zręcznościowa", 2022, 39.99),
        Game("Ostatni Ogrodnik", "Symulacja", 2023, 49.99),
        Game("Cień Detektywa", "Detektywistyczna", 2020, 69.99),
        Game("Pociąg Donikąd", "Logiczna", 2024, 29.99),
        Game("Potwory z Poddasza", "Kooperacyjna", 2021, 44.99),
        Game("Neonowy Kurier", "Wyścigowa", 2025, 79.99),
        Game("Wyspa na Dzień", "Survival", 2022, 54.99),
        Game("Mała Wielka Maszyna", "Konstrukcyjna", 2023, 34.99),
        Game("Biblioteka Snów", "Narracyjna", 2024, 64.99)
    )
    println("Gry przed posortowaniem:")
    for (game in sampleGames) {
        println("${game.name} - ${game.genre} - ${game.year} - ${game.price}")
    }
    println("Gry po posortowaniu:")
    sampleGames.sortBy { it -> it.price }
    for (game in sampleGames) {
        println("${game.name} - ${game.genre} - ${game.year} - ${game.price}")
    }
}

