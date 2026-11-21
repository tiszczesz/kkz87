package com.example.ark2

import android.os.Bundle
import android.widget.Button
import android.widget.EditText

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

        //kod aplikacji
        val emailEdit = findViewById<EditText>(R.id.etEmail)
        val pass1Edit = findViewById<EditText>(R.id.etPassword1)
        val pass2Edit = findViewById<EditText>(R.id.etPassword2)
        val btnAccept = findViewById<Button>(R.id.btnAccept)
        val resultTV = findViewById<TextView>(R.id.tvResult)
        btnAccept.setOnClickListener {
            if (!emailEdit.text.toString().contains("@")) {
                resultTV.text = "Nieprawidłowy adres e-mail";
                return@setOnClickListener;
            }
            if (pass1Edit.text.toString()
                != pass2Edit.text.toString()
            ) {
                resultTV.text = "Hasła się różnią";
                return@setOnClickListener;
            }
            resultTV.text = "Witaj ${emailEdit.text}"
        }
    }
}