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
            //Kode til menu

            Console.WriteLine("Velkommen til!");
            

            Console.WriteLine("Tryk 1 for det ene spil");
            Console.WriteLine("Tryk 2 for det andet spil");
            Console.WriteLine("Tryk Quit for at afslutte spillet");
            string spillerValg = Console.ReadLine();

            switch (spillerValg)
            {
                case "1":
                    GætTallet();
                    break;
                    

                case "2":
                    break;

                case "Quit":
                    break;
            

                
                }

            



            //Funktioner til første spil


            //Funktioner til andet spil
     
        
      
            
       }
        private static void 
            GætTallet()
        {
            // 1. Lav et tilfældigt tal mellem 1 og 10
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
    }
}
       



