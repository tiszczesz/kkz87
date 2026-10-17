package com.example.cw5

import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        //ZNALEŹĆ kontrolki Button i TextView
        // w kodzie i przypisać im odpowiednie akcje
        val btn1 = findViewById<Button>(R.id.btn1)
        val tv1 = findViewById<TextView>(R.id.txt1)

        //tv1.text = "po zmianie władzy"
        btn1.setOnClickListener {
            tv1.text = "ala ma kota";
        }
    }
}