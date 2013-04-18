using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public enum gameState { mainMenu, playing, winScreen, loseScreen };


    public class GameEngine
    {
        LunarTime timeEngine;

        long totalTime;

        int intervals;

        public gameState currentState
        {
            get;
            set;
        }

        //StructureEngine structs;
        public EventHandler timerTicks;

        static GameEngine()
        {

            //timerTicks.AddHandler(LunarTime.TimeTick, new RoutedEventHandler(OnTimerTick));
        }

        //this is the game loop
        public void RunGame()
        {
            totalTime = 0;
            timeEngine = new LunarTime();
            currentState = gameState.mainMenu;

            while (currentState != gameState.winScreen || currentState != gameState.loseScreen)
            {
                if (currentState == gameState.mainMenu)
                {
                    //mainWindow = new mainScreen();
                }

                else if (currentState == gameState.playing)
                {
                    //mainWindow = new PlayingScreen();
                }

                else if (currentState == gameState.loseScreen)
                {
                    //mainWindow = new LoseScreen();
                }

                else if (currentState == gameState.winScreen)
                {
                    //mainWindow = new WinScreen();
                }
            }

        }

        public void setWin()
        {
            currentState = gameState.winScreen;

            //mainWindow = new WinScreen();
        }

        public void setLose()
        {
            currentState = gameState.loseScreen;
            //mainWindow = new LoseScreen();
        }

        public void TurnStart()
        {
            timeEngine.Start();
        }

        private void OnTimerTick()
        {
            totalTime += 1;

            if (totalTime >= intervals)
            {
                timeEngine.Pause();

                //structEngine.update(totalTime);

                totalTime = 0;
            }
        }
    }
}
