package com.example.cw10

import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    private var isCircle = false
    private lateinit var buttons: Array<Button>
    private lateinit var resultGame: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        buttons = arrayOf(
            findViewById(R.id.b11),
            findViewById(R.id.b12),
            findViewById(R.id.b13),
            findViewById(R.id.b21),
            findViewById(R.id.b22),
            findViewById(R.id.b23),
            findViewById(R.id.b31),
            findViewById(R.id.b32),
            findViewById(R.id.b33)
        )
        resultGame = findViewById<TextView>(R.id.textView)
        val startGameButton = findViewById<Button>(R.id.btnStart)
        startGameButton.setOnClickListener {
            startGame(buttons)
            startGameButton.isEnabled = false
        }


        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        for (btn in buttons) {
            btn.setOnClickListener {
                if (btn.text.toString().trim() == "") {
                    if (isCircle) {
                        btn.text = "O"
                    } else {
                        btn.text = "X"
                    }
                    isCircle = !isCircle
                    if (isEndGame(buttons)) {
                        for (gameButton in buttons) {
                            gameButton.isEnabled = false
                        }
                        resultGame.text = "Koniec gry"
                        startGameButton.isEnabled = true
                    }
                }
            }
        }

    }

    private fun isEndGame(buttons: Array<Button>): Boolean {
        // Check rows
        for (i in 0..2) {
            if (buttons[i * 3].text.toString() == buttons[i * 3 + 1].text.toString() && buttons[i * 3].text.toString() == buttons[i * 3 + 2].text.toString() && buttons[i * 3].text.toString() != "") {
                return true
            }
        }
        // Check columns
        for (i in 0..2) {
            if (buttons[i].text.toString() == buttons[i + 3].text.toString() && buttons[i].text.toString() == buttons[i + 6].text.toString() && buttons[i].text.toString() != "") {
                return true
            }
        }
        // Check diagonals
        if (buttons[0].text.toString() == buttons[4].text.toString() && buttons[0].text.toString() == buttons[8].text.toString() && buttons[0].text.toString() != "") {
            return true
        }
        if (buttons[2].text.toString() == buttons[4].text.toString() && buttons[2].text.toString() == buttons[6].text.toString() && buttons[2].text.toString() != "") {
            return true
        }
        if (buttons.all { it.text.toString().trim() != "" })
            return true
        return false
    }

    private fun startGame(buttons: Array<Button>) {
        for (btn in buttons) {
            btn.text = ""
            btn.isEnabled = true
        }
        resultGame.text = "Rozpocznij grę"
        isCircle = false
    }
}