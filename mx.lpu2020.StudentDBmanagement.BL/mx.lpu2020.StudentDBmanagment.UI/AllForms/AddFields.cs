﻿using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mx.lpu2020.StudentDBmanagment.UI
{
    public partial class AddFields : Form
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        StudentRepositery studentRepositery;
        public AddFields()
        {
            try
            {
                log.Info("into the AddFields Constructer");
                InitializeComponent();
                studentRepositery = new StudentRepositery();
                log.Info("out of the AddFields Constructer");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("Unable to connect the database");
            }
        }

        //FOR ADD FIELDS BUTTON...
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the Add-fields button click listner");
                if (comboBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Please fill out the field name and field type ");
                }
                else
                {
                    studentRepositery = new StudentRepositery();
                    var Altered = studentRepositery.Alter(comboBox1.Text, textBox1.Text);
                    if (Altered)
                    {//  int result = Int32.Parse(input);
                        MessageBox.Show("Column added successfully");
                        label4.Text = "" + studentRepositery.GetNumberOfColumns();
                    }
                    else
                    {
                        MessageBox.Show("Some Error has occured ");
                    }
                }
                log.Info("out of the Add-fields button click listner");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("INVALID OR MALICIOUS ATTEMPT");
            }
           
        }

        private void AddFields_Load(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the Load Event of addfields form");
                label4.Text = "" + studentRepositery.GetNumberOfColumns();
                log.Info("out of the Load Event of addfields form");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("SERVER NOT RESPONDING");
            }
        }

        //HERE LABEL ONCLICK EVENT 
        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("click event for here label in addFields form");
                this.Hide();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("SOMETHING WENT WROMG");
            }
        }

    }
}
