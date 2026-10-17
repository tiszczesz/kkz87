package com.example.cw4

fun main() {
    val c1 = Car()
    val c2 = Car("Toyota", "Corolla", 2020)
//    c1.brand = "Toyota"
//    c1.model = "Corolla"
//    c1.year = 2020
    val c3 = Car2()
    println(c1)
    println(c2)
    println(c3)
    c3.Brand = "honda"
    c3.Brand = "";
    c3.Year = 23
    println(c3.Brand)
    println(c3.Year)
}