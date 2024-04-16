using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Milionerzy.Mechanics
{
    internal class Menu
    {
        public static void WelcomeMenu()
        {
            Console.WriteLine("Witaj w grze Milionerzy");
            Console.WriteLine("Gra polega na odpowiadaniu na kolejne, coraz trudniejsze pytania i wygraniu 1 mln zł");
            Console.WriteLine("Komunikacja z grą odbywa się wprowadzając odpowiednie znaki w konsoli i zatwierdzając je przyciskiem enter");
            Console.WriteLine("Gra składa się z 15 pytań o rosnącej skali trudności. Podczas gry skorzystać będziesz mógł z trzech kół ratunkowych");
            Console.WriteLine("50 na 50 - usunięte zostaną dwie błędne propozycje odpowiedzi");
            Console.WriteLine("Telefon do przyjaciela - pamiętaj, przyjaciel nie zawsze zna prawidłową odpowiedź");
            Console.WriteLine("Pytanie do publiczności - pamiętaj, publiczność może się mylić");
        }

        public static int SelectFromMenu()
        {
            int chose;
            bool correctValue = false;

            do
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("1. NOWA GRA");
                Console.WriteLine("2. NAJLEPSZE WYNIKI");
                Console.WriteLine("3. WYJDŹ");
                Console.Write("Wybierz z menu i potwierdź ENTER: ");

                while (!int.TryParse(Console.ReadLine(), out chose))
                {
                    Console.WriteLine("Błędna wartość. Wprowadź wartość od 1 do 3 i potwierdź enter");
                }

                switch (chose)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    case 3:
                        return 3;
                    default:
                        Console.WriteLine("Błędna wartość. Wprowadź wartość od 1 do 3 i potwierdź enter");
                        break;
                }
            } while (correctValue);
            return 0;
        }
    }
}
