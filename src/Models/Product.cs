using System;
using System.Collections.Generic;
using System.Text;

namespace HiveSharp.Models
{
    /// <summary>
    /// An object representing a product in the array returned from the 'products' endpoint.
    /// </summary>
    public class Product
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int SortOrder { get; set; }
        public long Created { get; set; }
        public long LastSeen { get; set; }
        public string Parent { get; set; }

        public class PropsResponse
        {
            public bool Online { get; set; }
            public string Model { get; set; }
            public string Version { get; set; }

            public class UpgradeResponse
            {
                public bool Available { get; set; }
                public bool Upgrading { get; set; }
            }
            public UpgradeResponse Upgrade { get; set; }

            public List<string> Capabilities { get; set; }

            public class HolidayModeResponse
            {
                public bool Active { get; set; }
                public bool Enabled { get; set; }
                public long Start { get; set; }
                public long End { get; set; }
                public int Temperature { get; set; }
            }
            public HolidayModeResponse HoldayMode { get; set; }

            public string ModelVarient { get; set; }
            public bool Working { get; set; }
            public string Pmz { get; set; }

            public class PreviousResponse
            {
                public string Mode { get; set; }
            }
            public PreviousResponse Previous { get; set; }

            public bool ScheduleOverride { get; set; }
            public double Temperature { get; set; }
            public string Zone { get; set; }
            
            public class AutoBoost
            {
                public bool Active { get; set; }
                public int Target { get; set; }
                public int Duration { get; set; }
                // Trvs?
            }
            public AutoBoost Autoboost { get; set; }
            public bool ReadyBy { get; set; }
        }
        public PropsResponse Props { get; set; }

        public class StateResponse
        {
            public string Name { get; set; }
            public int Boost { get; set; }
            public int FrostProtection { get; set; }
            public string Mode { get; set; }

            public class ScheduleResponse
            {

                public class Day
                {
                    public class ValueResponse
                    {
                        public int Target { get; set; }
                    }

                    public ValueResponse Value { get; set; }
                    public int Start { get; set; }
                }

                public List<Day> Monday { get; set; }
                public List<Day> Tuesday { get; set; }
                public List<Day> Wednesday { get; set; }
                public List<Day> Thursday { get; set; }
                public List<Day> Friday { get; set; }
                public List<Day> Saturday { get; set; }
                public List<Day> Sunday { get; set; }
            }
            public ScheduleResponse Schedule { get; set; }

            public int Target { get; set; }
            public int OptimumStart { get; set; }
            public string AutoBoost { get; set; }
            public int AutoBoostTarget { get; set; }
        }

        public StateResponse State { get; set; }
    }
}
