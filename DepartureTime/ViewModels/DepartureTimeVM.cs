using System;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using DepartureTime.Models;
using Plugin.LocalNotifications;
using System.Collections.Generic;
using DepartureTime.Classes;
using DepartureTime.Interfaces;

namespace DepartureTime.ViewModels
{
    public class DepartureTimeVM : ViewModelBase
    {      
        private DepartureTimeData _data;
        private DepartureTimeLanguage _currentLanguage;
        private Languages _languages;
        private bool _showCaculateLunch = false;
        private TimeSpan _lunchStart;
        private TimeSpan _lunchEnd;
        private TimeSpan _result;
        private DateTime _currentTime = DateTime.Today;




        public string LanguageLabel
        {
            get { return _currentLanguage.CurrentLanguage; }
            set 
            {
                if (_currentLanguage.CurrentLanguage != value)
                {
                    _currentLanguage.CurrentLanguage = value;
                    Language = _languages.GetLanguageDic(value);
                }           
            }
        }

        private List<string> _languageList;
        public List<string> LanguageList
        {
            get { return _languageList; }
        }

        private Dictionary<string, string> _language = new Dictionary<string, string>();
        public Dictionary<string,string> Language
        {
            get { return _language; }
            set 
            {
                if (_language != value)
                {
                    _language = value;
                    OnPropertyChangedEvent("Language");    
                }
            }
        }

        public Color UserBackgroundColor
        {
            get { return _data.BgColor; }
            set
            {
                if (_data.BgColor != value)
                {
                    _data.BgColor = value;
                    OnPropertyChangedEvent("UserBackgroundColor");
                }
            }
        }

        public Color UserTextColor
        {
            get { return _data.TxtColor; }
            set
            {
                if (_data.TxtColor != value)
                {
                    _data.TxtColor = value;
                    OnPropertyChangedEvent("UserTextColor");
                }
            }
        }

        public bool ShowCalculateLunch
        {
            get { return _showCaculateLunch; }
            set
            {
                if (_showCaculateLunch != value)
                {
                    _showCaculateLunch = value;
                    OnPropertyChangedEvent("ShowCalculateLunch");
                }
            }
        }

        public TimeSpan Arrival
        {
            get { return _data.Arrival; }
            set 
            {
                if (_data.Arrival != value)
                {
                    _data.Arrival = value;
                    CalculateResult();
                    OnPropertyChangedEvent("Arrival");
                }  
            }
        }

        public TimeSpan WorkingHours
        {
            get { return _data.WorkingHours; }
            set
            {
                if (_data.WorkingHours != value)
                {
                    _data.WorkingHours = value;
                    CalculateResult();
                    OnPropertyChangedEvent("WorkingHours");
                }
            }
        }

        public TimeSpan LunchBreak
        {
            get { return _data.LunchBreak; }
            set
            {
                if (_data.LunchBreak != value)
                {
                    _data.LunchBreak = value;
                    CalculateResult();
                    OnPropertyChangedEvent("LunchBreak");
                }
            }
        }

        public TimeSpan LunchStart
        {
            get { return _lunchStart; }
            set
            {
                if (_lunchStart != value)
                {
                    _lunchStart = value;
                    CalculInOut();
                    OnPropertyChangedEvent("LunchStart");
                }
            }
        }

        public TimeSpan LunchEnd
        {
            get { return _lunchEnd; }
            set
            {
                if (_lunchEnd != value)
                {
                    _lunchEnd = value;
                    CalculInOut();
                    OnPropertyChangedEvent("LunchEnd");
                }
            }
        }

        public TimeSpan Result
        {
            get { return _result; }
            private set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChangedEvent("Result");
                }
            }
        }

        void CalculateResult()
        {
            if (Arrival != null && WorkingHours != null && LunchBreak != null)
            {
                Result = Addtime(new TimeSpan[] { Arrival, WorkingHours, LunchBreak });
            }
        }

        TimeSpan Addtime(TimeSpan[] times)
        {
            TimeSpan tmptime;

            for (int i = 0; i < times.Length; i++) tmptime += times[i];
            return tmptime;
        }

        void CalculInOut()
        {
            if (LunchEnd > LunchStart)
                LunchBreak = LunchEnd - LunchStart;
        }
               
        public DateTime BuildNotificationTime()
        {
            DateTime NotificationTime = new DateTime(_currentTime.Year,
                                                     _currentTime.Month,
                                                     _currentTime.Day,
                                                     Result.Hours,
                                                     Result.Minutes,
                                                     Result.Seconds);
    
            return NotificationTime;                                    
        }

        ObservableCollection<View> _myItemsSource;
        public ObservableCollection<View> MyItemsSource
        {
            set
            {
                _myItemsSource = value;
                OnPropertyChangedEvent("MyItemsSource");
            }
            get
            {
                return _myItemsSource;
            }
        }


        public ICommand SetNotification { set; get; }
        public ICommand MyCommand { protected set; get; }
        public ICommand InvertColor { set; get; }
		public ICommand Save { set; get; }

        public DepartureTimeVM(IDataProvider data)
        {
            _data = data.GetData();
            _currentLanguage = data.GetCurrentLanguage();
            _languages = data.GetLanguages();
            _languageList = _languages.AvailableLanguage;
            Language = _languages.GetLanguageDic(LanguageLabel);

            SetNotification = new Command(() =>
                {
                    CrossLocalNotifications.Current.Show("Departure Time - Minimum Time Reached", "You can Go now !!!", 101, BuildNotificationTime());
                });

            MyItemsSource = new ObservableCollection<View>()
            {
                new Main(),
                new Settings()
            };

            MyCommand = new Command(() =>
            {
                Debug.WriteLine("Position selected.");
            });

            InvertColor = new Command(() =>
            {
                Color TmpColor = UserBackgroundColor;
                UserBackgroundColor = UserTextColor;
                UserTextColor = TmpColor;              
            });

			Save = new Command(() =>
		   {
			   data.SaveData(_data, _currentLanguage);
		   });
        }
    }
}
