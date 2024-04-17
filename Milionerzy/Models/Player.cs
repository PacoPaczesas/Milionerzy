using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Milionerzy.Models
{
    internal class Player
    {
        public Player()
        {
            Console.WriteLine("Wprowadź imie gracza:");
            Name = Console.ReadLine();
            FiftyFifty = true;
            Telephone = true;
            Audience = true;
            Resign = false;
            Score = 0;
            Winner = false;
        }


        public string Name { get; set; }
        public int Score { get; set; }
        public char Answer { get; set; }
        public bool FiftyFifty { get; set; }
        public bool Telephone { get; set; }
        public bool Audience { get; set; }
        public bool Resign { get; set; }
        public bool Winner { get; set; }

        private readonly int[] scoreToMoney = { 0, 500, 1000, 2000, 5000, 10000, 20000, 40000, 75000, 125000, 250000, 500000, 1000000, 999999999 };

        public void GoodAnswer()
        {
            Score++;
        }

        // Wyświetla dostępne koła ratunkowa
        public void HintsAvailable()
        {
            if (Telephone)
            {
                Console.WriteLine("E: telefon do przyjaciela");
            }
            if (Audience)
            {
                Console.WriteLine("F: Pytanie do publiczności");
            }
            if (FiftyFifty)
            {
                Console.WriteLine("G: 50 na 50");
            }
        }

        // koła ratunkowe
        public void CallFriend(Question question)
        {
            Telephone = false;
            Console.WriteLine("Twój przyjaciel odpowiada, że prawidłowa odpowiedź to: " + question.CorrectAnswer);

        }

        public void AskAudience(Question question)
        {
            Audience = false;
            Console.WriteLine("Publiczność głosuje: A: 80%, B: 10%: C: 7% D: 3%");
        }



        // wypłata nagrody
        /*
        500
        1000*gwarantowane
        2000
        5000
        10000
        20000
        40000*gwarantowane
        75000
        125000
        250000
        500000
        1000000*gwarantowane
        */
        public int Prize()
        {
            if (Resign)
            {
                return scoreToMoney[Score];
            }
            else if (Winner)
            {
                return scoreToMoney[12];
            }
            else
            {
                if (Score < 2)
                {
                    return scoreToMoney[0];
                }
                else if (Score < 7)
                {
                    return scoreToMoney[2];
                }
                else if (Score < 12)
                {
                    return scoreToMoney[7];
                }
                else
                {
                    return scoreToMoney[12];
                }
            }
        }
        public int NextQyestionPrize()
        {
            return scoreToMoney[Score + 1];
        }

        public void CheckIsWinner()
        {
            if (Score == 12) { Winner = true; }
        }

        public void EndGameResult()
        {
            if (Winner)
            {
                Console.WriteLine("Brawo, wygrałeś 1 mln zł! KONIEC GRY");
            }
            else if (Resign)
            {
                Console.WriteLine("Zrezygnowałeś z dalszej try. Twoja wygrana to " + Prize() + " zł. KONIEC GRY");
            }
            else
            {
                Console.WriteLine("Błędna odpowiedź. Wygrywasz: " + Prize() + "zł. KONIEC GRY");
            }
        }


    }
}


