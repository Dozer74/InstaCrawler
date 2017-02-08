using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InstaCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var tag = "chelly";
            var crawler = new Crawler();
            crawler.TotalPhotoProcessedChanged += Crawler_TotalPhotoProcessedChanged;

            var count = 100;
            Console.WriteLine($"Поиск {count} фото с тегом #{tag}");
            var photos = crawler.Start(tag, count);

            Console.WriteLine("\nСохранение результатов");
            CsvWriter.Write("photos.csv",photos);

            Console.WriteLine("Завершено.");
            Console.ReadLine();
        }

        private static void Crawler_TotalPhotoProcessedChanged(int total, int withGeo)
        {
            Console.Write($"\rОбработано фото {total}. Геометка найдена: {withGeo}");
        }
    }
}
