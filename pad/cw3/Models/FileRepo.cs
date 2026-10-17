using System;

namespace cw3.Models;
//rozmawinie z plikami danych
public class FileRepo
{
    private List<Contact> _contacts = new List<Contact>();
    private string filename = "data.txt";

    //public List<Contact> Contacts { get; set; } = [];
    public FileRepo(string filename = "data.txt")
    {
        this.filename = filename;
        var lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            var contact = Contact.GetContact(line);
            if (contact != null) _contacts.Add(contact);
        }
    }
    public void ShowAllContacts()
    {
        foreach (var c in _contacts)
        {
            Console.WriteLine(c);
        }
    }

    public void AddContact(Contact newContact)
    {
        _contacts.Add(newContact);
        SaveToFile();
    }

    private void SaveToFile()
    {
        var data = new List<string>();
        foreach (var c in _contacts)
        {
            data.Add(c.ToString());
        }
        File.WriteAllLines(filename, data);
    }

    public void DeleteByName(string v)
    {
        _contacts.RemoveAll((c) => c.Firstname.ToLower() == v.ToLower()
        || c.Lastname.ToLower() == v.ToLower());
        SaveToFile();
    }
}
