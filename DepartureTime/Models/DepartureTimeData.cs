using System;
using Xamarin.Forms;
using System.Collections.Generic;
using DepartureTime.Helpers;

namespace DepartureTime.Models
{
    public class DepartureTimeData
    {
        public TimeSpan Arrival;
        public TimeSpan WorkingHours;
        public TimeSpan LunchBreak;
        public Color BgColor = Color.Black;
        public Color TxtColor = Color.White;
        public DepartureTimeData()
        {}
    }
}
