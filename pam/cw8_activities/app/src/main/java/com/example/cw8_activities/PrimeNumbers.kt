package com.example.cw8_activities

fun IsPrime(number: Int): Boolean{
    if (number<2) return false
    var counter = 2;
    while(counter*counter<=number){
        if (number%counter==0) return false
        counter++
    }
    return true
}