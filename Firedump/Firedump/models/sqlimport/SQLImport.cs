using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firedump.models.configuration.dynamicconfig;
using MySql.Data.MySqlClient;
using Firedump.utils;
using System.Diagnostics;
using System.IO;

namespace Firedump.models.sqlimport
{
    class SQLImport
    {
        //<events>
        public delegate void progress(int progress);
        public event progress Progress;
        private void onProgress(int progress)
        {
            Progress?.Invoke(progress);
        }
        //</events>
        public string scriptStatus { set; get; }
        public ImportCredentialsConfig config { get; }
        private int commandCounter = 0;
        private string connectionString;
        private SQLImport() { }
        public SQLImport(ImportCredentialsConfig config)
        {
            this.config = config;
            if(config.port == 0)
            {
                this.config.port = 3306;
            }
            conStringBuilder();
        }
        private Process proc;

        private void conStringBuilder()
        {
            connectionString = "Server=" + config.host + ";UID=" + config.username;
            if (!string.IsNullOrWhiteSpace(config.password))
            {
                connectionString += ";password=" + config.password;
            }
            if (config.port != 3306)
            {
                connectionString += ";port=" + config.port;
            }
            connectionString += ";SslMode=Preferred";
            if (!string.IsNullOrWhiteSpace(config.database))
            {
                connectionString += ";database=" + config.database;
            }
        }
        /*
        private bool isServerCompatible()
        {
            bool isCompatible = true;
            //https://stackoverflow.com/questions/17464116/how-do-i-know-a-mysql-user-has-the-maximum-privileges-possible
            //https://stackoverflow.com/questions/6956106/how-to-know-if-mysql-binary-log-is-enable-through-sql-command
            //https://www.thegeekstuff.com/2017/08/mysqlbinlog-examples/
            //check if the user has super priviledge and if binary logging is enabled on the server
            //if not stop and pop message
            return isCompatible;
        }*/

        public ImportResultSet executeScript()
        {
            ImportResultSet result = new ImportResultSet();
            if (!string.IsNullOrWhiteSpace(this.scriptStatus))
            {
                result.wasSuccessful = false;
                result.errorMessage = this.scriptStatus;              
                return result;
            }
            try
            {
                /* not needed for import only needed for dump keeping as example
                if (!isServerCompatible())
                {
                    result.wasSuccessful = false;
                    result.errorMessage = "The user has no super priviledge on the server or binary logging is not enabled.";
                    return result;
                }*/
                result = executeSQLscript();
                //result = executeSQLscript();

            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = "import task: "+ex.Message;
            }

            return result;
        }

        /* old method using MySqlScript
        private ImportResultSet executeSQLscript()
        {
            ImportResultSet result = new ImportResultSet();

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            MySqlScript script = new MySqlScript(con, this.script);
            script.Delimiter = config.scriptDelimeter;
            script.StatementExecuted += scriptStatementExecuted;
            script.Execute();
            result.wasSuccessful = true;
            return result;
        }*/

        private ImportResultSet executeSQLscript()
        {
            ImportResultSet result = new ImportResultSet();

            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "resources/mysqldump/mysql.exe",
                    Arguments = buildMysqlexeArguments().ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                }
            };

            Console.WriteLine("Executing mysql.exe now.");
            proc.Start();

            try
            {
                StreamReader sr = new StreamReader(config.scriptPath);
                int index = 1;
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    proc.StandardInput.WriteLine(line);
                    onProgress(index);
                    index++;
                    //Console.WriteLine("Log file line: "+line);
                }
                proc.StandardInput.Close(); //ama den ginei auto perimenei endlessly gia input
                sr.Close();
            }catch(Exception ex)
            {
                result.wasSuccessful = false;
                if (proc == null || proc.HasExited)
                {
                    result.errorMessage = "Mysql.exe import proccess was killed.";
                }
                else
                {
                    result.errorMessage = "Mysql import: "+ex.Message;
                }
               
            }
            

            try
            {
                
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    Console.WriteLine("Mysql.exe output:" + line);
                }

                while (!proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    result.errorMessage += line + "\n";
                    Console.WriteLine("Mysql.exe error:"+line);
                }
                proc.WaitForExit();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Mysql.exe null reference exception on proccess: " + ex.Message);
            }

            if (proc == null || proc.ExitCode != 0)
            {
                result.wasSuccessful = false;
                if (proc == null)
                {
                    result.errorMessage = "Mysql.exe import proccess was killed.";
                }
            }
            else
            {
                result.wasSuccessful = true;
            }

            return result;
        }

        private void scriptStatementExecuted(object sender, MySqlScriptEventArgs e)
        {
            //to testara ligo to apo katw fenete na doulevei swsta
            commandCounter += StringUtils.countOccurances(e.StatementText, config.scriptDelimeter) + 1; //to +1 einai to delimeter(semicolon) sto telos kathe statement 
            onProgress(commandCounter);
        }

        private StringBuilder buildMysqlexeArguments()
        {
            StringBuilder arguments = new StringBuilder();
            //proswrina
            arguments.Append("-h ");
            arguments.Append(config.host);
            arguments.Append(" -u ");
            arguments.Append(config.username);
            arguments.Append(" -p");
            arguments.Append(config.password);
            if (config.port != 3306)
            {
                arguments.Append(" -P ");
                arguments.Append(config.port);
            }
            if (!string.IsNullOrWhiteSpace(config.database))
            {
                arguments.Append(" ");
                arguments.Append(config.database);
            }
            //Console.WriteLine(arguments.ToString());
            //Environment.Exit(0);
            return arguments;
        }

        public void cancelProcess()
        {
            if (proc != null && !proc.HasExited)
            {
                proc.Kill();
                proc.Dispose();
                proc = null;
            }
        }
        
    }
}
