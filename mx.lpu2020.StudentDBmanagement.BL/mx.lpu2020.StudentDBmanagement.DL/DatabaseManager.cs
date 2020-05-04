using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;

//using System.Data.MySqlClient;
using System.Data.SqlClient;
using mx.lpu2020.StudentDB.common;

namespace mx.lpu2020.StudentDBmanagement.DL
{
    public class DatabaseManager
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private MySqlConnection con;
        private MySqlCommand com;

        //DATABASEMANAGER NON PARAMETERISED CONSTRUCTOR WHICH MAKES THE CONNECTION WITH MYSQL SERVER
        public DatabaseManager()
        {
            try
            {
                log.Info("Making Connection");
                string connectionString = "Data Source=localhost;Port = 3306;Initial Catalog=RK;User Id=root;password=''";
                con = new MySqlConnection(connectionString);
                con.Open();
                com = con.CreateCommand();
                com.CommandType = CommandType.Text;
                log.Info("Connection made");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }
             
        //METHOD FOR HANDLING THE QUERY WHICH DEMANDS FETCHING OF DATA
        public DbDataReader RetrieveData(string QueryString)
        {
            try
            {
                log.Info("Into the retrieveData function");
                com.CommandText = QueryString;
                DbDataReader DbReader = com.ExecuteReader();
                log.Info("out of retrieveData function");
                return DbReader;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }
        
        //FOR INSERTING AND UPDATING THE RECORDS IN THE DATABASE
        public int UpdateData(string QueryString)
        {
            try
            {
                com.CommandText = QueryString;                
                return com.ExecuteNonQuery(); ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        //FOR PERFORMING THE AUTHENTICATION
        public bool Authenticate(string username, string password)
        {
            try
            {
                log.Info("Authticate function started");
                int i = 0;
                com.CommandText = string.Format("select * from login_credential where UserName = '{0}' and Password = '{1}'", username, password);
                com.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                log.Info("Authticate function ended");
                if (i == 0)
                {
                    log.Info("Authticate function ended with false result");
                    return false;
                }
                else
                {
                    log.Info("Authticate function ended with true result");
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR GETTING THE TOTAL NUMBER OF COLUMNS
        public int GetNumberOfColumns(string queryString)
        {

            try
            {
                log.Info("into get number of columns");
                var query = new MySqlCommand(queryString, this.con);
                int mysqlint = int.Parse(query.ExecuteScalar().ToString());
                log.Info("out of the get number of columns");
                return mysqlint;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }
    }
}