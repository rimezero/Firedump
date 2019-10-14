using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data;
using MySql.Data.MySqlClient;
using Firedump.Forms.mysql;
using System.Collections.Generic;
using Firedump.models.databaseUtils;

namespace FiredumpTest
{
    /// <summary>
    /// this tests need real mysql server database
    /// </summary>
    [TestClass]
    public class TestDbConnection
    {

        /// <summary>
        /// runs only once at class init
        /// </summary>
        [ClassInitialize()]
        public static void initDb(TestContext context)
        {           
            populateDb(100);
        }

        /// <summary>
        /// runs only once at class destroy
        /// </summary>
        [ClassCleanup()]
        public static void clearDb()
        {
            using (MySqlConnection con = new MySqlConnection(DbConnection.conStringBuilder(Const.host, Const.username, Const.password, null)))
            {
                con.Open();
                string sql = "DROP DATABASE IF EXISTS testfiredump;";
                using (MySqlCommand command = new MySqlCommand(sql,con))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(MySqlException ex) { 
                    }
                    
                }
            }
        }

        /// <summary>
        /// runs every time before every test method
        /// </summary>
        [TestInitialize()]
        public void Initialize() {
        }

        /// <summary>
        /// runs every time after every test method
        /// </summary>
        [TestCleanup()]
        public void Cleanup() {
        }

        private static string password = Const.password;

        [TestMethod]
        public void TestTestConnection()
        {
            
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);

            connection.Host = Const.host;
            connection.username = Const.username;
            connection.password = password;

            Assert.IsTrue(connection.testConnection().wasSuccessful);

            connection.Host = Const.host;
            connection.username = "invalidusername";
            connection.password = password;

            Assert.IsFalse(connection.testConnection().wasSuccessful);
            
        }

       

        [TestMethod]
        public void TestGetDatabases()
        {
            
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);

            connection.Host = Const.host;
            connection.username = Const.username;
            connection.password = password;

            Assert.IsFalse(connection.getDatabases().Count == 0);
            Assert.IsTrue(connection.getTables(Const.database).Count > 0);
            List<string> tables = connection.getTables(Const.database);
            Assert.AreEqual(3,tables.Count);
            
        }

        [TestMethod]
        public void TestGetTables()
        {
            DbConnection connection = DbConnection.Instance();
            Assert.IsNotNull(connection);

            connection.Host = Const.host;
            connection.username = Const.username;
            connection.password = password;

            //may not always pass!
            //depends on the mysql user privilages,if it has read permissions for information_schema and mysql databases
            Assert.IsFalse(connection.getTables("information_schema").Count == 0);
            Assert.IsFalse(connection.getTables("mysql").Count == 0);

            Assert.IsTrue(connection.getTables(Const.database).Count > 0);
            List<string> tables = connection.getTables(Const.database);
            Assert.AreEqual(3, tables.Count);

            
        }
        


        public static void populateDb(int rowsToCreate)
        {
            using (MySqlConnection con = new MySqlConnection(DbConnection.conStringBuilder(Const.host, Const.username, Const.password, null)))
            {
                //create test database and test tables
                con.Open();
                string sql = "CREATE DATABASE IF NOT EXISTS testfiredump;use testfiredump";
                MySqlCommand command = new MySqlCommand(sql, con);
                int count = command.ExecuteNonQuery();
                Assert.AreEqual(1, count);

                sql = "CREATE TABLE IF NOT EXISTS table1 (id int,text VARCHAR(45))";
                command = new MySqlCommand(sql, con);
                count = command.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS table2 (id int,text VARCHAR(45))";
                command = new MySqlCommand(sql, con);
                count = command.ExecuteNonQuery();

                sql = "CREATE TABLE IF NOT EXISTS table3 (id int,text VARCHAR(45))";
                command = new MySqlCommand(sql, con);
                count = command.ExecuteNonQuery();

                //populate them with junk data
                for (int i = 0; i < rowsToCreate; i++)
                {
                    
                    sql = "INSERT INTO table1(id,text) VALUES(" + i + ",'text" + i + "');";
                    command = new MySqlCommand(sql, con);
                    count = command.ExecuteNonQuery();
                    Assert.AreEqual(1, count);

                    sql = "INSERT INTO table2(id,text) VALUES(" + i + ",'text" + i + "');";
                    command = new MySqlCommand(sql, con);
                    count = command.ExecuteNonQuery();
                    Assert.AreEqual(1, count);

                    sql = "INSERT INTO table3(id,text) VALUES(" + i + ",'text" + i + "');";
                    command = new MySqlCommand(sql, con);
                    count = command.ExecuteNonQuery();
                    Assert.AreEqual(1, count);
                }



                if (command != null)
                {
                    command.Dispose();
                }

            }
        }


    }
}
