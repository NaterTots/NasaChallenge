﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public interface ILogger
    {
        void Log(Exception e);
        void Log(string s);
        void Log(Exception e, string s);
    }

    public class LogManager : List<ILogger>, IService, ILogger
    {

        public void Initialize()
        {
            //TODO: is this the best place to decide which loggers we should use?
            this.Add(new DiagnosticsLogger());
        }

        public ServiceType GetServiceType()
        {
            return ServiceType.Logger;
        }

        public void Log(Exception e)
        {
            foreach (ILogger logger in this)
            {
                logger.Log(e);
            }
        }

        public void Log(string s)
        {
            foreach (ILogger logger in this)
            {
                logger.Log(s);
            }
        }

        public void Log(Exception e, string s)
        {
            foreach (ILogger logger in this)
            {
                logger.Log(e, s);
            }
        }

        public void Finalize()
        {
            
        }
    }
}
