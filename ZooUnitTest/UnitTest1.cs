using ZealandZooLIB.Services;

namespace ZooUnitTest
{
    public class Tests
    {
        private CalendarService _calendarService;
        private DateTime _currentTime;

        [SetUp]
        public void Setup()
        {
            _calendarService = new CalendarService();
            _currentTime = DateTime.Now;
        }

        [Test]
        public void NextMonthTest()
        {
            _calendarService.NextMonth();

            Assert.AreEqual(expected: _currentTime.Month + 1, actual: _calendarService.DateToShow.Month);
        }

    }
}