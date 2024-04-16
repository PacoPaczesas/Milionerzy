using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milionerzy.Models;

namespace Milionerzy.Mechanics
{
    internal class Game
    {
        public static void StartNewGame()
        {
            GameMechanics gameMechanics = new GameMechanics();
            Player player = new Player();
            bool answer;
            gameMechanics.LoadQuestions();

            do
            {
                if (player.Score == 0)
                {
                    Console.WriteLine("Zaczynamy grę.");
                }
                else
                {
                    Console.WriteLine("Pora na kolejne pytanie");
                }


                answer = gameMechanics.AskQuestion(player);
                if (answer)
                {
                    player.GoodAnswer();
                    Console.WriteLine("Dobra odpowiedź.");
                }
                else
                {
                    Console.WriteLine("Błędna odpowiedź. Koniec gry. Twoja wygrana to {0}", player.Prize());
                }

            } while (answer);
        }
    }
}
