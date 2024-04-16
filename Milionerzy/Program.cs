using Milionerzy.Mechanics;

Menu.WelcomeMenu();

int gameMode;
do
{
    gameMode = Menu.SelectFromMenu();
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
    