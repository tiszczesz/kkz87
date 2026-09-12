package com.example.cw1

fun main(){
    val firstname:String = "Jan";
    val lastname:String = "Kowakski";
    val age:Int = 43;
    println(Hello(firstname,lastname,age));
}
fun Hello(firstname:String,lastname:String,age:Int):String {

    return "Witaj: "+firstname+" "+lastname+ " wiek: "+age
}