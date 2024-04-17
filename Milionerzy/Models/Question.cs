using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionerzy.Models
{
    internal class Question
    {
        public string Content { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public char CorrectAnswer { get; set; }



        public List<string> CreateListWithAnswers(bool fiftyFiftyUsed)
        {
            List<string> answerList = new List<string>();
            answerList.Add(AnswerA);
            answerList.Add(AnswerB);
            answerList.Add(AnswerC);
            answerList.Add(AnswerD);

            // zwracam listę z czterema odpowiedziami
            if (!fiftyFiftyUsed)
            {
                return answerList;
            }

            // w przypadku skorzystania z 50/50 zwracam listę z dwoma odpowiedziami - jedną prawidłową i jedną błędną.
            else
            {
                Console.WriteLine("Skorzystano z koła ratunkowego 50/50. Dwie błędne odpowiedzi zostały usunięte");
                List<string> answerListWithTwoAnswers = new List<string>();
                if (CorrectAnswer == 'A')
                {
                    answerListWithTwoAnswers.Add(AnswerA);
                    answerList.RemoveAt(0);
                }
                else if (CorrectAnswer == 'B')
                {
                    answerListWithTwoAnswers.Add(AnswerB);
                    answerList.RemoveAt(1);
                }
                else if (CorrectAnswer == 'C')
                {
                    answerListWithTwoAnswers.Add(AnswerC);
                    answerList.RemoveAt(2);
                }
                else
                {
                    answerListWithTwoAnswers.Add(AnswerD);
                    answerList.RemoveAt(3);
                }
                Random random = new Random();
                int rnd = random.Next(answerList.Count);
                answerListWithTwoAnswers.Add(answerList[rnd]);

                return answerListWithTwoAnswers;
            }
        }
        public void AskQuestion(List<String> answerList)
        {
            Console.WriteLine("Pytanie: " + Content);
            Console.WriteLine("Odpowiedzi:");
            foreach (String answer in answerList)
            {
                Console.WriteLine(answer);
            }
        }


    }
}
