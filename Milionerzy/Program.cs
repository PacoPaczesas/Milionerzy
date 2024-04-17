using Milionerzy.Mechanics;

Game.WelcomeMenu();
int gameMode;

do
{
    gameMode = Game.SelectFromMenu();
    switch (gameMode)
    {
        case 1:
            Game.StartNewGame();
            break;
        case 2:
            Console.WriteLine("Wyniki");
            break;
        case 3:
            Console.WriteLine("wyjscie");
            break;
    }
}   while (gameMode != 3); 

Console.ReadKey();
    