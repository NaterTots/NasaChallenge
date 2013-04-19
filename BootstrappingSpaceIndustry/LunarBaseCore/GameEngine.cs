﻿using System;
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
        public static EventHandler timerTicks;
        //Window mainWindow;


        static GameEngine()
        {

            //timerTicks.AddHandler(LunarTime.TimeTick, new RoutedEventHandler(OnTimerTick));
            
           
        }

        
        public void RunGame()
        {
            totalTime = 0;
            timeEngine = new LunarTime();

            //onTimerStart(this, new TickEventArgs(0));

            setMain();
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

        public void setPlaying()
        {
            currentState = gameState.playing;
            //mainWindow = new PlayScreen();
        }

        /*
        public void setLose()
        {
            currentState = gameState.loseScreen;
            //mainWindow = new LoseScreen();
        }*/

        public void setMain()
        {
            currentState = gameState.mainMenu;
            //mainWindow = new PlayScreen();
        }


        //Start the game loop
        public void TurnStart()
        {
            timeEngine.Start();
        }

        //this is the game loop that starts when the user clicks go
        public void OnTimerTick(object o, EventArgs e)
        {
            totalTime += 1;

            if (totalTime >= intervals)
            {
                //timeEngine.Pause();

                //structEngine.update(totalTime);

                totalTime = 0;
            }
        }
    }
}
