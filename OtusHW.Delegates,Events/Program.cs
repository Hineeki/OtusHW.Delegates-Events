using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

namespace OtusHW.Delegates_Events
{
    public delegate float MyDelegate(IEnumerable collection);

    internal class Program
    {
        static void Main(string[] args)
        {
            Collection<int> list = new Collection<int>() {1,2,3,4,5,6,7,8,9 }; 
            var scanner = new DirectoryScanner();
            scanner.FileFound += OnFileFound;
            scanner.ScanDirectory("C:\\");
            list.GetMax(element=> element.);
        }

        private static void OnFileFound(object sender, FileFoundEventArgs e)
        {
            Console.WriteLine($"File found: {e.FileName}");
        }
    }
    public static class MyExtensions //hjn t,fk, тут мы должны знать что содержится в коллекции, ибо надо знать какой метод вызывать, не?
                                     //(ленс или каунт, или наибольшее число)
    {
        public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null)
                throw new ArgumentException("Collection is null or empty");

            T maxElement = null;

            foreach ( var element in collection)
            {
                if (element > maxElement)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }
    }
}
