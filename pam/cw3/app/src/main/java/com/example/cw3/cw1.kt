package com.example.cw3

fun main(){
    print("Podaj rozmiar tablicy: ")
    val size = readln().toInt()
    val array = generateTab2(size)
    showArray2(array)
}

fun generateTab(size: Int): IntArray{
    val array = IntArray(size)
    return array
}
fun generateTab2(size:Int): Array<Int>{
    val array = Array(size){0}
    return array}
fun showArray(array: IntArray){
    for (i in array){
        print("$i ")
    }
    println()
}
fun showArray2(array: Array<Int>){
    for (i in array){
        print("$i ")
    }
    println()
}