using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class Database<T>
    {
        SQLiteConnection _myDatabaseConnection;
        string _databaseName;
        SQLiteCommand _command;
        readonly object _keyLock = new object();

        #region BASIC
        public string DatabaseName { set => _databaseName = value; }

        Database(string databaseName)
        {
            DatabaseName = "database." + databaseName;
            _myDatabaseConnection = new SQLiteConnection("Data Source=" + databaseName);
            _openConnection();
        }

        void _openConnection()
        {
            if (File.Exists("./ + " + _databaseName))
            {
                if (_myDatabaseConnection != null && _myDatabaseConnection.State == System.Data.ConnectionState.Closed)
                {
                    _myDatabaseConnection.Open();
                }
            }
        }

        void _closeConnection()
        {
            if (File.Exists("./ + " + _databaseName))
            {
                if (_myDatabaseConnection != null && _myDatabaseConnection.State == System.Data.ConnectionState.Open)
                {
                    _myDatabaseConnection.Close();
                }
            }
        }

        /// <summary>
        /// Sprawdza czy dana tabela w bazie danych istnieje
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        private bool checkForTableExist(string tableName, SQLiteConnection connection)
        {
            bool exists;
            _openConnection();

            try
            {
                _command.CommandText =
                     $"select case when exists((select * from information_schema.tables where table_name = '{tableName}')) then 1 else 0 end";
                exists = (int)_command.ExecuteScalar() == 1;
            }
            catch
            {
                try
                {
                    exists = true;
                    SQLiteCommand cmdOther = new SQLiteCommand($"SELECT 1 FROM {tableName} WHERE 1=0", connection);
                    cmdOther.ExecuteNonQuery();
                }
                catch
                {
                    exists = false;
                }
            }

            return exists;
        }
        #endregion

        /// <summary>
        /// Pobiera dane z bazy danych 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public List<T> getDataWithDatabase(string columnName)
        {
            _openConnection();
            List<T> list = new List<T>();

            lock(_keyLock)
            {
                using (SQLiteDataReader reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetFieldValue<T>(0));
                    }
                    reader.Close();
                }
            }
            _closeConnection();

            return list;
        }
    }
}
