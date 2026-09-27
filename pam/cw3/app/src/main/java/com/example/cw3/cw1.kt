package com.example.cw3

import kotlin.random.Random

fun main(){
    print("Podaj rozmiar tablicy: ")
    val size =     readln().toInt()
    val array = generateTab2(size)
    showArray2(array)
    println("Najmniejszy element: ${getMin(array)}")
    println("Największy element: ${getMax(array)}")
}

fun generateTab(size: Int): IntArray{
    val array = IntArray(size)
    for (i in array.indices){
        array[i] = Random.nextInt(0, 100)
    }
    return array
}
fun generateTab2(size:Int): Array<Int>{
    val array = Array(size){0}
    for (i in array.indices){
        array[i] = Random.nextInt(0, 100)
    }
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
fun getMin(arr: Array<Int>):Int{
//    var min = arr[0]
//    for (i in arr.indices){
//        if (arr[i] < min) min = arr[i]
//    }
//    return min;
    return arr.minOrNull() ?: 0
}
fun getMax(arr: Array<Int>):Int{
//    var max = arr[0]
//    for (i in arr.indices){
//        if (arr[i] > max) max = arr[i]
//    }
//    return max;
    return arr.maxOrNull() ?: 0
}