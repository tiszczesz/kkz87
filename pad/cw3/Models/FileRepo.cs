using System;

namespace cw3.Models;
//rozmawinie z plikami danych
public class FileRepo
{
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    //public List<Contact> Contacts { get; set; } = [];
    public FileRepo(string filename = "data.txt")
    {
        var lines = File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            var contact = Contact.GetContact(line);
            if(contact!=null) Contacts.Add(contact);
        }
    }
}
