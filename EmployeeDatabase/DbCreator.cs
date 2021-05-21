using Microsoft.Data.Sqlite;
using System;


namespace EmployeeDatabase
{
    public class DbCreator
    {
        public void LoadDataBase()
        {
            string cs = @"URI=file:C:\sqlite\databases\testdb.db";

            
            

            Console.WriteLine("row inserted");
        }
        public void CreateDataBase()
        {
            
                SqliteConnection sqlite_conn;
            string cs = @"Uri=file:C:\sqlite\databases\testdb.db";
            // Create a new database connection:
            sqlite_conn = new SqliteConnection();
         // Open the connection:
         try
            {
                sqlite_conn.Open();
                
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("HELLO");
            }
            
            CreateTable(sqlite_conn);
        }
        public void CreateTable(SqliteConnection con)
        {
            SqliteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(200), Col2 VARCHAR(200), Col3 INT)";
            sqlite_cmd = con.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
