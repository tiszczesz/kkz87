using System.Reflection.Metadata;

const string filename = "dane.txt";
string[] GetFromFile(string filename)
{
    //File.WriteAllLines()
    return File.ReadAllLines(filename);
}
int GetWordsFromStrings(string[] lines)
{
    //document.querySelector("#ala").addEvenListener("click",()=>{alert("jjjj")});
    // int wordsCount = 0;
    // foreach (var line in lines)
    // {
    //     wordsCount += line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
    // }
    // //explode w php, ... w js
    // return wordsCount;

    //lepsza wersja z Linq i powtarzaniem spacji
    return lines.Sum(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length);
}
int GetCharsFromStrings(string[] lines)
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
int countChar = GetCharsFromStrings(result);

Console.WriteLine("Ilosc znakow w pliku: " + countChar);
Console.WriteLine("Ilosc lini w pliku: " + result.Length);
Console.WriteLine("Ilosc wyrazow w pliku: " + GetWordsFromStrings(result));
Console.WriteLine("Ilosc wyrazow w pliku: " + "ala ma     kota".Split(" ").Length);
var ff = "ala ma  kota".Split(" ");
foreach (var item in ff)
{
    if (item.Length > 0)
        Console.Write(item + "-");
}