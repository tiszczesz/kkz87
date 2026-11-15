package com.example.cw9_lists

import android.os.Bundle
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
import android.widget.Toast

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
        val adapter = ArrayAdapter(
            this,
            android.R.layout.simple_expandable_list_item_1,
            contacts
        )
        lvContacts.adapter = adapter
        btnAdd.setOnClickListener {
            val contact = tvAddContact.text.toString().trim()
            if (contact.length == 0) {
                Toast.makeText(
                    this, "Nie podano kontaktu",
                    Toast.LENGTH_SHORT
                ).show()
                return@setOnClickListener
            }
            contacts.add(contact)
            adapter.notifyDataSetChanged()
            tvAddContact.text.clear()
        }
//        lvContacts.onItemLongClickListener =
//            AdapterView.OnItemLongClickListener{ _, _, position,_ ->
//                Toast.makeText(
//                    this,
//                    "Usunięto kontakt: ${contacts[position]}",
//                    Toast.LENGTH_SHORT).show()
//                contacts.remove(contacts[position])
//                adapter.notifyDataSetChanged()
//                true
//            }
        lvContacts.setOnItemLongClickListener { parent, view, position, id ->
            // Pobierz kliknięty element z adaptera (opcjonalnie)
            val selectedItem = parent.getItemAtPosition(position)

            // Wykonaj akcję po długim przytrzymaniu
            Toast.makeText(this, "Przytrzymano pozycję: $position", Toast.LENGTH_SHORT).show()

            // Zwróć true, aby zablokować wywołanie zwykłego kliknięcia (OnItemClickListener)
            true
        }

    }
}