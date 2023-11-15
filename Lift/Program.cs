using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{


    internal class Program
    {

        static List<Lifthasznalat> hasznalat = new List<Lifthasznalat>();
        static void Main(string[] args)
        {

            /*      var ell = File.ReadAllLines("lift.txt");
                  foreach(var sor in ell)
                  {
                      Console.WriteLine(sor);
                  }  */

            List<Lifthasznalat> hasznalat = new List<Lifthasznalat>();
            string[] sorok = File.ReadAllLines("lift.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] adat = sorok[i].Split(' ');
                DateTime idopont = Convert.ToDateTime(adat[0]);
                int sorszam = Convert.ToInt32(adat[1]);
                int indulo = Convert.ToInt32(adat[2]);
                int erkezo = Convert.ToInt32(adat[3]);

                Lifthasznalat hasznal = new Lifthasznalat(idopont, sorszam, indulo, erkezo);
                hasznalat.Add(hasznal);
            }

            // 3. feladat: Hány alkalommal használták a liftet?

            Console.WriteLine($"Összes lifthasználat: {hasznalat.Count}");

            // 4. feladat: A vizsgált időszak mettől meddig tartott?

            var rendezett = hasznalat.OrderBy(x => x.Idopont); //ha rendezett akkor ez nem kell!
            DateTime kezdoIdopont = rendezett.First().Idopont; //rendezett helyett liftAdatok
            DateTime vegIdopont = rendezett.Last().Idopont; //rendezett helyett liftAdatok

            Console.WriteLine($"4. feladat: Időszak: {kezdoIdopont.ToShortDateString()} - {vegIdopont.ToShortDateString()}");

            //5. feladat: Melyik volt a legnagyobb sorszámú célszint az időszakban?

            var legnagyobbSzamuCelszint = hasznalat.Max(x => x.Erkezo);
            Console.WriteLine($"5. feladat: Célszint max: {legnagyobbSzamuCelszint}");


            // 6. feladat: Kérje be a felhasználótól a kártya számát szöveges típusú adatként.
            //             A szöveges adatot próbálja numerikus egészre konvertálni, majd tárolni.
            //             A konverzió során fellépő hiba esetén oldja meg, hogy az 5-ös sorszámú
            //             kártya és/vagy az 5-ös célszint legyen beállítva. A megoldáshoz
            //             használjon védett blokkot (Pl. try-catch  szerkezetet).


            Console.WriteLine("6. feladat:");
            int kartyaszam;
            try
            {
                kartyaszam = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                kartyaszam = 5;
            }
            int celszint;
            try
            {
                celszint = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                celszint = 5;
            }
            Console.WriteLine($"\tKártya száma: {kartyaszam}");
            Console.WriteLine($"\tCélszint száma: {celszint}");


            //7. feladat: Döntse el, hogy az előző feladatba megadott számokkal utaztak-e
            //            a vizsgált időszakban.

            bool utaztak = false;

            foreach (var item in hasznalat)
            {
                if (item.Sorszam == kartyaszam && item.Erkezo == celszint)
                {
                    utaztak = true; break;

                }               
            }
            Console.WriteLine(utaztak ? $"A {kartyaszam}-s számú kártyával utaztak a {celszint}. emeletre." :
                                        $"A {kartyaszam}-s számú kártyával nem utaztak a {celszint}. emeletre.");

            //LINQ
            Console.WriteLine(hasznalat.Any(x => x.Sorszam == kartyaszam && x.Erkezo == celszint) ?
                             $"A {kartyaszam}-s számú kártyával utaztak a {celszint}. emeletre." :
                             $"A {kartyaszam}-s számú kártyával nem utaztak a {celszint}. emeletre.");


            // 8. feladat: Készítsen statisztikát a naponkénti lifthasználat számáról.
            //             A megoldást úgy készítse el, hogy az inputállományba később
            //             további napok adatai is bekerülhessenek. 

            Console.WriteLine("8. feladata: Statisztika");

            foreach(var napi in hasznalat.GroupBy(x=> x.Idopont))
            {
                Console.WriteLine($"{napi.Key} - {napi.Count()}x");
            }

            
            Console.WriteLine(new string('─', 60));   // ez egy elválasztó vonal, h ne olvadjon össze a két megoldás.

            // LINQ
            hasznalat.GroupBy(x => x.Idopont).ToList().ForEach(x => Console.WriteLine($"{x.Key} - {x.Count()}x"));
        }
    }
}
           
