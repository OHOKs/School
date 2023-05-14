using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace HegyekMo
{
    class Program
    {
        internal class Mountain
        {
            public string name { get; set; }
            public string place { get; set; }
            public int height { get; set; }
        }
        static void Main(string[] args)
        {
            List<Mountain> Mountains = new List<Mountain>();
            string[] data = File.ReadAllLines(@"D:/HegyekMo.txt", Encoding.UTF8).Skip(1).ToArray();

            int sum = 0;
            int indexMax = 0;
            int heightMax = 0;
            int heightInput = 0;
            string output = "Hegycsúcs neve;Magasság láb";
            List<Mountain> MountainsInBukk;

            foreach (var item in data)
            {
                string[] splittedData = item.Split(';');
                Mountains.Add(new Mountain
                {
                    name = splittedData[0],
                    place = splittedData[1],
                    height = Convert.ToInt32(splittedData[2])
                });
            }

            MountainsInBukk = Mountains.Where(x => x.place == "Bükk-vidék").ToList();

            Console.WriteLine($"3. Feladat: Hegycsúcsok száma: {Mountains.Count()}");

            foreach (var item in Mountains) { sum += item.height; }

            Console.WriteLine($"4. Feladat: Hegyek átlagmagassága: {sum / Mountains.Count()}");

            for (int i = 0; i < Mountains.Count; i++)
            {
                if (Mountains[i].height > heightMax) { heightMax = Mountains[i].height; indexMax = i; }
            }

            Console.WriteLine($"5. Feladat: A legmagasabb hegy adatai: \n       Név: {Mountains[indexMax].name}\n       Hegyég: {Mountains[indexMax].place}\n       Magasság: {Mountains[indexMax].height} m");

            Console.Write("6. Feladat: Kérek egy magasságot: ");

            heightInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Mountains.Where(x => x.height > heightInput).Count() > 0 ? $"  Van {heightInput}-nél magasabb hegység" : $" Nincs {heightInput}-nél magasabb hegység");

            Console.WriteLine($"8. Feladat: 3000 lábnál magasabb hegycsúcsok száma: {Mountains.Where((x) => x.height * 3.280839895 > 3000).Count()}");

            Dictionary<string, int> MountainsStat = new Dictionary<string, int>();

            foreach (var item in Mountains)
            {
                if (MountainsStat.ContainsKey(item.place)) { MountainsStat[item.place]++; }
                else { MountainsStat.Add(item.place, 1); }
            }

            Console.WriteLine("8. Feladat: Hegység statisztika");

            foreach (var item in MountainsStat)
            {
                Console.WriteLine($"        {item.Key} - {item.Value} db");
            }

            foreach (var item in MountainsInBukk)
            {
                double tempHeight = Math.Round(Convert.ToDouble(item.height) * 3.280839895, 1);
                string heightStr = tempHeight % 1 == 0 ? ((int)tempHeight).ToString() : tempHeight.ToString("0.0");
                output += $"\n{item.name};{heightStr}";
            }

            Console.Write("9. Feladat: bukk-videk.txt");

            File.WriteAllText(@"D:/bukk-videk.txt", output);

            Console.ReadKey();
        }
    }
}