const string filename = "dane.txt";
string[] GetFromFile(string filename)
{
    return File.ReadAllLines(filename);
}
var result = GetFromFile(filename);
Console.WriteLine("Zawartosc pliku: " + filename);
foreach(string line in result)
{
    Console.WriteLine(line);
}
int countChar = 0;
Console.WriteLine("Ilosc znakow w pliku: "+countChar);
Console.WriteLine("Ilosc lini w pliku: ");