using System;

namespace cw9_layout.Models;

public class FileRepo
{
    public static void SaveToFile(Student student,string filename = "dane.txt")
    {
        File.AppendAllText(filename,student+Environment.NewLine);
    }

}
