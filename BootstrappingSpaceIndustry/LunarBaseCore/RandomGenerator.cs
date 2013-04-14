using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class RandomGenerator : IService
    {
        Random randGenerator;

        public int Next(int max)
        {
            return randGenerator.Next(max);
        }

        public int Next(int min, int max)
        {
            return randGenerator.Next(min, max);
        }

        public double NextDouble(double min, double max)
        {
            return randGenerator.NextDouble() * (max - min) + min;
        }


        public void Initialize()
        {
            randGenerator = new Random((int)DateTime.Now.Ticks);
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.RandomGenerator;
        }

		public void Cleanup()
        {
            
        }
    }
}

