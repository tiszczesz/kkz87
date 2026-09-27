namespace cw5_class;

public class Student  //dziedziczy z object
{
    // public string firstname;
    // public string lastname;
    private string firstname;
    private string lastname;
    private int age;

    //nadpisanie metody ToString() z klasy object
    public override string ToString()
    {
        return $"imię: {firstname} nazwisko: {lastname} wiek: {age}";
    }

    //przeładowanie konstruktora
    public Student(string firstname, string lastname, int age)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
    }
    public Student()
    {
        this.firstname = "noname";
        this.lastname = "noname";
        this.age = 20;
    }
}