using System.Data.SqlClient;

namespace ZealandZooLIB.Helper;

public static class DataReaderHelper
{
    public static int SafeInt32Get(SqlDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetInt32(colIndex);
        return -1;
    }

    public static string? SafeGetString(SqlDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetString(colIndex);
        return null;
    }
}