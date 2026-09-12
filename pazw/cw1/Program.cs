//napisz funkcję UserRegister w której podajecie email i hasło
//walidacja emaila i hasła, jeśli nie spełnia wymagań to wyświetlamy
//  komunikat o błędzie
void RegisterUser()
{
    Console.WriteLine("Podaj swój email: ");
    string? inputEmail = Console.ReadLine();
     Console.WriteLine("Podaj swoje hasło: ");
    string? password = Console.ReadLine();
    // if (ValidateEmail(email)){
    //     Console.WriteLine("Email jest poprawny.");
    // }
    Console.WriteLine(ValidateEmail(inputEmail) ? "Email jest poprawny." : "Email jest niepoprawny.");
    Console.WriteLine(ValidatePassword(password) ? "Hasło jest poprawne." : "Hasło jest niepoprawne.");

}

static void GreetUser()
{
    Console.WriteLine("Hello World");
    string napis = "Hello World";
    Console.WriteLine(napis);
    try
    {
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

bool ValidatePassword(string? password)
{
    // Prosta walidacja hasła
    return password != null && password.Length >= 8 && password.Any(char.IsUpper) 
        && password.Any(char.IsLower) && password.Any(char.IsDigit); 
}
bool ValidateEmail(string? email)
{
    // Prosta walidacja emaila
    return email != null && email.Length > 4 && email.Contains("@") && email.Contains(".");   
}


void fun1()
{
   // GreetUser();
    Console.WriteLine(" ======================================================== \n\n");
    RegisterUser();

}
fun1();
