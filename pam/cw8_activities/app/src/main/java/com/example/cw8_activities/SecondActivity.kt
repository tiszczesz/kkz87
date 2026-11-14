package com.example.cw8_activities

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class SecondActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_second)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        val btnGoToFirst = findViewById<Button>(R.id.btnGoToFirst)
        btnGoToFirst.setOnClickListener {
            finish()
        }
        val btnCheck = findViewById<Button>(R.id.btnCheck)
        val editTextNumber = findViewById<EditText>(R.id.editTextNumber)
        val tvResult = findViewById<TextView>(R.id.tvResult)
        btnCheck.setOnClickListener {
            try {
                val number:Int = (editTextNumber.text).toString().toInt()
                val result = IsPrime(number)
                if (result) {
                    tvResult.text = "Liczba $number jest liczbą pierwszą"
                } else {
                    tvResult.text = "Liczba $number nie jest liczbą pierwszą"
                }
            } catch (e: NumberFormatException) {
                Toast.makeText(this, "Niepoprawna liczba", Toast.LENGTH_SHORT).show()
            }
        }
    }
}