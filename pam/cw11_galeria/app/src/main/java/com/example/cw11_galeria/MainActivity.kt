package com.example.cw11_galeria

import android.os.Bundle
import android.widget.Button
import android.widget.ImageView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {

    //pole klasy
    private val images = intArrayOf(
        R.drawable.obraz1,
        R.drawable.obraz2,
        R.drawable.obraz3,
        R.drawable.obraz4,
        R.drawable.obraz5
    );
    private var currentIndex = 4;


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        val imageView = findViewById<ImageView>(R.id.image)
        imageView.setImageResource(images[currentIndex])
        val btnRandom = findViewById<Button>(R.id.btnRandom)

        btnRandom.setOnClickListener {
            currentIndex = (0..<images.count()).random()
            imageView.setImageResource(images[currentIndex])
        }
        val btndown = findViewById<Button>(R.id.down)
        val btnup = findViewById<Button>(R.id.up)
        btnup.setOnClickListener {
            currentIndex = (currentIndex + 1) % images.size
            imageView.setImageResource(images[currentIndex])
        }
        btndown.setOnClickListener {
            if (currentIndex > 0) {
                currentIndex--
                imageView.setImageResource(images[currentIndex])
            }else{
                currentIndex = images.size - 1
                imageView.setImageResource(images[currentIndex])
            }
        }
    }
}