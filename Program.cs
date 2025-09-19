using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Basisprogrammering_Spil_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

            //Kode til menu


            



            //Funktioner til første spil


            //Funktioner til andet spil
     
        
       
            
       }
        private static void Menu(){


            Console.WriteLine("Velkommen til!");


            Console.WriteLine("Tryk 1 for det ene spil");
            Console.WriteLine("Tryk 2 for det andet spil");
            Console.WriteLine("Tryk 3 for det tredje spil");
            Console.WriteLine("Tryk Quit for at afslutte spillet");
            string spillerValg = Console.ReadLine();

            switch (spillerValg)
            {
                case "1":
                    GætTallet();
                    break;


                case "2":
                    break;

                case "3":

                    GætTallet2_0();
                    break;

                case "Quit":
                    break;



            }

        }

        private static void GætTallet()
        {
            // 1. Gæt et tilfældigt tal mellem 1 og 10
            Random random = new Random();
            int hemmeligtTal = random.Next(1, 11); // 1 til 10
            bool gættetRigtigt = false;

            Console.WriteLine("Jeg har tænkt på et tal mellem 1 og 10.");
            Console.WriteLine("Kan du gætte hvilket?");

            // 2. Spilleren skal gætte indtil det er rigtigt
            while (!gættetRigtigt)
            {
                Console.Write("Skriv dit gæt: ");
                string input = Console.ReadLine();    // læs fra tastaturet
                int gæt = Convert.ToInt32(input);     // lav tekst om til tal

                // 3. Tjek om gættet er rigtigt
                if (gæt == hemmeligtTal)
                {
                    Console.WriteLine("Tillykke! Du gættede rigtigt 🎉");
                    gættetRigtigt = true;
                }
                else if (gæt < hemmeligtTal)
                {
                    Console.WriteLine("For lavt, prøv igen.");
                }
                else
                {
                    Console.WriteLine("For højt, prøv igen.");
                }
            }

            Console.WriteLine("Tak fordi du spillede!");
            Console.ReadKey(); // venter på at du trykker en tast

            //Random random = new Random(); → laver et objekt, som kan finde tilfældige tal.

            //random.Next(1, 11) → finder et tal mellem 1 og 10(11 er eksklusiv).

            //Console.WriteLine(...) → skriver tekst på skærmen.

            //Console.ReadLine() → læser hvad du skriver på tastaturet.

            //Convert.ToInt32(...) → laver det, du skriver, om til et tal.

            //while (!gættetRigtigt) → gentager koden indtil du har gættet rigtigt.

            //if / else if / else → styrer hvad der sker afhængigt af dit gæt.
        }
        private static void GætTallet2_0()

            // Spil nr 2 Alaa
        {   //Denne kommando gør at skærmen viser "GÆT ET TAL 2.0, NÅR MAN ÅBNER
            Console.WriteLine("=== GÆT ET TAL 2.0 ===");
            Console.WriteLine("vælg sværhedsgrad:");
            Console.WriteLine("1. Let (1.19, 5 forsøg)");
            Console.WriteLine("2. Middel (1-50, 7 forsøg)");
            Console.WriteLine("3. Svær (1-100, 10 forsøg)");
            Console.Write("Dit valg:");
            string valg = Console.ReadLine();

            int maxTal = 10;
            int maxForsøg = 5;
            
            switch (valg)

            {
                case "1":
                    maxTal = 10;
                    maxForsøg = 5;
                    break;
                case "2":
                    maxTal = 50;
                    maxForsøg = 7;
                    break;
                case "3":
                    maxTal 0 100;
                    maxForsøg = 10;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg, standard = Let.");
                    break;

            }

            Random rnd = new Random();
            int hemmeligtTal = rnd.Next(1, maxTal + 1);
            int forsøgTilbage = maxforsøg;
            bool gættetRigtigt = false;

            Console.WriteLine($"\nIndtast dit gæt: ");
            string input = console.ReadLine();

            if (int.TryParse(input, out int gaet))

            {
                forsøgTilbage--;

                if (gaet == hemmeligtTal)

                {
                    Console.WriteLine($"TILLYKKE! Du gættede rigtigt på {maxForsøg - forsøgTilbage} forsøg!");
                    gættetRigtigt = true;

                }
                else if (gaet < hemmeligtTal)
                {
                    Console.WriteLine("For lavt! Prøv et større tal.");

                }
                else
                {
                    Console.WriteLine("For højt! Prøv et mindre tak.");
                }
                if (!gættetRigtigt && forsøgTilbage > 0)

                {
                    Console.WriteLine($"Du har {forsøgTilbage} forsøg tilbage."); 
                }
             }
               else
            {
                Console.WriteLine("Det skal være et tal");
             
            }
                if (!gættetRigtigt)

            {
                Console.WriteLine($"\nØv :( Du løb tør for forsøg. Det rigtige tal var {hemmeligtTal}.");
            }

            Console.WriteLine("\nTryk på en tast for at afslutte..");
            Console.ReadKey();

          





            

         }

    }
}





    



