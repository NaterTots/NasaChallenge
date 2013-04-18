using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LunarBaseCore
{
	public enum TickInterval
	{
		Hour,
		Day,
		Week,
		Month,
		Year
	}

	public class LunarTime
	{
		private const int MillisecondsBetweenTicks = 1000;
		Timer _timer = null;
		public LunarTime()
		{
			_timer = new Timer(timerCallback, null, Timeout.Infinite, MillisecondsBetweenTicks);
            GameEngine bleh = new GameEngine();
            TimeTick += new EventHandler<TickEventArgs>(bleh.OnTimerTick);
		}

		private void timerCallback(object state)
		{
			if (!Paused)
			{
				if (TimeTick != null)
				{
					TimeTick(this, new TickEventArgs(CurrentInterval));
                    
				}
			}
		}

		public TickInterval CurrentInterval
		{
			get;
			set;
		}

		// Fired when a tick occurs - represents the interval CurrentInterval
		public event EventHandler<TickEventArgs> TimeTick;

		// You must call start when ready!  The timer is off by default.
		public void Start()
		{
			// This should fire after 1s and fire every 1 second after that?
			_timer.Change(MillisecondsBetweenTicks, MillisecondsBetweenTicks);
			
		}

		public void Pause()
		{
			Paused = true;
		}

		// Set to true when the sim is paused
		public bool Paused
		{
			get;
			private set;
		}

	}

	public class TickEventArgs : EventArgs
	{
		public TickEventArgs(TickInterval interval)
		{
			Interval = interval;
		}

		public TickInterval Interval
		{
			get;
			private set;
		}
	}
}
