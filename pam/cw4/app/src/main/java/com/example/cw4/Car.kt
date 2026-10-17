package com.example.cw4

class Car {
    private var brand: String;
    private var model: String;
    private var year: Int;
    constructor(
        brand: String = "noname", model: String = "noname",
        year: Int = 2000
    ) {
        this.brand = brand;
        this.model = model;
        this.year = year;
    }


    override fun toString(): String {
        return "Car(brand='$brand', model='$model', year=$year)"
    }
}