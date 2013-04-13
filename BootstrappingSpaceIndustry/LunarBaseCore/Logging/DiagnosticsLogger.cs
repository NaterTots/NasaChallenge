using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    class DiagnosticsLogger : ILogger
    {
        //TODO: this should be retrieved from a config file
        private bool _useDebugger = true;

        public void Log(Exception e)
        {
            Debug.WriteLineIf(_useDebugger, e);
        }

        public void Log(string s)
        {
            Debug.WriteLineIf(_useDebugger, s);
        }

        public void Log(Exception e, string s)
        {
            Debug.WriteLineIf(_useDebugger, e);
            Debug.WriteLineIf(_useDebugger, s);
        }
    }
}