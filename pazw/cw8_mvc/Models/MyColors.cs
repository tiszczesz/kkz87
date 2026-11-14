using System;

namespace cw8_mvc.Models;

public class MyColors
{
    public static List<string> Colors()
    {
        return new()
        {   
            "White",
            "Red",
            "Blue",
            "Green",
            "Yellow",
            "Orange",
            "Purple",
            "Pink",
            "Brown",
            "Black"            
        };
    }
}
