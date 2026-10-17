package com.example.cw4

import java.util.Locale
import java.util.Locale.getDefault

class Car2(
    private var brand: String = "noname",
    private var model: String = "noname",
    private var year: Int = 2000
) {
    override fun toString(): String {
        return "Car2(brand='$brand', model='$model', year=$year)"
    }
    //get and set
    public var Brand:String
        get() = brand.uppercase(getDefault())
        set(value) {
            brand = if (value.isNotEmpty()) value else "noname"
        }
    public var Model: String
        get() = model
        set(value) {
            model = value
        }
    public var Year: Int
        get() = year
        set(value) = if(value< 1900) year = 1900 else year = value
}