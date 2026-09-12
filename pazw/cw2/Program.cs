Console.WriteLine("Hello, World!");


void ShowVertical(string text)
{
    for (int i = 0; i < text.Length; i++)
    {
        Console.WriteLine(text[i]);
    }
    //for(; ; )
    //{
    //    Console.WriteLine("ii");
    //}
}
void ShowReverse(string text)
{
    for (int i = text.Length - 1; i >= 0; i--)
    {
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
    //dołożyć wyzanczanie sumy, średniej max i min oprócz ZERO
    //jeżeli ZERO na początku losowania to wyswietlic komunikat zbiór pusty i zakończyć program
    var rnd = new Random();
    //losowanie do momentu zera i wyswietlenie
    int random;
    int counter = 0;
    do
    {
        random = rnd.Next(0, 5);
        if(random != 0)
        {
            counter++;
        }
        Console.Write(random + " ");
    } while (random != 0);
    Console.WriteLine($"\nWylosowano {counter} liczb niezerowych");
}

ShowVertical("Ala ma kota");
ShowReverse("ala ma kota");
Console.WriteLine("\n=================================\n");
ShowRandomSum(200);
Console.WriteLine("\n=================================\n");
RandomUntilZero();