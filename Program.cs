using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
        RestartPoint:
            //Zufallszahlgeneration
            Random myObject = new Random();
            int ranNum = myObject.Next(1, 100);

            //Versuche
            int tries = 0;
            int maxtries = 10;

            //Textfarbe
            Console.ForegroundColor = ConsoleColor.Cyan;


            //solange Anzahl Versuche kleiner ist als Anzahl erlaubte Versuche lauft diese Schleife
            while (tries < maxtries)
            {
                Console.WriteLine("Es wurde eine zufällige Zahl generiert. Sie müssen diese nun erraten.");
                Console.WriteLine("Geben Sie eine natürliche, geschätzte Zahl zwichen 1 und 100 ein: ");
                int userGuess = 0;
                string userInput = Console.ReadLine();


                if (!int.TryParse(userInput, out userGuess))
                {
                    Console.WriteLine("Bitte geben Sie nur natürliche Zahlen zwischen 1 und 100 ein.");
                    PressToContinue();
                    Console.Clear();
                    continue;
                }

                else if (Int32.Parse(userInput) < 1 || Int32.Parse(userInput) > 100)
                {
                    Console.WriteLine("Bitte geben Sie nur natürliche Zahlen zwischen 1 und 100 ein.");
                    PressToContinue();
                    Console.Clear();
                    continue;
                }

                tries++;

                if (userGuess == ranNum)
                {
                    Console.WriteLine("Sie haben es geschafft die Geheimzahl zu erraten!");
                    Console.WriteLine("Es brauchte " + tries + " Versuche.");
                    tries = maxtries + 2;
                    //hier wird der Output für game over wird übersprungen
                    //aus irgendeinem Grund brauchte es +2 anstatt nur ++
                }

                else if (userGuess < ranNum)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Die eingegebene Zahl ist kleiner als die Geheimzahl.");
                }

                else if (userGuess > ranNum)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Die eingegebene Zahl ist grösser als die Geheimzahl.");
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                PressToContinue();
                Console.Clear();
            }

            //game over
            if (tries == maxtries)
            {
                Console.WriteLine("Sie haben es leider nicht in den 10 Versuchen geschafft :(");
            }

        Request:
            Console.WriteLine("Möchten Sie nochmal spielen? Geben Sie Ihre Antwort ein:\n[ja|nein]");
            string answer = Console.ReadLine().ToLower(); //Antwort kann auch mit Grossbuchstaben angegeben werden

            if (answer == "ja")
            {
                Console.Clear();
                goto RestartPoint;
            }
            else if (answer == "nein")
            {
                goto Exit;
            }
            else
            {
                Console.WriteLine("Ihre Antwort war zu unklar. Bitte antworten Sie nur mit 'ja' oder 'nein'.");
                PressToContinue();
                Console.Clear();
                goto Request;
            }

        Exit:
            PressToContinue();
        }

        public static void PressToContinue()
        {
            Console.WriteLine("Drücken Sie eine beliebige Taste um fortzufahren...");
            Console.ReadKey();
            Console.Clear();

            //Ich habe diese Funktion für den Fall von Wiederholung geschrieben.
            //So muss ich nur ein Wort mit Tab ergänzen anstatt zwei Zeilen zu schreiben.
        }

    }
}
