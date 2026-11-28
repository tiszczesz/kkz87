using System;
using Microsoft.Data.Sqlite;


namespace cw10_models.Models;

public class StudentsRepo
{
    private string? connString;
    public StudentsRepo(IConfiguration configuration)
    {
        connString = configuration.GetConnectionString("sqlite")
              ??"Data Source=appdb.db";
    }
    public List<Student> GetStudents()
    {
        using SqliteConnection conn = new SqliteConnection(connString);
        using SqliteCommand command = conn.CreateCommand();
        command.CommandText = "SELECT id,firstname,lastname,age FROM Students";
        conn.Open();        
        using SqliteDataReader reader = command.ExecuteReader();
        List<Student> students = new();
        while (reader.Read())
        {
            students.Add(
                new Student
                {
                    Id = reader.GetInt32(0),
                    Firstname = reader.GetString(1),
                    Lastname = reader.GetString(2),
                    Age = reader.GetInt32(3)
                }
            );
        }
        conn.Close();
        return students;
    }
}
