using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Tokens;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services
{
    public class CalendarService
    {
        private static DateTime _dateToShow = DateTime.Now;
        private static MonthType? _month = null;
        public string[] GetDayNames()
        {
            return new[]
            {
                "Mandag", "Tirsdag", "Onsdag", "Torsdag",
                "Fredag", "Lørdag", "Søndag"
            };
        }

        public void NextMonth()
        {
            {
                _dateToShow = _dateToShow.AddMonths(1);
            }
        }

        public void PreviousMonth()
        {
            {
                _dateToShow = _dateToShow.AddMonths(-1);
            }
        }

        public MonthType GetCurrentMonth()
        {
            return GetMonth(_dateToShow.Month);
        }

        public MonthType GetNextMonth()
        {
            if (_dateToShow.Month + 1 > 12)
            {
                return MonthType.Januar;
            }
            return GetMonth(_dateToShow.Month +1 );
        }

        public MonthType GetPreviousMonth()
        {
            if (_dateToShow.Month - 1 < 1)
            {
                return MonthType.December;
            }
            return GetMonth(_dateToShow.Month - 1);
        }


        public void Reset()
        {
            _dateToShow = DateTime.Now;
        }

        public int DaysOfCurrentMonth()
        {
            return DateTime.DaysInMonth(_dateToShow.Year, _dateToShow.Month);
        }

        public int GetCurrentYear()
        {
            return _dateToShow.Year;
        }

        public bool IsNewMonth(MonthType month)
        {

            if (month == _month )
            {
                return false;
            }

            _month = month;
            return true;
        }

        public List<Day> GetDaysInCurrentMonth(List<BaseModel> events)
        {
            var firstDayOfMonth = new DateTime(_dateToShow.Year, _dateToShow.Month, 1);
            List<Day> days = new List<Day>() {new Day(null, firstDayOfMonth)};

            for (int i = 1; i < DaysOfCurrentMonth(); i++)
            {
                days.Add(new Day(null!, firstDayOfMonth.AddDays(i)));
            }

            if (!events.IsNullOrEmpty())
            {
                PopulateDaysWithEvents(events, days);
            }

            return days;
        }

        private static void PopulateDaysWithEvents(List<BaseModel> events, List<Day> days)
        {
            foreach (var day in days)
            {
                foreach (var baseModel in events)
                {
                    var e = (Event)baseModel;
                    if (day.Date.Day == e.DateFrom.Day && day.Date.Month == e.DateFrom.Month &&
                        day.Date.Year == e.DateFrom.Year)
                    {
                        day.ZooEvent = e;
                    }
                }
            }
        }


        public DayType FirstDayInMonth()
        {
            var today = new DateTime(_dateToShow.Year, _dateToShow.Month, 1).DayOfWeek;
            switch (today)
            {
                case (DayOfWeek.Monday):
                    return DayType.Monday;
                case (DayOfWeek.Tuesday):
                    return DayType.Tuesday;
                case (DayOfWeek.Wednesday):
                    return DayType.Wednesday;
                case (DayOfWeek.Thursday):
                    return DayType.Thursday;
                case (DayOfWeek.Friday):
                    return DayType.Friday;
                case (DayOfWeek.Saturday):
                    return DayType.Saturday;
                case (DayOfWeek.Sunday):
                    return DayType.Sunday;
                default: throw new NotImplementedException();
            }
        }

        public static MonthType GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return MonthType.Januar;
                case 2:
                    return MonthType.Februar;
                case 3:
                    return MonthType.Marts;
                case 4:
                    return MonthType.April;
                case 5:
                    return MonthType.Maj;
                case 6:
                    return MonthType.Juni;
                case 7:
                    return MonthType.Juli;
                case 8:
                    return MonthType.August;
                case 9:
                    return MonthType.September;
                case 10:
                    return MonthType.Oktober;
                case 11:
                    return MonthType.November;
                case 12:
                    return MonthType.December;
                default: 
                    throw new ArgumentException();
            }
        }
    }

    public enum DayType : int
    {
        [Display(Name = "Mandag")] Monday = 0,
        [Display(Name = "Tirsdag")] Tuesday = 1,
        [Display(Name = "Onsdag")] Wednesday = 2,
        [Display(Name = "Torsdag")] Thursday = 3,
        [Display(Name = "Fredag")] Friday = 4,
        [Display(Name = "Lørdag")] Saturday = 5,
        [Display(Name = "Søndag")] Sunday = 6,
    }

    public enum MonthType : int
    {
        Januar = 1,
        Februar = 2,
        Marts = 3,
        April = 4,
        Maj = 5,
        Juni = 6,
        Juli = 7,
        August = 8,
        September = 9,
        Oktober = 10,
         November = 11,
        December = 12
    }

}
