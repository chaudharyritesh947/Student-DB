using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mx.lpu2020.StudentDBmanagement.BL
{
  public class Auth
    {

        private static readonly log4net.ILog log = LogHelper.GetLogger();
        DatabaseManager databaseManager;

        
        public Auth()
        {
            try
            {
                log.Info("Into the auth constructer");
                databaseManager = new DatabaseManager();
                log.Info("out of the auth constructer");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }
        
        //METHOD FOR AUTHENTICATING AGAINST THE NAME AND PASSWORD
        public bool UserAuthentication(string username, string password)
        {
            try
            {
                log.Info("Into the userAuthentication function");
                if (databaseManager.Authenticate(username, password))
                {
                    log.Info("out of the userAuthentication function  on successfull authentication");
                    return true;
                }
                else
                {
                    log.Info("out of the userAuthentication function on unsuccessfull authentication");
                    return false;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }




    }
}
