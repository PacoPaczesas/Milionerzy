using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
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
            questionList.Clear();
            string filePath = "C:\\Users\\jakub\\OneDrive\\Pulpit\\projekty c#\\Milionerzy\\Pytania1.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Plik z pytaniami nie istnieje.");
                Console.ReadKey();
                return;
            }

            // Otwieram plik do odczytu
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                Question nextQuestion = null;

                // sprawdzam "!= null" ponieważ w przypadku końca pliku ostatania, nieistniejąca w pliku linia będzie zawracana jaku null co jest równoznaczne z zakończeniem odczytywania - odczytano już cały plik.
                while ((line = sr.ReadLine()) != null)
                {
                    // tutaj pomijam puste linie, które są w pliku. W znaczeniu linia jest pusta ale nie jest to wartość null jak powyżej.
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    if (line.StartsWith("Pytanie:"))
                    {
                        // Jeśli to nie jest pierwsze pytanie, dodaj poprzednie pytanie do listy
                        if (nextQuestion != null)
                        {
                            questionList.Add(nextQuestion);
                        }

                        nextQuestion = new Question();
                        nextQuestion.Content = line.Substring("Pytanie:".Length);
                    }
                    else if (line.StartsWith("Poprawna odpowiedź:"))
                    {
                        char correctAnswer = line[line.Length - 1];
                        nextQuestion.CorrectAnswer = correctAnswer;
                    }
                    else
                    {
                        char answerLetter = line[0];
                        string answerText = line
                        switch (answerLetter)
                        {
                            case 'a':
                                nextQuestion.AnswerA = answerText;
                                break;
                            case 'b':
                                nextQuestion.AnswerB = answerText;
                                break;
                            case 'c':
                                nextQuestion.AnswerC = answerText;
                                break;
                            case 'd':
                                nextQuestion.AnswerD = answerText;
                                break;
                            default:
                                Console.WriteLine("Błąd odczytu");
                                break;
                        }
                    }
                }

                // Dodaj ostatnie pytanie do listy już po zakończeniu pętli while
                if (nextQuestion != null)
                {
                    questionList.Add(nextQuestion);
                }

            }
        }


        public Question RandomQuestion()
        {
            Random random = new Random();
            int rnd = random.Next(questionList.Count);
            Question randomQuestion = questionList[rnd];
            questionList.RemoveAt(rnd);
            Console.WriteLine("usunięto pytanie. pozostąło pytań " + questionList.Count);
            return randomQuestion;
        }

        public bool NextRound(Player player)
        {
            Question question = RandomQuestion();
            char answer = 'o';
            List<string> answerList = new List<string>();
            answerList = question.CreateListWithAnswers(false);

            do
            {
                question.AskQuestion(answerList);
                player.HintsAvailable();
                Console.WriteLine("X: Rezygnuj i zgarnij aktualną pulę pieniędzy");
                answer = char.ToUpper(Console.ReadKey().KeyChar);

                if (answer == 'E' && player.Telephone)
                {
                    player.CallFriend(question);
                }
                if (answer == 'F' && player.Audience)
                {
                    player.AskAudience(question);
                }
                if (answer == 'G' && player.FiftyFifty)
                {
                    answerList = question.CreateListWithAnswers(true);
                    player.FiftyFifty = false;
                }
                if (answer == 'X')
                {
                    Console.WriteLine("Rezygnujesz i zgarniasz obecnie posiadaną pulę pieniędzy");
                    player.Resign = true;
                    Console.WriteLine("Prawidłową odpowiedzią na dane pytanie była odpowiedź: " + question.CorrectAnswer);
                }
            } while (answer != 'A' && answer != 'B' && answer != 'C' && answer != 'D' && answer != 'X');

            return answer == question.CorrectAnswer;
        }




    }
}
