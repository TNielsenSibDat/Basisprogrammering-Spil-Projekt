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
            //Kode til menu - måske smid dette ind i en funktion så vi kan kalde den når et bestemt spil skal afsluttes for at vende tilbage til menuen

            

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
            TicTacToeClearBoard(spilBræt);

            TicTacToeBræt(spilBræt);

            

            
            int spillerVandt = 0;
            int computerVandt = 0;
            int antalSpil = 0;
            while (true)
            {

                TicTacToeVælg(spilBræt);
                // string[,] computerValg = TicTacToeComputerValg();
                Console.WriteLine("Computeren vælger:");
                
                TicTacToeComputerValg(spilBræt);

                
                spillerVandt = TicTacToeCheckVinder("X", spilBræt);
                computerVandt = TicTacToeCheckVinder("O", spilBræt);
                antalSpil += 1;
                Console.WriteLine(antalSpil % 3);


                //luk det her inde i et form for while loop som kører så længe at der ikke er nogen der har vundet ved at flytte brikker endnu
                if (spillerVandt == 0 && computerVandt == 0 && antalSpil % 3 == 0) //der går noget galt med matematikken her tror jeg - når man går i gang med andet spil får man lov at sætte 4 x'r og 3. spil bliver man allerede bedt om at flytte en brik efter første move?
                {
                    antalSpil -= 1; //tror dette fiksede mit problem for nu forbliver den der modulus condition true så længe at der ikke er nogen der har vundet - tror bare jeg skal have fikset det der gøgl med at brættet ikke vises ordentligt osv
                    
                    Console.WriteLine("Hej");
                    //få bruger til at vælge et felt der har data - så omvendt af det tjek der checker om der er data i et felt og siger nej hvis der er - nu skal den kun gå videre i koden hvis der faktisk er data
                    TicTacToeSpillerFlyt(spilBræt);
                    TicTacToeComputerFlyt(spilBræt);
                    //TicTacToeBræt(spilBræt);

                } else if (spillerVandt != 0 || computerVandt != 0)
                {
                    TicTacToeClearBoard(spilBræt);
                    antalSpil = 0;
                }

            }











            /*
             
             tjek til at der ikke står noget der hvor spiller/computer prøver at sætte noget:

            if(spilBræt[x,y] != ".") //tjekker om det felt der forsøges udfyldt har en anden værdi en "." altså om feltet er fyldt ud med enten X eller O
            {
                
            }
             
             */


        }
        
        
        private static string[,] TicTacToeClearBoard(string[,] bræt)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    bræt[x, y] = ".";
                    
                }
            }
            return bræt;
        }
        private static int TicTacToeCheckVinder(string input, string[,] board)
        {
         
            //tjekker alle rækker for om nogen har vundet
            if (board[0,0] == input && board[0,1] == input && board[0,2] == input)
            {
               if(input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
                
            }

            if (board[1, 0] == input && board[1, 1] == input && board[1, 2] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            if (board[2, 0] == input && board[2, 1] == input && board[2, 2] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            //tjekker rækker
            if (board[0, 0] == input && board[1, 0] == input && board[2, 0] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            if (board[0, 1] == input && board[1, 1] == input && board[2, 1] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            if (board[0, 2] == input && board[1, 2] == input && board[2, 2] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            //tjekker om spiller vandt diagonalt
            if (board[0, 0] == input && board[1, 1] == input && board[2, 2] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            if (board[2, 0] == input && board[1, 1] == input && board[0, 2] == input)
            {
                if (input == "X")
                {
                    TicTacToeSpillerVinder();
                    return 1;
                }
                else
                {
                    TicTacToePCVinder();
                    return 2;
                }
            }

            return 0;

            /* //SEJ METODE TIL AT TJEKKE VINDER - LAV FÆRDIG HVIS TID 

             //lav et eller andet med at den trækker dataet fra index 0,0 0,1 0,2 også merger lårtet sammen til en string som vi kan bruge i switchen til at tjekke maybe?

             string resultat = "";
             int threshold = 0; //vores threshold for at vinde er at der er 3 streg - denne tæller op hver gang der er sat et tegn

             //Her er en for loop der tjekker om computeren vinder ved at sætte en lodret streg i første kolonne - den tjekker for hver iteration om der på index i,0 er sat et 0 hvis der er tælles threshold op - hvis threshold når 3 vil det sige at der er fundet en vinder og vinder funktionen kaldes
             for(int i = 0; i < 3; i++)
             {
                 Console.WriteLine(board[i,0]);
                 if (board[i, 0] == "O")
                 {
                     threshold += 1;

                 }


             }

             switch (threshold)
             {
                 case 3:
                     TicTacToeSpillerVinder();
                     break;
             }

             */

        }


        private static void TicTacToePCVinder()
        {
            //Console.Clear();
            Console.WriteLine("Computeren vandt!");
            
        }

        private static void TicTacToeSpillerVinder()
        {
            //Console.Clear();
            Console.WriteLine("Spilleren vandt!");
        }

        private static void TicTacToeComputerValg(string[,] bræt)
        {
            //måske hardcode nogle valg - fx start med at sæt et tegn i midten hvis det ikke er optaget - ellers gå til random selection hvis datapunktet er optaget

            Random random = new Random();
            bool optagetData = true;

            while(optagetData) 
            {
                int x = random.Next(0, 3);
                int y = random.Next(0, 3);
                if (bræt[y, x] != ".")
                {
                    Console.WriteLine("Computeren valgte et felt hvor der allerede var data");

                    
                }
                else
                {
                    bræt[y, x] = "O";
                    optagetData = false;
                    TicTacToeBræt(bræt);

                }

                //TicTacToeCheckVinder("O", bræt);
            }

        }

        private static void TicTacToeComputerFlyt(string[,] bræt)
        {
            Random random = new Random();
            
            bool optagetData = true;

            while (optagetData)
            {
                int x = random.Next(0, 3);
                int y = random.Next(0, 3);
                if (bræt[y, x] == "O")
                {
                    
                    bræt[y, x] = ".";
                    optagetData = false;

                }
                else
                {
                    Console.WriteLine("valgte forkert");
                    


                }
            }
           


        }


        private static void TicTacToeVælg(string[,] spilBræt)
        {
            Console.WriteLine("Hvor vil du sætte et X?");
            Console.WriteLine("Vælg koordinat på x aksen (skriv 0, 1 eller 2) ");
            int xKoordinat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vælg koordinat på y aksen (skriv 0, 1 eller 2) ");
            int yKoordinat = Convert.ToInt32(Console.ReadLine()); //lav måske et if statement ting hvor man bliver spurgt om man er sikker på sit valg hvor der vises et board hvor man har sat sit felt og blive dermed spurgt om det er der man gerne vil sætte sit tegn - så tjekker den med et if statement og man trykkede ja eller nej og reverter tilbage til valget hvis man trykkede nej
            if (spilBræt[yKoordinat, xKoordinat] != ".")
            {
                Console.WriteLine("Din giraf");
            }
            else
            {
                spilBræt[yKoordinat, xKoordinat] = "X"; //rundt om dette skal if statementet der tjekker om feltet allerede er fyldt ud nok være - 

            }


            TicTacToeBræt(spilBræt);

        }

        private static void TicTacToeSpillerFlyt(string[,] spilBræt)
        {
            Console.WriteLine("Nu skal vælge hvilken en af dine 'brikker?' du vil flytte");
            Console.WriteLine("Hvilket X vil du flytte?");
            Console.WriteLine("Vælg koordinat på x aksen (skriv 0, 1 eller 2) ");
            int xFlyt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vælg koordinat på y aksen (skriv 0, 1 eller 2) ");
            int yFlyt = Convert.ToInt32(Console.ReadLine());
            if (spilBræt[yFlyt, xFlyt] == "X")
            {
                spilBræt[yFlyt, xFlyt] = ".";

            }
            else
            {
                //rundt om dette skal if statementet der tjekker om feltet allerede er fyldt ud nok være - 
                Console.WriteLine("din giraf");
            }

            TicTacToeBræt(spilBræt);
        }

        private static void TicTacToeBræt(string[,] Bræt)
        {

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(Bræt[x, y] + " "); //udskriver index x og y og lægger en string med et mellemrum til
                }

                Console.WriteLine(); //laver et linebreak efter hele rækken af "." er udskrevet
            }



            Console.WriteLine("");

        }
    } 
 
}



