using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public enum gameState { mainMenu, playing, winScreen, loseScreen };
    public enum intervalType { days=0, weeks, months, years };



    public class GameEngine
    {
        private LunarTime timeEngine;

        private long totalTime;

        private DateTime _currentGameDate;
		public DateTime CurrentGameDate
		{
			get
			{
				return _currentGameDate;
			}
			set
			{
				_currentGameDate = value;
			}
		}

        public event EventHandler<UpdateTurn> UpdateEverything;

        public gameState currentState
        {
            get;
            set;
        }

        public GameEngine()
        {
            BuildingManager allBuildings;
            allBuildings = new BuildingManager();
            UpdateEverything = new EventHandler<UpdateTurn>(allBuildings.Update);

            _currentGameDate = new DateTime(2050, 1, 1);
        }

        
        public void RunGame()
        {
            totalTime = 0;

            while (true)
            {

            }
        }

        public void setWin(object o, EventArgs e)
        {
            currentState = gameState.winScreen;

            //mainWindow = new WinScreen();
        }

        public void setLose(object o, EventArgs e)
        {
            currentState = gameState.loseScreen;
            //mainWindow = new LoseScreen();
        }

        public void setPlaying(object o, EventArgs e)
        {
            currentState = gameState.playing;
            //mainWindow = new PlayScreen();
        }

        public void setMain(object o, EventArgs e)
        {
            currentState = gameState.mainMenu;
            //mainWindow = new PlayScreen();
        }


        //The user clicked the turn complete button, increase the amount of time passed, and fire off the update everything using the current time interval as an argument
        public void TurnStart(object o, EventArgs e)
        {
            //totalTime = totalTime + interval;
            int timeToPass =0; //= e as timeCounter;
            intervalType curIntervalType = intervalType.days;
            //

            if (curIntervalType == intervalType.days)
            {
                _currentGameDate = _currentGameDate.AddDays(timeToPass);
            }

            else if (curIntervalType == intervalType.weeks)
            {
                _currentGameDate = _currentGameDate.AddDays(timeToPass * 7);
                timeToPass = timeToPass * 7;
            }

            else if (curIntervalType == intervalType.months)
            {
                _currentGameDate = _currentGameDate.AddMonths(timeToPass);
                timeToPass = timeToPass * 30;
            }

            else if (curIntervalType == intervalType.years)
            {
                _currentGameDate = _currentGameDate.AddYears(timeToPass);
                timeToPass = timeToPass * 365;
            }

            if (timeToPass == 0)
            {
                timeToPass = 30;
                _currentGameDate = _currentGameDate.AddDays(timeToPass);
            }
            //The update method should just go off of the number of days passed. Don't need to worry about months/years
            UpdateEverything(this, new UpdateTurn(timeToPass));
        }

  
    }

    public class UpdateTurn : EventArgs
    {
        public UpdateTurn(long interval)
        {
            Interval = interval;
        }

        public long Interval
        {
            get;
            private set;
        }
    }
}
