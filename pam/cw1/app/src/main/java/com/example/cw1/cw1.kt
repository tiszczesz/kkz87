package com.example.cw1

fun main(){
//    val firstname:String = "Jan";
//    val lastname:String = "Kowakski";
    print("Podaj imie: ")
    var firstname =  readLine() ?: ""
    print("Podaj nazwisko: ")
    var lastname = readlnOrNull() ?: ""
    print("Podaj wiek: ")
    var age = readLine()?.toIntOrNull() ?: 0
//    var age:Int = if (agge?.length!=0) agge.toInt() else 0

    println(Hello(firstname,lastname,age));
    println(Hello(firstname,lastname));
}
fun Hello(firstname:String,lastname:String,age:Int=67):String {
    return "Witaj: "+firstname+" "+lastname+ " wiek: "+age
}