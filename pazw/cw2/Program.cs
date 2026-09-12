Console.WriteLine("Hello, World!");


void ShowVertical(string text)
{
    for (int i=0; i<text.Length ;i++ ) {
        Console.WriteLine(text[i]);
    }
    //for(; ; )
    //{
    //    Console.WriteLine("ii");
    //}
}
void ShowReverse(string text)
{
    for (int i = text.Length - 1; i >= 0; i--) { 
        Console.Write(text[i]);
    }
}
void ShowRandomSum(uint max)
{
    uint sum = 0;
    var rnd = new Random();
    while (sum < max)
    {
        uint random = (uint)rnd.Next(20);
        Console.Write(random + " ");
        sum += random;
    }
    Console.WriteLine($"suma wynosi: {sum}");
}
void RandomUntilZero()
{
    var rnd = new Random();
    //losowanie do momentu zera i wyswietlenie
}

ShowVertical("Ala ma kota");
ShowReverse("ala ma kota");
Console.WriteLine("\n=================================\n");
ShowRandomSum(200);