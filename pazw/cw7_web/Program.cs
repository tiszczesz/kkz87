var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
// app.MapGet("/date", () =>
// {
//     return DateTime.Now.ToShortDateString();
// });
// app.MapGet("/date", () => DateTime.Now.ToShortDateString());
app.MapRazorPages();
app.Run();
