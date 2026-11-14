package com.example.cw8_activities

import org.junit.Test

import org.junit.Assert.*

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * See [testing documentation](http://d.android.com/tools/testing).
 */
class ExampleUnitTest {
    @Test
    fun addition_isCorrect() {
        assertEquals(4, 2 + 2)
    }
    @Test
    fun prime_isCorrect() {
        assertTrue(IsPrime(2))
        assertTrue(IsPrime(3))
        assertFalse(IsPrime(4))
        assertTrue(IsPrime(5))
        assertFalse(IsPrime(6))
        assertFalse(IsPrime(21))
        assertTrue(IsPrime(31))
    }
}