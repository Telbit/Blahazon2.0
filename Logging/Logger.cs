using System;
using System.Diagnostics;

namespace Blahazon.Logging
{
    public static class Logger
    {
        private static string MachineNamee { get; set; }
        public static void SetupLogger(string machineName)
        {
            MachineNamee = machineName;
            if (!EventLog.SourceExists("BlahaLogger", MachineNamee))
            {
                EventLog.CreateEventSource(new EventSourceCreationData("BlahaLogger", "localhost") { MachineName = MachineNamee });
            }
        }

        public static EventLog GetNewEventLog()
        {
            return new EventLog("localhost", MachineNamee, "BlahaLogger");
        }
    }
}
