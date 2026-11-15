package com.example.cw9_lists

import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView

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
        val btnAdd = findViewById<Button>(R.id.btnAddContact)
        val lvContacts = findViewById<ListView>(R.id.lvContacts)
        val tvAddContact = findViewById<EditText>(R.id.etAddContact)

        //adapter dla danych z listy
        val adapter = ArrayAdapter(this,
                 android.R.layout.simple_expandable_list_item_1,
                   contacts)
        lvContacts.adapter = adapter

    }
}