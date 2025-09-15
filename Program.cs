using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private static void GætTallet()
        {
      
        }
    } 
 
}



