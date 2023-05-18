namespace ZealandZooLIB.Models;

public class Day
{
    public Day(Event zooEvent, DateTime date)
    {
        ZooEvent = zooEvent;
        Date = date;
    }

    public Event? ZooEvent { get; set; }
    public DateTime Date { get; init; }
}