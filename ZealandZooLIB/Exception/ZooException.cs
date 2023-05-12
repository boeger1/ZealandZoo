using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.Exception
{
    public class ZooException : System.Exception
    {
        public ZooErrorCode ErrorCode { get; init; }
        public string? ErrorMessage { get; init; } = null;

        public ZooException(ZooErrorCode errorCode, string? errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public ZooException(ZooErrorCode errorCode)
        {
            ErrorCode = errorCode;
        }
    }

    public enum ZooErrorCode
    {
        SQL_Duplicate_Key,
    }


}
