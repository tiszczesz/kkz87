using System;

namespace cw5_class;

public class Book
{
    private string title;
   // private string author;
    private decimal price;
    //property dla pól
    public string Title
    {
        get { return title.ToUpper(); }
        set { title = value; }
    }
    // public string Author
    // {
    //     get { return author; }
    //     set { author = value; }
    // }
    //autoproperty
    public string Author { get; set; }
    public decimal Price
    {
        get { return price; }
        set { price = value > 0 ? value : 0; }
    }
    public Book()
    {
        Title = "noname";
        Author = "noname";
        Price = 100M;
    }
    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author  = author;
        Price = price;
    }
}
