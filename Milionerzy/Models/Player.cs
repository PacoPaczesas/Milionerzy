using System;
using System.Collections.Generic;
using System.Linq;
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
            Score = 0;
        }


        public string Name { get; set; }
        public int Score { get; set; }
        public char Answer { get; set; }
        public bool FiftyFifty { get; set; }
        public bool Telephone { get; set; }
        public bool Audience { get; set; }

        public void GoodAnswer()
        {
            Score++;
        }

        public bool CanUseTelephone()
        {
            if (Telephone)
            {
                Console.WriteLine("E: telefon do przyjaciela");
                return true;
            }
            return false;
        }

        public char CallFriend(Question question)
        {
            Telephone = false;
            Console.WriteLine("Twój przyjaciel odpowiada, że prawidłowa odpowiedź to: " + question.CorrectAnswer);
            Console.WriteLine("Przypomnę pytanie");
            Console.WriteLine("Pytanie: " + question.Content);
            Console.WriteLine("Odpowiedzi:");
            Console.WriteLine(question.AnswerA);
            Console.WriteLine(question.AnswerB);
            Console.WriteLine(question.AnswerC);
            Console.WriteLine(question.AnswerD);
            char answer = char.ToUpper(Console.ReadKey().KeyChar);
            return answer;
        }






        public int Prize()
        {
            /*
            500
            1000*
            2000
            5000
            10000
            20000
            40000*
            75000
            125000
            250000
            500000
            1000000*
            */
            if (Score < 2)
            {
                return 0;
            }
            else if (Score < 7)
            {
                return 1000;
            }
            else if (Score < 12)
            {
                return 40000;
            }
            else
            {
                return 1000000;
            }
        }

    }
}


