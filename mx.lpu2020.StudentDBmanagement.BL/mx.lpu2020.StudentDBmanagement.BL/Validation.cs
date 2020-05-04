using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mx.lpu2020.StudentDBmanagement.BL
{
   public class Validation
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();


        //FOR VALIDATING THE FIELDS RELATED TO LOGIN ACTIVITY
        public int ValidateLogin(string username, string password)
        {
            try
            {
                log.Info("Into the ValidateLogin function");
                int IsValidate = 0;
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                {
                    IsValidate = 1;
                }
                else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                {
                    IsValidate = 2;
                }
                log.Info("out of the ValidateLogin function");
                return IsValidate;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR VALIDATING THE FIELDS RELATED TO ADD RECORD ACTIVITY
        public int ValidateAddRecord(string firstname, string lastname, string email, string city, string gender)
        {
            try
            {
                log.Info("Into the ValidateRecord function");
                int IsValidate = 0;
                if (string.IsNullOrEmpty(firstname) || string.IsNullOrWhiteSpace(firstname))
                {
                    IsValidate = 1;
                }
                else if (string.IsNullOrEmpty(lastname) || string.IsNullOrWhiteSpace(lastname))
                {
                    IsValidate = 2;
                }
                else if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                {
                    IsValidate = 3;
                }
                else if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city))
                {
                    IsValidate = 4;
                }
                else if (string.IsNullOrEmpty(gender) || string.IsNullOrWhiteSpace(gender))
                {
                    IsValidate = 5;
                }
                log.Info("out of the ValidateRecord function");
                return IsValidate;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR CHECKING THE ACTIVITY OF SQL INJECTION
        public bool IsMaliciousAttempt(string Test)
        {
            try
            {
                log.Info("Into the isMaliciousAttempt function with one parameter");
                bool isInjectionText = false;
                Regex r1 = new Regex("^[A-Za-z][A-Za-z0-9]*$");
                Match match = r1.Match(Test);
                if (match.Success)
                {
                    isInjectionText = false;
                }
                else
                {
                    isInjectionText = true;
                }
                log.Info("out of the isMaliciousAttempt function with one parameter");
                return isInjectionText;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR CHECKING THE ACTIVITY OF SQL INJECTION
        public bool IsMaliciousAttempt(string text1, string text2)
        {

            try
            {
                log.Info("into the isMaliciousAttempt function with two parameter ");
                bool isInjectionText1 = false, isInjectionText2 = false;
                Regex r1 = new Regex("^[A-Za-z][A-Za-z0-9]*$");
                Match match = r1.Match(text1);
                if (match.Success)
                {

                    isInjectionText1 = false;
                }
                else
                {
                    isInjectionText1 = true;
                }
                match = r1.Match(text2);
                if (match.Success)
                {
                    isInjectionText2 = false;
                }
                else
                {
                    isInjectionText2 = true;
                }

                if (isInjectionText1 == false && isInjectionText2 == false)
                {
                    return false;
                }
                log.Info("out of the isMaliciousAttempt function with two parameter ");
                return true;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }       
        }

        //FOR CHECKING THE ACTIVITY OF SQL INJECTION
        public bool IsMaliciousAttempt(string text1, string text2, string text3, string text4, string text5)
        {

            try
            {
                log.Info("into the isMaliciousAttempt function with maximum parameter ");
                bool isInjectionText1 = false, isInjectionText2 = false, isInjectionText3 = false, isInjectionText4 = false, isInjectionText5 = false;
                Regex r1 = new Regex("^[A-Za-z][A-Za-z0-9]*$");
                Match match = r1.Match(text1);
                if (match.Success)
                {

                    isInjectionText1 = false;
                }
                else
                {
                    isInjectionText1 = true;
                }

                match = r1.Match(text2);
                if (match.Success)
                {
                    isInjectionText2 = false;
                }
                else
                {
                    isInjectionText2 = true;
                }

                match = r1.Match(text3);
                if (match.Success)
                {
                    isInjectionText2 = false;
                }
                else
                {
                    isInjectionText2 = true;
                }

                match = r1.Match(text4);
                if (match.Success)
                {
                    isInjectionText2 = false;
                }
                else
                {
                    isInjectionText2 = true;
                }

                match = r1.Match(text5);
                if (match.Success)
                {
                    isInjectionText2 = false;
                }
                else
                {
                    isInjectionText2 = true;
                }

                if (isInjectionText1 == false && isInjectionText2 == false && isInjectionText3 == false && isInjectionText4 == false && isInjectionText5 == false)
                {
                    return false;
                }
                log.Info("out of the isMaliciousAttempt function with maximum parameter ");
                return true;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }
    }
}
