using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentDBWebApi.Controllers
{
    public class AccountLoginController : ApiController
    {

        private static readonly log4net.ILog log = LogHelper.GetLogger();

        //HANDELS LOGIN ACTIVITY
        //GET METHOD WHICH RETURNS THE SUCCESS OR FAILURE BASED ON THE CREDENTIALS PROVIDED.
        //api/AccountLogin/Credential?name=''&password=''
        Auth auth = new Auth();
        [Route("api/AccountLogin/Credential")]
        [HttpGet]
        public string Get(string name , string password)
        {
            try
            {
                log.Info("into the get function of AccounLoginController");                
                var authenticated = auth.UserAuthentication(name, password);
                if (authenticated == true)
                {
                    log.Info("out of the get function of AccounLoginController with returned value true");
                    return "success";
                }
                log.Info("out of the get function of AccounLoginController with returned value false");
                return "Invalid";               
            }
            catch (Exception exception)
            {
                log.Error(exception);
                throw exception;
            }

        }
    }
}
