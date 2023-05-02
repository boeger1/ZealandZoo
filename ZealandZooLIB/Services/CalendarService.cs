using System;
using System.Collections.Generic;
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
            _dateToShow = _dateToShow.AddMonths(1);
        }

        public void PreviousMonth()
        {
            _dateToShow = _dateToShow.AddMonths(-1);
        }

        public void Reset()
        {
            _dateToShow = DateTime.Now;
        }

        public int DaysOfCurrentMonth()
        {
            return DateTime.DaysInMonth(_dateToShow.Year, _dateToShow.Month);
        }

        public List<Day> GetDaysInCurrentMonth(List<Event> events)
        {
            var firstDayOfMonth = new DateTime(_dateToShow.Year, _dateToShow.Month, 1);
            List<Day> days = new List<Day>() {new Day(null, firstDayOfMonth)};

            for (int i = 1; i < DaysOfCurrentMonth(); i++)
            {
                days.Add(new Day(null, firstDayOfMonth.AddDays(i)));
            }

            if (!events.IsNullOrEmpty())
            {
                foreach (var day in days)
                {
                    foreach (var e in events)
                    {
                        if (day.Date.Day == e.DateFrom.Day && day.Date.Month == e.DateFrom.Month &&
                            day.Date.Year == e.DateFrom.Year)
                        {
                            day.ZooEvent = e;
                        }
                    }
                }
            }

            return days;
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

}
