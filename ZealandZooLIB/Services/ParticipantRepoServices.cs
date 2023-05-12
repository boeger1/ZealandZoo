using System.Data.SqlClient;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services
{
    public class ParticipantRepoServices : IRepositoryService
    {
        public List<BaseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        
        public BaseModel Create(BaseModel model)
        {
            throw new NotImplementedException();
        }

        public BaseModel Create(ParticipantSignUp participantSignUpnUp)
        {
            var signUp = (ParticipantSignUp)participantSignUpnUp;
            var queryString =
                "INSERT INTO [dbo].[EventParticipants] ([event_id],[student_id],[student_email],[participants]) VALUES(@event_id,@student_id,@student_email,@participants)";

            using var createCommand = new SqlConnection(Secret.GetSecret());
            {
                createCommand.Open();
                var command = new SqlCommand(queryString, createCommand);

                command.Parameters.AddWithValue("@event_id", signUp.ZooEvent.Id);
                command.Parameters.AddWithValue("@student_id", signUp.Student.Id);
                command.Parameters.AddWithValue("@student_email", signUp.Student.Email);
                command.Parameters.AddWithValue("@participants", signUp.Participants);

                var rows = command.ExecuteNonQuery();

                if (rows != 1) throw new ArgumentException("Event er ikke oprettet");

                createCommand.Close();

                return null;
            }
        }

        public BaseModel Update(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
