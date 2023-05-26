using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.Models
{

    
    
    public class ZooStudent : BaseModel
    {
        public ZooStudent() { }
        public ZooStudent(int id,string firstname, string lastname)
        {
            Id = id;
            First_Name = firstname;
            Last_Name = lastname;
        }

        public int Id { get; set; }
        public string? First_Name { get; set; } = null!;

        public string? Last_Name { get; set; } = null!;

        public int ImageId { get; set; }
    }
}
