void Ex1()
{
    int[] nazwa = new int[20]; //zdefiniowanie 20 elem tablicy liczb  całkowitych
    Random rnd = new Random(); //generator liczb losowych 
    for(int i=0; i < nazwa.Length; i++)
    {
        nazwa[i] = rnd.Next(100);
    }

    foreach(int elem in nazwa)
    {
        Console.Write(elem+ " ");
    }
}  
Ex1();
