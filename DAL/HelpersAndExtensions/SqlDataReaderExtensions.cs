using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.HelpersAndExtensions
{
    public static class SqlDataReaderExtensions
    {
        public static bool IsDbNull(this SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName));
        }

        public static decimal? GetDecimalOrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (decimal?)Convert.ToDecimal(reader[columnName]);
        }

        public static decimal GetDecimal(this SqlDataReader reader, string columnName)
        {
            return Convert.ToDecimal(reader[columnName]);
        }


        public static int? GetInt32OrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (int?)Convert.ToInt32(reader[columnName]);
        }

        public static int GetInt32(this SqlDataReader reader, string columnName)
        {
            return Convert.ToInt32(reader[columnName]);
        }


        public static string GetString(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : Convert.ToString(reader[columnName]);
        }


        public static bool? GetBooleanOrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (bool?)Convert.ToBoolean(reader[columnName]);
        }

        public static bool GetBoolean(this SqlDataReader reader, string columnName)
        {
            return Convert.ToBoolean(reader[columnName]);
        }


        public static DateTime GetDateTime(this SqlDataReader reader, string columnName)
        {
            return Convert.ToDateTime(reader[columnName]);
        }

        public static DateTime? GetDateTimeOrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (DateTime?)Convert.ToDateTime(reader[columnName]);
        }

        public static byte? GetByteOrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (byte?)Convert.ToByte(reader[columnName]);
        }

        public static byte GetByte(this SqlDataReader reader, string columnName)
        {
            return Convert.ToByte(reader[columnName]);
        }

        public static short? GetInt16OrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (short?)Convert.ToInt16(reader[columnName]);
        }

        public static short GetInt16(this SqlDataReader reader, string columnName)
        {
            return Convert.ToInt16(reader[columnName]);
        }


        public static long? GetInt64OrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (long?)Convert.ToInt64(reader[columnName]);
        }

        public static long GetInt64(this SqlDataReader reader, string columnName)
        {
            return Convert.ToInt64(reader[columnName]);
        }


        public static double? GetDoubleOrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (double?)Convert.ToDouble(reader[columnName]);
        }

        public static double GetDouble(this SqlDataReader reader, string columnName)
        {
            return Convert.ToDouble(reader[columnName]);
        }

        public static float? GetFloatOrNull(this SqlDataReader reader, string columnName)
        {
            return IsDbNull(reader, columnName) ? null : (float?)Convert.ToSingle(reader[columnName]);
        }

        public static float GetFloat(this SqlDataReader reader, string columnName)
        {
            return Convert.ToSingle(reader[columnName]);
        }

    }
}
