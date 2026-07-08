using System;

class Program
{
    static void Main(string[] args)
    {

        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine(i);
            if (i == 20)
            {
                Console.WriteLine("The loop is stopping at 20");
                break;
            }
        }

    }
}