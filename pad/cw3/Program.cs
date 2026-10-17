using cw3.Models;

FileRepo repo = new FileRepo();
repo.ShowAllContacts();
Contact newContact = new Contact
{
    Firstname = "nowy",
    Lastname = "nowy",
    Age = 22,
    Email = "vvv@bbb.bb"
};
//repo.AddContact(newContact);
repo.DeleteByName("nowy");