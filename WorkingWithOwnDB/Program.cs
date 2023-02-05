using System;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Linq;

namespace WorkingWithOwnDB
{
    public class Program
    {
        public static string pathIn = @"E:\NewVSCODE\WorkingWithOwnDB\WorkingWithOwnDB\";

        static void Main(string[] args)
        {
            string pathOut = string.Empty;
            string nameFolder = "DB";
            string nameDB = "testDB.db";
            RequestToDB.CreateFolderForDB(pathIn, nameFolder,out pathOut);
            string connection = string.Empty;
            RequestToDB.CreateDB(pathOut, nameDB, out connection);
            connection = String.Concat("Data Source =", connection);
            Console.WriteLine(connection);
            RequestToDB.RequestWithNonQuery(connection);
        }
    }
}
