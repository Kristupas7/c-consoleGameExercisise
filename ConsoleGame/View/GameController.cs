using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Game;

namespace ConsoleGame.View
{
    class GameController
    {
        public GameController()
        {

        }
        public void StartGame(GuiController guiController)
        {
            // init game
            GameScreen myGame = new GameScreen(30, 20);

            // fill game with game data.
            myGame.SetHero(new Hero(5, 5, "HERO"));

            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy(enemyCount, rnd.Next(0, 10), rnd.Next(0, 10), "enemy" + enemyCount));
                enemyCount++;
            }

            // render loop
            bool needToRender = true;

            do
            {
                // isvalom ekrana
                Console.Clear();
                myGame.Render();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (hashCode)
                    {
                        case 27: //ConsoleKey.Escape:
                            needToRender = false;
                            Console.Clear();
                            guiController.ShowMenu();
                            break;
                        case 39: // ConsoleKey.RightArrow:
                            myGame.GetHero().MoveRight();
                            Console.Clear();
                            myGame.Render();
                            break;
                        case 37: // ConsoleKey.LeftArrow:
                            myGame.GetHero().MoveLeft();
                            Console.Clear();
                            myGame.Render();
                            break;
                    }
                }


                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}

