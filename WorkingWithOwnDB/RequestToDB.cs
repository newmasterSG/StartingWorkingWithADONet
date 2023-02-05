using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WorkingWithOwnDB
{
    public class RequestToDB
    {
        public static void CreateFolderForDB(string pathIn, string nameFolder, out string pathOut)
        {
                Directory.SetCurrentDirectory(pathIn);
                var currentDirectory = Directory.GetCurrentDirectory();
                var DBDirectory = Path.Combine(currentDirectory, nameFolder);
                if (Directory.Exists(DBDirectory))
                {
                    Console.WriteLine("The Folder has already been created");
                }

                if (!(Directory.Exists(DBDirectory)))
                {
                    Directory.CreateDirectory(DBDirectory);
                }

                pathOut = DBDirectory;
        }

        public static void CreateDB(string path,string nameDB,out string pathOut)
        {
            string pathWithNameFile = Path.Combine(path, nameDB);
            if (File.Exists(pathWithNameFile))
            {
                Console.WriteLine("The DB has already been created");
            }
            if (!(File.Exists(pathWithNameFile)))
            {
                File.Create(path);
            }
            pathOut = pathWithNameFile;
        }

        public static void RequestWithNonQuery(string connection)
        {
            using (var connections = new SqliteConnection(connection))
            {
                connections.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connections;
                command.CommandText =@"Insert Into Student (name, surnmane, birthday)
                                                            VALUES (@name,@surnmane,@birthday)
                                                            ";
                command.Parameters.Add(new SqliteParameter("@name", "Daniel"));
                command.Parameters.Add(new SqliteParameter("@surnmane", "Plotnik"));
                command.Parameters.Add(new SqliteParameter("@birthday", "2004-09-03"));
                command.ExecuteNonQuery();
            }
        }
    }
}
