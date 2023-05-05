using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EU
{
    class Program
    {
        internal class Tagállam
        {
            public string TagállamNeve { get; set; }
            public string CsatlakozásÉve { get; set; }
        }
        static void Main(string[] args)
        {
            string[] Adatok = File.ReadAllLines("EUcsatlakozas.txt");

            List<Tagállam> Tagállamok = new List<Tagállam>();

            foreach(var Adat in Adatok)
            {
                string[] AdatElválatsztva = Adat.Split(';');
                Tagállamok.Add(new Tagállam() { TagállamNeve = AdatElválatsztva[0], CsatlakozásÉve = AdatElválatsztva[1] });
            }

            Console.WriteLine($"3. Feladat: EU tagállamok száma: {Tagállamok.Count()}db");

            Console.WriteLine($"4. Feladat: 2007-ben csatlakozó országok száma: {Tagállamok.Where(obj => obj.CsatlakozásÉve.Contains("2007")).Count()}db");

            string Év = "";

            foreach(var item in Tagállamok) { if (item.TagállamNeve == "Magyarország") Év = item.CsatlakozásÉve; }

            Console.WriteLine($"5. Feladat: Magyarország csatlakozásának dátuma: {Év}");

            string message = Tagállamok.Where(obj => obj.CsatlakozásÉve.Contains(".05.")).Count() > 0 ? "6. Feladat: Volt májusban csatlakozás" : "6. Feladat: Nem volt májusban csatlakozás";

            Console.WriteLine($"{message}");

            Tagállam current = Tagállamok[0];

            foreach (var item in Tagállamok)
            {
                string[] ev = item.CsatlakozásÉve.Split('.');
                string[] ev2 = current.CsatlakozásÉve.Split('.');
                if(Convert.ToUInt32(ev[0]) > Convert.ToUInt32(ev2[0]))
                {
                    current = item;
                } 
            }

            Console.WriteLine($"7. Feladat: Legutoljára csatlakozott ország: {current.TagállamNeve}");

            Dictionary<int, int> Statistic = new();

            foreach(var item in Tagállamok)
            {
                string[] ev = item.CsatlakozásÉve.Split('.');

                if (Statistic.ContainsKey(Convert.ToInt32(ev[0])))
                {
                    Statistic[Convert.ToInt32(ev[0])]++;
                }
                else
                {
                    Statistic.Add(Convert.ToInt32(ev[0]), 1);
                }
            }

            Console.WriteLine("8. Feladat: Statisztika");
            foreach(var item in Statistic)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.ReadLine();
        }
    }
}
