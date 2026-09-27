using cw5_class;

Student s1 = new Student();//wywołanie konstruktora domyślnego
Student s2 = new Student("Jan", "Nowak", 33);//wywołanie konstruktora domyślnego
// s1.firstname = "Jan";
// s1.lastname = "Nowak";
// s1.age = 33;
Console.WriteLine(s1);
Console.WriteLine(s1.ToString());
Console.WriteLine(s2);
// Console.WriteLine(s1.GetHashCode());
// Console.WriteLine(s1.GetType());
