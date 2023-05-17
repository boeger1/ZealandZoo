namespace ZealandZooLIB.Exception;

public class ZooException : System.Exception
{
    public ZooException(ZooErrorCode errorCode, string? errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public ZooException(ZooErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    public ZooErrorCode ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
}

public enum ZooErrorCode
{
    SQL_Duplicate_Key,
    SQL_CheckGuestsNotGreaterThanMax
}