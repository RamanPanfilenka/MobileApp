using MovieDb;
using System;

namespace TestMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new MovieDbService();
            var films = service.GetFilmList("Shrek");
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
