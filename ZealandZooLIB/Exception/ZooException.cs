namespace ZealandZooLIB.Exception;

/// <summary>
/// Peter
/// </summary>
public class ZooException : System.Exception
{
    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="errorMessage"></param>
    public ZooException(ZooErrorCode errorCode, string? errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="errorCode"></param>
    public ZooException(ZooErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    public ZooErrorCode ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
}

/// <summary>
/// Peter
/// </summary>
public enum ZooErrorCode
{
    SQL_Duplicate_Key,
    SQL_CheckGuestsNotGreaterThanMax
}