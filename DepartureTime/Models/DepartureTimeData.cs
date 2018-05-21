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
		public Color BgColor;
		public Color TxtColor;
		public string SelectedFont;
        public DepartureTimeData()
        {}
    }
}
