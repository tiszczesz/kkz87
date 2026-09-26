const string filename = "dane.txt";
string[] GetFromFile(string filename)
{
    return File.ReadAllLines(filename);
}
int GetWordsFromString(string[] lines)
{
    return 0;
}
int GetCharsFromString(string[] lines)
{
    int result = 0;
    foreach (var line in lines)
    {
        result += line.Length;
    }
    return result;
}
var result = GetFromFile(filename);
Console.WriteLine("Zawartosc pliku: " + filename);
foreach (string line in result)
{
    Console.WriteLine(line);
}
int countChar = GetCharsFromString(result);

Console.WriteLine("Ilosc znakow w pliku: " + countChar);
Console.WriteLine("Ilosc lini w pliku: " + result.Length);
Console.WriteLine("Ilosc wyrazow w pliku: " + GetWordsFromString(result));