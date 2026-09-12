//napisz funkcję UserRegister w której podajecie email i hasło
//walidacja emaila i hasła, jeśli nie spełnia wymagań to wyświetlamy
//  komunikat o błędzie
void RegisterUser()
{
    var bb = Char.IsUpper('a');
    string email = "asdad@sdfsdfsdf";
    email.Contains("@");
}

void fun1()
{  
    Console.WriteLine("Hello World");
    string napis = "Hello World";
    Console.WriteLine(napis);
    try{
        Console.WriteLine("Please enter your first name:");
        string? firstname = Console.ReadLine();
        Console.WriteLine("Please enter your birth year:");
        int actualYear = DateTime.Now.Year;
        int? age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Hello {firstname}, you are {actualYear - age} years old.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
    
}
fun1();
