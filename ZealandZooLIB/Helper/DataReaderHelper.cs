using System.Data.SqlClient;

namespace ZealandZooLIB.Helper;

/// <summary>
///     Peter
/// </summary>
public static class DataReaderHelper
{
    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="colIndex"></param>
    /// <returns></returns>
    public static int SafeInt32Get(SqlDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetInt32(colIndex);
        return -1;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="colIndex"></param>
    /// <returns></returns>
    public static string? SafeGetString(SqlDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetString(colIndex);
        return null;
    }
}