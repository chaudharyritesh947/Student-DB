using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mx.lpu2020.StudentDBmanagment.UI
{
    public partial class Form1 : Form
    {

        private static readonly log4net.ILog log = LogHelper.GetLogger();
        StudentRepositery studentRepositery;
        Validation validation;
        Auth Auth;
        public Form1()
        {
            try
            {
                log.Info("into the form1 constructer");
                InitializeComponent();
            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("Invalid or Malicious attempt: " + e1);
            }
        }

        //LOAD EVENT FOR FORM1
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the load function of form1");
                studentRepositery = new StudentRepositery();
                validation = new Validation();
                Auth = new Auth();
                log.Info("out of the form1 constructer");
            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("PLEASE RESTART THE APPLICATION");
            }
         
        }
      
        //LOGIN BUTTON
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the click event listner of login button");
                int result = validation.ValidateLogin(usernameTB.Text, passwordTB.Text);
                if (result == 1)
                {
                    MessageBox.Show("User Name Cannot be left empty");
                }
                else if (result == 2)
                {
                    MessageBox.Show("Password can not be left empty");
                }
                else if (validation.IsMaliciousAttempt(usernameTB.Text,passwordTB.Text) == true)
                {
                    MessageBox.Show("Malicious Attempt");

                }
                else if (Auth.UserAuthentication(usernameTB.Text,passwordTB.Text) == true)
                {
                    this.Hide();
                    MdiMenuForm mdiMenuForm = new MdiMenuForm();
                    mdiMenuForm.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is wrong!!");
                }
                log.Info("out of the click event listner of login button");
            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("Invalid or Malicious input: " + e1.Message);
            }
        }
       
        //BUTTON FOR EXIT
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("Exit button click event listner");
                Environment.Exit(0);
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
            }
        }
    }
    }

