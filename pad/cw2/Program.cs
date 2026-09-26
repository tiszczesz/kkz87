void Ex1()
{
    int[] nazwa = new int[20]; //zdefiniowanie 20 elem tablicy liczb  całkowitych
    Random rnd = new Random(); //generator liczb losowych 
    for (int i = 0; i < nazwa.Length; i++)
    {
        nazwa[i] = rnd.Next(100);
    }

    foreach (int elem in nazwa)
    {
        Console.Write(elem + " ");
    }
}
//Ex1();
void Ex2()
{
    //tablice 2-wymiarowe
    string?[,] zdania = new string[2, 3];
    for (int i = 0; i < zdania.GetLength(0); i++)
    {
        for (int j = 0; j < zdania.GetLength(1); j++)
        {
            Console.Write($"podaj tekst dla [{i},{j}]: ");
            zdania[i, j] = Console.ReadLine();
        }

    }
    for (int i = 0; i < zdania.GetLength(0); i++)
    {
        for (int j = 0; j < zdania.GetLength(1); j++)
        {
            Console.Write(zdania[i, j] + " ");
        }
        Console.WriteLine();

    }
    // foreach (string? elem in zdania)
    // {
    //     Console.Write(elem + " ");
    // }
}
//Ex2();
void Ex3()
{
    //tablica tablic
    int[][] tab = new int[4][]; // 4-elementowa tablica tablic liczb calkowitych
    tab[0] = new int[10];
    tab[1] = new int[20];
    tab[2] = new int[5];
    tab[3] = new int[100];
    Random rnd = new Random();
    for (int i = 0; i < tab.Length; i++)
    {
        for (int j = 0; j < tab[i].Length; j++)
        {
            tab[i][j] = rnd.Next(100);
        }
    }
    //wyswietlanie
    foreach (var item in tab)
    {
        foreach (var elem in item)
        {
            Console.Write(elem + " ");
        }
        Console.WriteLine();
    }
}
Ex3();
