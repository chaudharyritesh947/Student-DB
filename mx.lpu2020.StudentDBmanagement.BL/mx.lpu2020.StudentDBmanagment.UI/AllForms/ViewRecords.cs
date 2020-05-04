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
    public partial class ViewRecords : Form
    {
        StudentRepositery studentRepository;
        Validation validation;
        public static DataGridViewRow row;
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public ViewRecords()
        {
            try
            {
                log.Info("into the viewRecords constructor");   
                InitializeComponent();
                validation = new Validation();
                studentRepository = new StudentRepositery();
                log.Info("out of the viewRecords constructor");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("PLEASE RESTART THE APPLICATION");
            }
        }

        //THIS FUNCTION HANDLES THE ONLOAD EVENT PF VIEWRECORDS FORM
        private void ViewRecords_Load(object sender, EventArgs e)
        {
            
            ViewAll();  
        }
        
        //BUTTON FOR PERFORMING THE SEARCH OPERATION
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the search button click function");
                studentRepository = new StudentRepositery();
                //Text validation is necessary here also.
                List<Student> studentList;
                if (string.IsNullOrWhiteSpace(comboBox3.Text))
                {
                    MessageBox.Show("Please select the your way of searching.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please key/id to search");
                }
                else if (comboBox3.Text.Equals("ID"))
                {
                    int id = Int32.Parse(textBox1.Text);
                    studentList = studentRepository.Retrive(id);
                    dataGridView1.DataSource = studentList;
                }
                else if (comboBox3.Text.Equals("KEYWORD"))
                {

                    int i;
                    bool Number = int.TryParse(textBox1.Text, out i);
                    if (Number == true)
                    {
                        //textbox integer hai toh gadbad hai.
                        MessageBox.Show("Invalid Keyword, you can not use Numbers here");
                    }
                    else
                    {
                        if (!validation.IsMaliciousAttempt(textBox1.Text))
                        {
                            studentList = studentRepository.Retrive(textBox1.Text);
                            dataGridView1.DataSource = studentList;
                        }
                        else
                        {
                            MessageBox.Show("Malicious Attempt");
                        }
                    }
                  
                }
                else {
                    MessageBox.Show("PLEASE USE THE KEYWORDS AVAILABLE IN THE SEARCH DROPBOX");
                    comboBox3.Text = "";
                    textBox1.Text = "";

                }
                log.Info("out of the search button click function");
            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("Invalid or Malicious attempt");
            }
        }
    
        //FUNCTION FOR HANDLING THE ONCLICK EVENT OF VIEW ALL BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            ViewAll();
        }
       
        //THIS METHOD DISPLAYS ALL THE RECORD
        public void ViewAll()
        {
            try
            {
                log.Info("into the viewall function");
                studentRepository = new StudentRepositery();
                List<Student> studentList = studentRepository.Retrive();
                dataGridView1.DataSource = studentList;
                log.Info("out of the viewall function");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("SOMETHING WENT WRONG: PLEASE RESTART THE APPLICATION");
            }
        }    
      
        //BUTTON FOR HANDLING THE CLICK EVENT OF GO BUTTON 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the sort button click function");
                List<Student> studentList;
                studentRepository = new StudentRepositery();
                if(string.IsNullOrWhiteSpace(comboBox3.Text) && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    string SortingOrder = comboBox1.Text.Equals("Ascending Order") ? " ASC " : " DESC ";

                    if (string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrWhiteSpace(comboBox2.Text))
                    {
                        comboBox1.Text = "Descending order";
                        comboBox2.Text = "firstname";
                    }
                    studentList = studentRepository.Retrive(SortingOrder, comboBox2.Text);
                    dataGridView1.DataSource = studentList;

                }
                else if (!string.IsNullOrWhiteSpace(comboBox3.Text))
                {

                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Please type in the keyword/Id you want to search ");
                    }
                    else if (comboBox3.Text.Equals("ID"))
                    {
                        string SortingOrder = comboBox1.Text.Equals("Ascending Order") ? " ASC " : " DESC ";

                        if (string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrWhiteSpace(comboBox2.Text))
                        {
                            comboBox1.Text = "Descending order";
                            comboBox2.Text = "firstname";
                        }
                        int id = Int32.Parse(textBox1.Text);

                        //I have to work on this
                        studentList = studentRepository.Retrive(id, SortingOrder, comboBox2.Text);
                        dataGridView1.DataSource = studentList;
                    }
                    else if (comboBox3.Text.Equals("KEYWORD"))
                    {

                        string SortingOrder = comboBox1.Text.Equals("Ascending Order") ? " ASC " : " DESC ";
                        int i;
                        bool bNum = int.TryParse(textBox1.Text, out i);
                        if (bNum == true)
                        {
                            //textbox integer hai toh gadbad hai.
                            MessageBox.Show("Invalid Keyword, you can not use Numbers here");
                        }
                        else
                        {

                            if (!validation.IsMaliciousAttempt(textBox1.Text))
                            {
                                studentList = studentRepository.Retrive(textBox1.Text,SortingOrder,comboBox2.Text);
                                dataGridView1.DataSource = studentList;
                            }
                            else
                            {
                                MessageBox.Show("Malicious Attempt");
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("PLEASE FILL ALL THE FIELDS");
                    }

                }
                log.Info("out of the sort button click function");

            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("invalid or malicious attempt");
            }
        }
       
        //FUNCTION TO HANDLE THE CHANGE OF CELL VALUE.
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                log.Info("into the cellvaluechanged function");
                row = new DataGridViewRow();
                row = this.dataGridView1.Rows[e.RowIndex];
                int res = validation.ValidateAddRecord(row.Cells["FirstName"].Value.ToString(), row.Cells["LastName"].Value.ToString(), row.Cells["Email"].Value.ToString(), row.Cells["City"].Value.ToString(), row.Cells["Gender"].Value.ToString());
                if (res == 0)
                {
                    Student student = new Student
                    {
                        FirstName = row.Cells["FirstName"].Value.ToString(),
                        LastName = row.Cells["LastName"].Value.ToString(),
                        Email = row.Cells["Email"].Value.ToString(),
                        City = row.Cells["City"].Value.ToString(),
                        Gender = row.Cells["Gender"].Value.ToString(),
                        id = row.Cells["id"].Value.ToString(),
                    };
                   
                    
                    var hasUpdated = studentRepository.Update(student);
                    if (hasUpdated == true)
                    {
                        MessageBox.Show("DATA UPDATED SUCCESSFULLY");
                    }
                    else
                    {
                        MessageBox.Show("UPDATION FAILED");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please Fill the cell");
                }
                log.Info("out of the cellvaluechanged function");
            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("Malicious Activity: Please avoid using the special characters or please fill the cell");
            }
        }

        //FUNCTIONALITY FOR CLEAR ALL BUTTON
        private void button4_Click(object sender, EventArgs e)
        {            
            try
            {
                log.Info("into the on click function of clearAll button");
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox1.Text = "";
                log.Info("out of the on click function of clearAll button");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }

        }
 
        //HOVER, MOVE, LEAVE EVENT HANDLER FUNCTIONS
        private void ChangeColorOnMouseMoveForButtonOne(object sender, EventArgs e)
        {
            try
            {
                
                button1.BackColor = Color.White;
                button1.ForeColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        private void ChangeColorOnMouseLeaveForButtonOne(object sender, EventArgs e)
        {
            try
            {
                button1.ForeColor = Color.White;
                button1.BackColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        private void ChangeColorOnMouseMoveForButtonTwo(object sender, EventArgs e)
        {
            try
            {
                button2.BackColor = Color.White;
                button2.ForeColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        private void ChangeColorOnMouseLeaveForButtonTwo(object sender, EventArgs e)
        {
            try
            {
                button2.ForeColor = Color.White;
                button2.BackColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        private void ChangeColorOnMouseMoveForButtonThree(object sender, EventArgs e)
        {
            try
            {
                button3.BackColor = Color.White;
                button3.ForeColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        private void ChangeColorOnMouseLeaveForButtonThree(object sender, EventArgs e)
        {
            try
            {
                button3.ForeColor = Color.White;
                button3.BackColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }
        private void ChangeColorOnMouseMoveForButtonFour(object sender, EventArgs e)
        {
            try
            {
                button4.BackColor = Color.White;
                button4.ForeColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        private void ChangeColorOnMouseLeaveForButtonFour(object sender, EventArgs e)
        {
            try
            {
                button4.ForeColor = Color.White;
                button4.BackColor = Color.DarkSlateGray;
            }
            catch (Exception exception)
            {
                MessageBox.Show("APPLICATION ERROR");
            }
        }

             
    }
}
