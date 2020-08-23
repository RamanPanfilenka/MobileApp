using BusinessLogic.Models;
using GoogleTable;
using MovieDb;
using System;

namespace TestMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new GoogleSheetFilmService();
            var films = service.GetFilms();
            var saveFilmsType = typeof(SavedFilm);
            var prop = saveFilmsType.GetProperties();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
