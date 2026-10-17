using System;

namespace cw3.Models;

public class Contact
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public override string ToString()
    {
        return $"{Firstname}|{Lastname}|{Age}|{Email}";
    }
    public static Contact? GetContact(string line)
    {
        //string bb = Firstname;
        var data = line.Split('|');
        if (data.Length == 4)
        {
            return new Contact
            {
                Firstname = data[0].Trim(),
                Lastname = data[1].Trim(),
                Age = Convert.ToInt32(data[2]),
                Email = data[3]
            };
        }
        return null;
    }
}
