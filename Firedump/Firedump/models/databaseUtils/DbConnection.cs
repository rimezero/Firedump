using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Firedump.models.databaseUtils
{
    public class DbConnection
    {

        public DbConnection() {
            port = 3306;
        }
        //den prepei na einai singleton auto me tpt mporei na ginonte taftoxrona connections se diaforous server
        private static DbConnection instance = null;
        public static DbConnection Instance()
        {
            if(instance == null)
            {
                instance = new DbConnection();
            }
            return instance;
        }
        
        public string Host
        {
            get; set;
        }

        public int port { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string database { get; set; }

        public string connectionString { get; set; }

        private MySqlConnection connection;

        public MySqlConnection Connection { get; }


        private string conStringBuilder()
        {            
            connectionString = "Server=" + Host + ";UID=" + username;
            if (!string.IsNullOrWhiteSpace(password))
            {
                connectionString += ";password=" + password;
            }
            if (port != 3306)
            {
                connectionString += ";port="+port;
            }
            connectionString += ";SslMode=Preferred";
            if (!string.IsNullOrWhiteSpace(database))
            {
                connectionString += ";database=" + database;
            }
            return connectionString + @";Convert Zero Datetime=true;" + @"default command timeout=120;";
        }

        /// <summary>
        /// used for testing
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static string conStringBuilder(string host,string username,string password,string database)
        {

            string cons = "";
            if (!String.IsNullOrEmpty(database))
            {
                cons = string.Format("Server=" + host + ";database={0};UID=" + username + ";password=" + password, database+ @";Convert Zero Datetime=true;" + @"default command timeout=120;");
            }
            else
            {
                cons = "Server=" + host + ";UID=" + username + ";password=" + password + @";Convert Zero Datetime=true;" + @"default command timeout=120;";
            }
            return cons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static string conStringBuilder(string host, string username, string password, string database,int port)
        {

            string cons = "";
            if (!String.IsNullOrEmpty(database))
            {
                cons = string.Format("Server=" + host + ";database={0};UID=" + username + ";password=" + password + ";port=" + port, database + @";Convert Zero Datetime=true;"+ @"default command timeout=120;");
            }
            else
            {
                cons = "Server=" + host + ";UID=" + username + ";password=" + password + ";port=" + port + @";Convert Zero Datetime=true;" + @"default command timeout=120;";
            }
            return cons;
        }

        public ConnectionResultSet testConnection()
        {
            ConnectionResultSet result = new ConnectionResultSet();
            try
            {
                connection = new MySqlConnection(conStringBuilder());
                connection.Open();
            }
            catch(ArgumentException a_ex)
            {
                Console.WriteLine("Check the connection string");
                Console.WriteLine(a_ex.Message);
                Console.WriteLine(a_ex.ToString());
                result.wasSuccessful = false;
                result.exceptionType = 0;
                result.errorMessage = a_ex.Message;
                return result;
            }
            catch(MySqlException ex)
            {
                string sqlErrorMessage = "Message: " + ex.Message + "\n" +"Source: " + ex.Source + "\n" +"Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042: 
                        Console.WriteLine("Unable to connect to any of the specified MySQL hosts (Check Server,Port)");
                        break;
                    case 0: // 
                        Console.WriteLine("Access denied (Check DB name,username,password)");
                        break;
                    default:
                        break;
                }
                result.wasSuccessful = false;
                result.exceptionType = 1;
                result.errorMessage = ex.Message;
                result.errorSource = ex.Source;
                result.mysqlErrNum = ex.Number;
                return result;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            result.wasSuccessful = true;
            return result;
        }

        /// <summary>
        /// Must be connected to a server and not to a database
        /// </summary>
        /// <returns></returns>
        public List<string> getDatabases()
        {
            connection = new MySqlConnection(conStringBuilder());
            connection.Open();
            List<string> databases = new List<string>();

            string query = "show databases;";
            MySqlCommand command = new MySqlCommand(query,connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                databases.Add(reader.GetString(0));
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return databases;
        }

        /// <summary>
        /// Must be connected to a server and not to a database
        /// </summary>
        /// <param name="database">The database name</param>
        /// <returns>A list of the tables in the database</returns>
        public List<string> getTables(String database)
        {
            try {
                connection = new MySqlConnection(conStringBuilder());
                connection.Open();
                List<string> tables = new List<string>();

                string query = "show tables from " + database + ";";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return tables;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        public int getTableRowsCount(string tablename,string constring)
        {
            connection = new MySqlConnection(constring);
            connection.Open();
            int count = 0;
            string sql = "SELECT COUNT(*) FROM " + tablename;
            MySqlCommand command = new MySqlCommand(sql,connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                count = reader.GetInt32(0);
            }
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return count;
        }

        /// <summary>
        ///  Must be connected to database and not to server
        /// </summary>
        /// <returns>A list of the tables in the database</returns>
        [Obsolete("use getTables(database)")]
        public List<string> getTables()
        {
            connection = new MySqlConnection(conStringBuilder());
            connection.Open();
            List<string> tables = new List<string>();

            string query = "show tables;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tables.Add(reader.GetString(0));
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            
            return tables;
        }

        public void Close()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
