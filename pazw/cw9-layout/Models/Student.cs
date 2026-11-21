using System;

namespace cw9_layout.Models;

public class Student
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string BirthDate { get; set; }
    public string Division { get; set; }

    public override string ToString()
    {
        return $"{Firstname}|{Lastname}|{BirthDate}|{Division}";
    }
}
