using cw3.Models;

FileRepo repo = new FileRepo();
foreach(var c in repo.Contacts)
{
    Console.WriteLine(c);
}
Contact newContact = new Contact
{
    Firstname = "nowy",
    Lastname = "nowy",
    Age = 22,
    Email = "vvv@bbb.bb"
};
repo.Contacts.Add(newContact);