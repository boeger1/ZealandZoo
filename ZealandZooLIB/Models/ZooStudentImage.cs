using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.Models
{
    public class ZooStudentImage : BaseModel
    {

        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Path { get; set; }
        public ImageType Type { get; set; }

        public static bool IsImageNullOrEmpty(ZooStudentImage image)
        {
            if (image == null) return true;
            if (string.IsNullOrEmpty(image.Name) && string.IsNullOrEmpty(image.Path)) return true;

            return false;
        }




    }
}
