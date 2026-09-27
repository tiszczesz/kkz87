package com.example.cw3

fun main(){
    val p1: Person = Person("Jan", "Kowalski", 30);
    val p2: Person = Person("Anna", "Nowak", 25);
    val p3: Person = Person("Roman", "Gryk", 19);
    val p4: Person = Person("Teresa", "Małecka", 25);
    val p10: Person = Person("Marek", "Nowak", 40);
    println(p1)
    println(p2)
    val people = listOf(p1, p2, p3, p4) //lista osób tylko do odczytu
    val p5 = Person("Marek", "Nowak", 40)
    //people.add(p5) // błąd kompilacji, bo lista jest tylko do odczytu
    val people2 = mutableListOf<Person>(p1, p2, p3, p4) //lista osób do odczytu i zapisu
    people2.add(p5) // dodanie osoby do listy
    println("   ====== Lista osób:")
    for (p in people2){
        println(p)
    }
}

data class Person(val firstname: String,val lastname:String, val age: Int)