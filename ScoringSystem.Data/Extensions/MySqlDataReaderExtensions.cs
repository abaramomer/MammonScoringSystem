using System;
using System.Runtime.InteropServices.ComTypes;
using MySql.Data.MySqlClient;

namespace ScoringSystem.Data.Extensions
{
    public static class MySqlDataReaderExtensions
    {
        public static T GetValue<T>(this MySqlDataReader dataReader, string columnName)
        {
            return (T) dataReader[columnName];
        }

        //public static T GetNullableValue<T>(this MySqlDataReader dataReader,  string columnName) where T : object
        //{
        //    //if(dataReader[columnName] is DBNull)
        //    //{
        //    //    return null;
        //    //}

        //    //return dataReader.GetValue<T>(columnName);
        //}
    }
}