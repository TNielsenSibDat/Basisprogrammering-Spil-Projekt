using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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
                    TicTacToe();
                    break;

                case "Quit":
                    break;
            

                
                }

            



            //Funktioner til første spil


            //Funktioner til andet spil
     
        
      
            
       }
        private static void GætTallet()
        {
      
        }

        private static void TicTacToe()
        {
            Console.WriteLine("Velkommen til kryds og bolle!");
            Console.WriteLine();
            string[,] spilBræt = new string [3, 3]; //opretter et 2 dimensionelt array

            Console.WriteLine("For at vælge hvor du vil sætte X skal du skrive \nkoordinaterne på det felt du vil sætte tegnet i \nHer ser du koordinaterne på felterne:");

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    spilBræt[x, y] = Convert.ToString(x) + "," + Convert.ToString(y);
                }
            }

            TicTacToeBræt(spilBræt);

            Console.WriteLine("Hvis du gerne vil sætte X i midten skriver du dermed '1' ved X koordinat og '1' ved y koordinat");
            Console.WriteLine("Tryk på Enter for at starte spillet");
            Console.ReadLine();
            Console.Clear();
            //Opretter en forloop der genererer spilbrættet ved at tildele arrayet spilBræt et "." på hvert index
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    spilBræt[x, y] = ".";
                }
            }

            TicTacToeBræt(spilBræt);

            TicTacToeVælg(); //sæt koden ind i den der i stedet for når koden til valget er done

            Console.WriteLine("Hvor vil du sætte et X?");
            Console.WriteLine("Vælg koordinat på x aksen (skriv 0, 1 eller 2) ");
            int xKoordinat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vælg koordinat på y aksen (skriv 0, 1 eller 2) ");
            int yKoordinat = Convert.ToInt32(Console.ReadLine()); //lav måske et if statement ting hvor man bliver spurgt om man er sikker på sit valg hvor der vises et board hvor man har sat sit felt og blive dermed spurgt om det er der man gerne vil sætte sit tegn - så tjekker den med et if statement og man trykkede ja eller nej og reverter tilbage til valget hvis man trykkede nej
            spilBræt[xKoordinat, yKoordinat] = "X";
            TicTacToeBræt(spilBræt);


        }

        private static void TicTacToeVælg()
        {

        }

        private static void TicTacToeBræt(string[,] spilBræt)
        {

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(spilBræt[x, y] + " "); //udskriver index x og y og lægger en string med et mellemrum til
                }

                Console.WriteLine(); //laver et linebreak efter hele rækken af "." er udskrevet
            }


            Console.WriteLine("");

        }
    } 
 
}



