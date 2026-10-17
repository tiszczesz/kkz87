using cw6_wb.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var repo = new FileRepo();
var contacts = repo.GetAll();
app.MapGet("/hello", () => "Hello World!");
app.MapGet("/ala", () => "Hello ala!");
app.MapGet("/", () =>
{
    var c = new Contact
    {
        Firstname = "ddssd",
        Lastname = "dsdsdsd",
        Age = 34,
        Email = "adsasd@dsfds"
    };
    return c;
});
app.MapGet("/contacts", () =>
{
    return contacts;
});

app.Run();
