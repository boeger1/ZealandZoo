using Microsoft.IdentityModel.Tokens;
using ZealandZooLIB.Helper;

namespace ZealandZooLIB.Models;

public class ParticipantSignUp : BaseModel
{
    private Student? _student;
    private Event? _zooEvent;

    public Event? ZooEvent
    {
        get
        {
            if (_zooEvent == null)
                if (!JsonZooEvent.IsNullOrEmpty())
                    _zooEvent = ModelHelper.DeSerializeEvent(JsonZooEvent)!;
            return _zooEvent;
        }
        set => _zooEvent = value;
    }

    public string JsonZooEvent { get; set; }

    public Student Student
    {
        get
        {
            if (_student == null)
                if (!JsonStudent.IsNullOrEmpty())
                    _student = ModelHelper.DeSerializeStudent(JsonStudent)!;
            return _student;
        }
        set => _student = value;
    }

    public string JsonStudent { get; set; }
    public int Participants { get; set; }
}