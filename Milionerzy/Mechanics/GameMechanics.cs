using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Milionerzy.Models;

namespace Milionerzy.Mechanics
{

    internal class GameMechanics
    {
        private List<Question> questionList = new List<Question>();

        public void LoadQuestions()
        {
            Question question1 = new Question();
            question1.Content = "Co jest stolicą Polski??";
            question1.AnswerA = "A: Warszawa";
            question1.AnswerB = "B: Gdańsk";
            question1.AnswerC = "C: Kraków";
            question1.AnswerD = "D: Poznań";
            question1.CorrectAnswer = 'A';
            questionList.Add(question1);

            Question question2 = new Question();
            question2.Content = "Pytanie 2?";
            question2.AnswerA = "Odpowiedź A";
            question2.AnswerB = "Odpowiedź B";
            question2.AnswerC = "Odpowiedź C";
            question2.AnswerD = "Odpowiedź D";
            question2.CorrectAnswer = 'A';
            questionList.Add(question2);

            Question question3 = new Question();
            question3.Content = "Pytanie 3?";
            question3.AnswerA = "Odpowiedź A";
            question3.AnswerB = "Odpowiedź B";
            question3.AnswerC = "Odpowiedź C";
            question3.AnswerD = "Odpowiedź D";
            question3.CorrectAnswer = 'A';
            questionList.Add(question3);
        }

        public Question RandomQuestion()
        {
            Random random = new Random();
            int rnd = random.Next(questionList.Count);
            Question randomQuestion = questionList[rnd];
            questionList.RemoveAt(rnd);
            return randomQuestion;
        }
        public bool AskQuestion(Player player)
        {
            Question question = RandomQuestion();
            Console.WriteLine("Pytanie: " + question.Content);
            Console.WriteLine("Odpowiedzi:");
            Console.WriteLine(question.AnswerA);
            Console.WriteLine(question.AnswerB);
            Console.WriteLine(question.AnswerC);
            Console.WriteLine(question.AnswerD);
            bool CanUseTelephone = player.CanUseTelephone();

            char answer = char.ToUpper(Console.ReadKey().KeyChar);

            if (answer == 'E' && CanUseTelephone)
            {
                answer = player.CallFriend(question);
            }


            return answer == question.CorrectAnswer;
        }




    }
}
