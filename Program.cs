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
            



            Menu(); //Kalder menu funktionen

            



            //Funktioner til første spil


            //Funktioner til andet spil
     
        
      
            
       }
        private static void GætTallet()
        {
      
        }

        private static void Menu(){
            Console.WriteLine("Velkommen til!"); //Udskriver velkomstbesked


            //Console.WriteLine udtryk der fremlægger valgmuligheder for spilleren:
            Console.WriteLine("Tryk 1 for det ene spil");
            Console.WriteLine("Tryk 2 for det andet spil");
            Console.WriteLine("Tryk Quit for at afslutte spillet");


            string spillerValg = Console.ReadLine(); //Console.ReadLine der gemmer spillerens input i en string variabel

            switch (spillerValg) //switch case over variablen spillerValg
            {
                //hvis spiller skriver 1:
                case "1":
                    GætTallet(); //Funktionen GætTallet() kaldes og spil 1 starter
                    break;

                //hvis spiller skriver 2:
                case "2":
                    TicTacToe(); //Funktionen TicTacToe() kaldes og spil 2 starter
                    break;

                //hvis spiller skriver Quit
                case "Quit": 
                    break; //programmet bryder ud af switch casen og slutter
            }
        }

        private static void TicTacToe() //Funktionen af typen void (returnerer ikke noget) oprettes
        {
            Console.WriteLine("Velkommen til kryds og bolle!"); //Udskriver velkomstbesked
            Console.WriteLine(); //laver et linebreak
            string[,] spilBræt = new string [3, 3]; //opretter et 2 dimensionelt array og tildeler det 3*3 pladser vi kan fylde data i

            Console.WriteLine("For at vælge hvor du vil sætte X skal du skrive \nkoordinaterne på det felt du vil sætte tegnet i \nHer ser du koordinaterne på felterne:"); //Udskriver beskrivelse af spillebrættet

            //for loop der udfylder vores spilBræt array med tal der svarer til det index i arrayet tallet lægges i 
            for (int x = 0; x < 3; x++) //opretter en for loop der kører sålænge tællevariablen x er mindre end 3 - efter hver iteration lægges 1 til x
            {
                for (int y = 0; y < 3; y++) //opretter en for loop inde i den første for loop der kører sålænge tællevariablen y er mindre end 3 - efter hver iteration lægges 1 til y
                {
                    spilBræt[x, y] = Convert.ToString(x) + "," + Convert.ToString(y); //her indsætter vi værdien af x og y på index x,y i vores 2 dimensionelle array. vi indsætter en string ',' mellem x og y så de er separeret - vi konverterer x og y variablerne til strings med Convert.ToString() funktionen da vores array er af typen string
                }
            }


            TicTacToeBræt(spilBræt); //kalder funktionen TicTacToeBræt og sender arrayet spilBræt med som parameter

            Console.WriteLine("Hvis du gerne vil sætte X i midten skriver du dermed '1' ved X koordinat og '1' ved y koordinat"); //udskriver vejledning til hvad man skal skrive
            Console.WriteLine("Tryk på Enter for at starte spillet"); //udskriver forklaring af hvordan man starter spillet
            Console.ReadLine(); //venter på input
            Console.Clear(); //bruger Console.Clear funktionen til at slette alt i konsollen så der ikke er så meget rod
            
            TicTacToeClearBoard(spilBræt); //kalder funktionen TicTacToeClearBoard og sender arrayet spilBræt med som parameter

            TicTacToeBræt(spilBræt); //kalder funktionen TicTacToeBræt og sender arrayet spilBræt med som parameter




            int spillerVandt = 0; //opretter en variabel af typen int kaldet spillerVandt som tildeles værdien 0
            int computerVandt = 0; //opretter en variabel af typen int kaldet computerVand som tildeles værdien 0
            int antalSpil = 0; //opretter en variabel af typen int kaldes antalSpil som tildeles værdien 0
            while (true) //opretter et while loop der kører uendeligt
            {

                TicTacToeVælg(spilBræt); //kalder funktionen TicTacToeVælg og sender spilBræt arrayet med som parameter
                Console.WriteLine("Computeren vælger:"); //udskriver besked der fortæller spilleren hvad computeren gør
                
                TicTacToeComputerValg(spilBræt); //kalder funktionen TicTacToeComputerValg og sender spilBræt arrayet med som parameter

                
                spillerVandt = TicTacToeCheckVinder("X", spilBræt); //tildeler spillerVandt variablen værdien af det som TicTacToeCheckVinder funktionen returnerer. TicTacToeCheckVinder funktionen tager en string "X" og arrayet spilBræt som parameter
                computerVandt = TicTacToeCheckVinder("O", spilBræt); //tildeler computerVandt variablen værdien af det som TicTacToeCheckVinder funktionen returnerer. TicTacToeCheckVinder funktionen tager en string "O" og arrayet spilBræt som parameter
                antalSpil += 1; //lægger 1 til antalSpil variablen
                


                //if statement der tjekker om variblerne spillerVandt og computerVandt begge er lig 0 samt om antalSpil delt i 3 giver en rest på 0
                if (spillerVandt == 0 && computerVandt == 0 && antalSpil == 3) // når spillerVandt og computerVandt er lig 0 betyder det at ingen har vundet endnu antalSpil skal være lig 3 da der kun kan være mulighed for at der skal flyttes plå brikker efter der er gået 3 runder (efter alle har lagt 3 brikker)
                {
                    antalSpil -= 1; //trækker 1 fra variablen antalSpil - dette medfører at når loopen gentager sig så vil antalSpil altid blive lig med 3 når den kommer til dette if statement - det skyldes at hvis der ikke er fundet nogen vinder efter spilleren og computeren har flyttet på deres første brik så skal dette if statement blive sandt igen så der kan flyttes endnu engang indtil der er fundet en vinder
                    
                    
                    //få bruger til at vælge et felt der har data - så omvendt af det tjek der checker om der er data i et felt og siger nej hvis der er - nu skal den kun gå videre i koden hvis der faktisk er data
                    TicTacToeSpillerFlyt(spilBræt); //Kalder funtkionen TicTacToeSpillerFlyt og sender arrayet spilBræt med som parameter
                    TicTacToeComputerFlyt(spilBræt); //kalder funktionen TicTacToeComputerFlyt og sender arrayet spilBræt med som parameter
                    

                } else if (spillerVandt != 0 || computerVandt != 0) //else if statement der tjekker om enten spillerVandt eller computerVandt ikker er lig med 0
                {
                    TicTacToeClearBoard(spilBræt); //hvis else if udtrykket er sandt kaldes funktionen TicTacToeClearBoard og arrayet spilBræt sendes med som parameter
                    antalSpil = 0; //antal spil variablen tildeles værdien 0 da spillet genstates
                }

            }

        }
        
        
        //TicTacToeClearBoard overskriver alle pladser i et array med et punktum - dette indikerer tomme pladser
        private static string[,] TicTacToeClearBoard(string[,] bræt) //Opretter funktionen TicTacToeClearBoard af typen string[,] (2 dimensionelt string array) der tager et 2 dimensionelt string array som parameter
        {
            for (int x = 0; x < 3; x++)  //for loop der kører så længe at tællervariablen x er mindre 3 - efter hver iteration lægges 1 til x
            {
                for (int y = 0; y < 3; y++) //for loop der kører så længe at tællervariablen y er mindre end 3 - efter hver iteration lægges 1 til y
                {
                    bræt[x, y] = "."; //index x,y i arrayet bræt tildeles værdien "."
                    
                }
            }
            return bræt; //returner arrayet bræt med de nye værdier
        }
        private static int TicTacToeCheckVinder(string input, string[,] board) //opretter funktionen TicTacToeCheckVinder af typen ind - den tager en string og et 2 dimensionelt string array som parameter
        {
         
            //tjekker alle rækker for om nogen har vundet
            if (board[0,0] == input && board[0,1] == input && board[0,2] == input) //if statement der checker om index 0.0, 0.1 og 0.2 i arrayet board er lig med stringen input
            {
               if(input == "X") //hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else //hvis input er noget andet end X
                {
                    TicTacToePCVinder(); //kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
                
            }

            if (board[1, 0] == input && board[1, 1] == input && board[1, 2] == input) //if statement der checker om index 1.0, 1.1 og 1.2 i arrayet board er lig med stringen input
            {
                if (input == "X") //hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            if (board[2, 0] == input && board[2, 1] == input && board[2, 2] == input)//if statement der checker om index 2.0, 2.1 og 2.2 i arrayet board er lig med stringen input
            {
                if (input == "X") //hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            //tjekker rækker efter vinder
            if (board[0, 0] == input && board[1, 0] == input && board[2, 0] == input)//if statement der checker om index 0.0, 1.0 og 2.0 i arrayet board er lig med stringen input
            {
                if (input == "X")//hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            if (board[0, 1] == input && board[1, 1] == input && board[2, 1] == input)//if statement der checker om index 0.1, 1.1 og 2.1 i arrayet board er lig med stringen input
            {
                if (input == "X")//hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            if (board[0, 2] == input && board[1, 2] == input && board[2, 2] == input)//if statement der checker om index 0.2, 1.2 og 2.2 i arrayet board er lig med stringen input
            {
                if (input == "X")//hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            //tjekker efter vinder diagonalt
            if (board[0, 0] == input && board[1, 1] == input && board[2, 2] == input) //if statement der checker om index 0.0, 1.0 og 2.0 i arrayet board er lig med stringen input
            {
                if (input == "X")//hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            if (board[2, 0] == input && board[1, 1] == input && board[0, 2] == input)//if statement der checker om index 2.0, 1.1 og 0.2 i arrayet board er lig med stringen input
            {
                if (input == "X")//hvis input == "X" altså hvis det er 3 X i streg er det spilleren der har vundet
                {
                    TicTacToeSpillerVinder(); //kalder funktionen TicTacToeSpillerVinder() hvis if statement er sandt
                    return 1; //returnerer 1
                }
                else//hvis input er noget andet end X
                {
                    TicTacToePCVinder();//kalder funktionen TicTacToePCVinder
                    return 2; //returnerer 2
                }
            }

            return 0; //Returnerer 0 hvis ingen af de foregående if statements bliver true

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


        private static void TicTacToePCVinder() //opretter funktionen TicTacToePCVinder af typen void
        {
            
            Console.WriteLine("Computeren vandt!"); //udskriver en besked der fortæller spilleren af computeren vandt
            Console.WriteLine("Vil du spille igen eller tilbage til menuen?");//udskriver spørgsmål til spilleren
            Console.WriteLine("Skriv 'ja' eller 'tilbage' "); //udskriver valgmuligheder
            while (true) //opretter et while loop der gentager sig uendeligt medmindre der brydes ud af loopen
            {
                string svar = Console.ReadLine(); //gemmer brugerens input i en string variabel kaldet svar

                switch (svar) //opretter en switch case over variablen svar
                {
                    case "ja": //hvis svar er lig med ja
                        break; // bryder ud af switch casen

                    case "tilbage": //hvis svar er lig med tilbage
                        Menu(); //kalder metoden Menu()
                        break; //bryder ud af switch casen

                    default: //hvis de 2 første cases ikke opfyldes
                        Console.WriteLine("Skriv venligst 'ja' eller 'tilbage'"); //udskriver en besked for at forklare spilleren hvad de skal skrive
                        continue; //sender programmet tilbage til starten af loopen
                }
                break;//bryder ud af loopen
            }
            
        }

        private static void TicTacToeSpillerVinder() //opretter TicTacToeSpillerVinder funktionen af typen void
        {
            
            Console.WriteLine("Spilleren vandt!"); //udskriver "Spilleren vandt"
            Console.WriteLine("Vil du spille igen eller tilbage til menuen?"); //udskriver spørgsmål til spilleren
            Console.WriteLine("Skriv 'ja' eller 'tilbage"); //udskriver valgmuligheder
            while (true) //opretter en switch case over variablen svar
            {
                string svar = Console.ReadLine(); //gemmer brugerens input i en string variabel kaldet svar

                switch (svar)//opretter en switch case over variablen svar
                {
                    case "ja"://hvis svar er lig med ja
                        break;// bryder ud af switch casen

                    case "tilbage"://hvis svar er lig med tilbage
                        Menu();//kalder metoden Menu()
                        break;//bryder ud af switch casen

                    default://hvis de 2 første cases ikke opfyldes
                        Console.WriteLine("Skriv venligst 'ja' eller 'tilbage'");//udskriver en besked for at forklare spilleren hvad de skal skrive
                        continue; //sender programmet tilbage til starten af loopen
                }
                break; //bryder ud af loopen
            }
        }

        private static void TicTacToeComputerValg(string[,] bræt) //opretter funktionen TicTacToeComputerValg af typen void der tager et 2 dimensionelt array som parameter
        {
            //måske hardcode nogle valg - fx start med at sæt et tegn i midten hvis det ikke er optaget - ellers gå til random selection hvis datapunktet er optaget

            Random random = new Random(); //opretter et objekt af klassen Random
            bool optagetData = true; //opretter en bool optagetData og tildeler den værdien true

            while(optagetData) //opretter en while loop der kører så længe at optagetData er true
            {
                int x = random.Next(0, 3); //opretter en variabel af typen int kaldet x - tildeles værdien af random.Next(0,3) - metoden Next() kaldes på objektet random - vælger et tilfældigt tal mellem 0 og 3
                int y = random.Next(0, 3); //opretter en variabel af typen int kaldet y - tildeles værdien af random.Next(0,3) - metoden Next() kaldes på objektet random - vælger et tilfældigt tal mellem 0 og 3
                if (bræt[y, x] != ".") // opretter et if statement der checker om index y,x i arrayet bræt ikke er lig "."
                {
                    //sker ikke andet end at loopen gentager sig
                }
                else //hvis index y,x i bræt arrayet er lig med "." kører koden i else
                {
                    bræt[y, x] = "O"; //tildeler index y,x værdien "O"
                    optagetData = false; //sætter optagetData variablen lig med false
                    TicTacToeBræt(bræt); //kalder funktionen TicTacToeBræt og sender parameteren bræt med

                }

               
            }

        }

        private static void TicTacToeComputerFlyt(string[,] bræt) //opretter funktionen TicTacToeComputerFlyt af typen void som tager et 2 dimensionelt array som parameter
        {
            Random random = new Random(); //opretter et objekt af klassen Random

            bool optagetData = true;//opretter en bool optagetData og tildeler den værdien true

            while (optagetData)//opretter en while loop der kører så længe at optagetData er true
            {
                int x = random.Next(0, 3);//opretter en variabel af typen int kaldet x - tildeles værdien af random.Next(0,3) - metoden Next() kaldes på objektet random - vælger et tilfældigt tal mellem 0 og 3
                int y = random.Next(0, 3);//opretter en variabel af typen int kaldet y - tildeles værdien af random.Next(0,3) - metoden Next() kaldes på objektet random - vælger et tilfældigt tal mellem 0 og 3
                if (bræt[y, x] == "O") //if statement der checker om index y,x i arrayet bræt er lig med "O"
                {
                    
                    bræt[y, x] = "."; //tildeler værdien "." til arrayet bræt på index y,x
                    optagetData = false; //sætter bool'en optagetData lig med false

                }
                else //hvis det første udtryk ikke er sandt
                {
                   //sker ikke andet end at loopen kører igen
                }
            }
           


        }


        private static void TicTacToeVælg(string[,] spilBræt) //opretter funktionen TicTacToeVælg af typen void der tager et 2 dimensionelt array som parameter
        {
            string xKoorString; //opretter en string kaldet xKoorString
            int xKoordinat; //opretter en int kaldet xKoordinat
            string yKoorString; //opretter en string kaldet yKoorString
            int yKoordinat; //opretter en int kaldet yKoordinat
            while (true) //opretter et while loop der kører uendeligt medmindre noget bryder loopen
            {
                Console.WriteLine("Hvor vil du sætte et X?");//udskriver et spørgsmål til spilleren
                while (true) //opretter et while loop der kører indtil noget bryder loopen
                {
                    Console.WriteLine("Vælg koordinat på x aksen (skriv 0, 1 eller 2) "); //udskriver hvad brugeren skal inputte
                    xKoorString = Console.ReadLine(); //gemmer brugerens input i variablen xKoorString
                    if (int.TryParse(xKoorString, out xKoordinat) != true) //opretter et if statement der kører TryParse på xKoorString - udtrykket bliver true hvis TryParse metoden fejler og returnerer false
                    {
                        Console.WriteLine("Skriv et tal"); //udskriver besked til spilleren så de ved at de skal skrive et tal

                    }
                    else if (xKoordinat > 2) //hvis første betingelse ikke er sand tjekkes der om xKoordinat er større end 2
                    {
                        Console.WriteLine("Skriv venligts 0, 1 eller 2"); //hvis else if udtrykker er sandt udskrives der til spilleren at de skal skrive 0,1 eller 2

                    }
                    else //hvis de forrige udtryk er falske kører dette:
                    {
                        break; //bryder loopen 

                    }

                }

                while (true) //opretter et while loop der kører indtil noget bryder loopen
                {
                    Console.WriteLine("Vælg koordinat på y aksen (skriv 0, 1 eller 2) "); //udskriver hvad brugeren skal inputte
                    yKoorString = Console.ReadLine(); //gemmer brugerens input i variablen yKoorString
                    if (int.TryParse(yKoorString, out yKoordinat) != true) //opretter et if statement der kører TryParse på yKoorString - udtrykket bliver true hvis TryParse metoden fejler og returnerer false
                    {
                        Console.WriteLine("Skriv et tal");//udskriver besked til spilleren så de ved at de skal skrive et tal
                    }
                    else if (yKoordinat > 2) //hvis første betingelse ikke er sand tjekkes der om yKoordinat er større end 2
                    {
                        Console.WriteLine("Skriv venligst 0, 1 eller 2");//hvis else if udtrykker er sandt udskrives der til spilleren at de skal skrive 0,1 eller 2
                    }
                    else//hvis de forrige udtryk er falske kører dette:
                    {
                        break; //bryder loopen
                    }

                }

                if (spilBræt[yKoordinat, xKoordinat] != ".") //checker om index yKoordinat, xKoordinat i arrayet spilBræt ikke er lig "."
                {
                    Console.WriteLine("Vælg et felt der ikke er udfyldt"); //fortæller spilleren at de ikke må vælge et felt der allerede er udfyldt
                    
                }
                else //hvis det første udtryk ikke er true
                {
                    spilBræt[yKoordinat, xKoordinat] = "X"; //sætter index yKoordinat, xKoordinat i arrayet spilBræt lig med "X"
                    break; //bryder ud af loopen
                }

            }
  
            TicTacToeBræt(spilBræt); //kalder metoden TicTacToeBræt og sender det 2 dimensionelle array spilBræt med som parameter 

        }

        private static void TicTacToeSpillerFlyt(string[,] spilBræt)//opretter funktionen TicTacToeSpillerFlyt af typen void der tager det 2 dimensionelle array spilBræt som parameter
        {
            Console.WriteLine("Nu skal vælge hvilken en af dine 'brikker?' du vil flytte"); //udskriver en besked omkring hvad spilleren skal gøre
            Console.WriteLine("Hvilket X vil du flytte?"); //spørger spilleren om hvilket X de vil flytte
            Console.WriteLine("Vælg koordinat på x aksen (skriv 0, 1 eller 2) "); //udskriver et spørgsmål til spilleren
            int xFlyt = Convert.ToInt32(Console.ReadLine());  //gemmer brugerens input i variablen xFlyt - bruger Convert.ToInt32 for at konverterer inputtet fra en string til en int
            Console.WriteLine("Vælg koordinat på y aksen (skriv 0, 1 eller 2) ");//udskriver et spørgsmål til spilleren
            int yFlyt = Convert.ToInt32(Console.ReadLine());//gemmer brugerens input i variablen yFlyt - bruger Convert.ToInt32 for at konverterer inputtet fra en string til en int
            if (spilBræt[yFlyt, xFlyt] == "X")//checker om index yFlyt, xFlyt i arrayet spilBræt er lig "X"             //////////////////////////////skal fikse den her ligesom vælg funktionerne så man får fejl og prøv igen hvis man vælger noget invalid
            {
                spilBræt[yFlyt, xFlyt] = "."; //tildeler index yFlyt, xFlyt i arrayet spilBræt værdien "."

            }
            else //hvis første udsagn ikke er true
            {
                //rundt om dette skal if statementet der tjekker om feltet allerede er fyldt ud nok være - 
                Console.WriteLine("din giraf"); /////////////DETTE SKAL FIXES I MÅRN MAGTER FANDME ÆT LIGE NU
            }

            TicTacToeBræt(spilBræt); //kalder funktionen TicTacToeBræt og sender det 2 dimensionelle array spilBræt med som parameter
        }

        private static void TicTacToeBræt(string[,] Bræt) //opretter funktionen TicTacToeBræt() af typen void som tager det 2 dimensioneller array Bræt som parameter
        {
            //Opretter en forloop der genererer spilbrættet ved at tildele arrayet Bræt et "." på hvert index
            for (int x = 0; x < 3; x++) //for loopet kører så længe at tællevariablen x er mindre end 3. x forøges med 1 efter hver iteration
            {
                for (int y = 0; y < 3; y++) //for loopet kører så længe at tællevariablen y er mindre end 3. y forøges med 1 eter hver iteration
                {
                    Console.Write(Bræt[x, y] + " "); //udskriver index x, y og lægger en string med et mellemrum til
                }

                Console.WriteLine(); //laver et linebreak efter hele rækken af "." er udskrevet
            }

            Console.WriteLine(""); //udskriver et linebreak i slutningen af funktionen

        }
    } 
 
}



