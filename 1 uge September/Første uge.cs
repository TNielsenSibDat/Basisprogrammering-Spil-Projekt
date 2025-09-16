using System;

public class Class1
{
	public Class1()
	{
	}
}
static void Main(string[] args)
{

    //denne kommando skriver hello world til skærmen når man åbner
    Console.WriteLine("Hello World");

    //denne kommando skriver "indtast brugernavn" 
    Console.WriteLine("Indtast brugernavn");

    //denne kommando gør at der rent faktisk reageres når jeg har tastet brugernavn
    string inputUsername = Console.ReadLine();

    //denne kommando gør jeg fortæller at jeg har 5 personer som jeg gerne vil have der skal ske noget med 
    String[] navne = new string[5];

    //denne kommando gør at computeren ved hvilke navne som er i denne liste 
    Console.WriteLine("Hannah" +
        "Ole" +
        "Jens" +
        "Alaa" +
        "sofie");
    //denne kommando fortæller computeren at det er okay at hoppe videre til password, hvis et af ovenstående navne er plottet ind
    Console.WriteLine("Indtast password");
    //denne kommando fortæller computeren at der så skal ske noget når et password er tastet ind rigtigt 
    string inputPassword = Console.ReadLine();

    //Denne kommando fortæller hvilke brugernavne som hører til hvilke passwords 
    switch (inputUsername)
        
        
        }
