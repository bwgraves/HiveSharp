using System.Collections.Generic;

namespace HiveSharp.Models
{
    /// <summary>
    /// Represents the json response from calling the 'admin-login' endpoint.
    /// </summary>
    public class AdminLoginResponse
    {
        public List<Product> Products { get; set; }

        public class Product
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public int SortOrder { get; set; }
            public string Created { get; set; }
            public string LastSeen { get; set; }
            public string Parent { get; set; }
        }

        //public class State
        //{
        //    public string AutoBoost { get; set; }
        //    public string AutoBoostTarget { get; set; }
        //    public string Boost { get; set; }
        //    public int FrostProtection { get; set; }
        //    public string Mode { get; set; }
        //    public string Name { get; set; }
        //    public bool OptimumStart { get; set; }
        //    public Schedule Schedule { get; set; }
        //    public int Target { get; set; }
        //}

        //public class Schedule
        //{
        //    public Day Monday { get; set; }
        //    public Day Tuesday { get; set; }
        //    public Day Wednesday { get; set; }
        //    public Day Thursday { get; set; }
        //    public Day Friday { get; set; }
        //    public Day Saturday { get; set; }
        //    public Day Sunday { get; set; }
        //}


        //public class Day
        //{
        //    public HalfDay[] halves { get; set; }

        //    public class HalfDay
        //    {
        //        public DayValue Value { get; set; }
        //        public int Start { get; set; }
        //    }

        //    public class DayValue
        //    {
        //        public int Target { get; set; }
        //    }
        //}
    }
}
