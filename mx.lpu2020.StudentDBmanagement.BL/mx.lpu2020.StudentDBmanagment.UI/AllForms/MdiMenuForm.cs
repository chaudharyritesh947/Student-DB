﻿using mx.lpu2020.StudentDB.common;
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
    public partial class MdiMenuForm : Form
    {
        Add_Record addRecord;
        ViewRecords viewRecords;
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public MdiMenuForm()
        {
            try
            {
                log.Info("mdimenuform constructor");
                InitializeComponent();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
            }
        }       

        //HANDLER FOR LOAD EVENT OF MDIMENUFORM
        private void MdiMenuForm_Load(object sender, EventArgs e)
        {

            try
            {
                log.Info("into the MdiMenuForm load function");
                Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.CadetBlue;
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
            //   MessageBox.Show("Please select the Menu for more option);
        }     

        //MENU CLICK EVENT HANDLER.

        //ADRECORDS SUB-MENU CLICK EVENT HANDLER.
        private void addRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            try
            {              
                log.Info("into the addrecord sub-menu click function ");
                if (addRecord == null)
                {
                    if (viewRecords != null)
                    {
                        viewRecords.Hide();
                        viewRecords = null;
                    }                    
                    addRecord = new Add_Record();
                    addRecord.MdiParent = this;
                    addRecord.Show();
                    addRecord.Location = new Point(70, 30);
                }
                else
                {
                    addRecord.Activate();
                }
                log.Info("out of the addrecord sub-menu click function ");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("PLEASE RESTART YOUR APPLICATION");
            }
        }

        //VIEWRECORDS SUB-MENU CLICK EVENT HANDLER.
        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                log.Info("into the click event of viewRecords sub-menu function");
                if (viewRecords == null)
                {
                    if (addRecord != null)
                    {

                        addRecord.Hide();
                        addRecord = null;
                    }
                    viewRecords = new ViewRecords();
                    viewRecords.MdiParent = this;
                    viewRecords.Show();
                    viewRecords.Location = new Point(27, 25);
                }
                else
                {
                    viewRecords.Activate();
                }
                log.Info("out of the click event of viewRecords sub-menu function");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("PLEASE RESTART YOUR APPLICATION");
            }
        }
        //EXIT BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        //MENU TOOL STRIP
        private void menuToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the Menu button hover event listner");
                menuToolStripMenuItem.BackColor = Color.Red;
                log.Info("out of the Menu button hover event listner");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //MENU BUTTON EVENT LISTNER FOR MOUSE LEAVE
        private void menuToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-leave event listner function");
                menuToolStripMenuItem.ForeColor = Color.White;
                log.Info("out of the mouse-leave event listner function");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //MENU BUTTON EVENT LISTENER ON MOUSE MOVE.
        private void menuToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the mouse-move event listner function");
                menuToolStripMenuItem.ForeColor = Color.Red;
                log.Info("out of the mouse-move event listner function");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }
     
        //ADDRECORD SUB-MENU EVENT LISTNER ON MOUSE HOVER.
        private void addRecordsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            try
            {
                log.Info("in the addrecord sub-menu hover event listner");
                addRecordsToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the addrecord sub-menu hover event listner");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //ADDRECORD SUB-MENU EVENT LISTNER ON MOUSE LEAVE
        private void addRecordsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the addrecord mouse-leave event listener");
                addRecordsToolStripMenuItem.ForeColor = Color.White;
                log.Info("out of the mouse-leave event listener");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //ADDRECORD SUB-MENU EVENT LISTNER ON MOUSE MOVE
        private void addRecordsToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the addrecord mouse-move event listener");
                addRecordsToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the addrecord mouse-move event listener");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }


        //ADDRECORD SUB-MENU EVENT LISTNER ON MOUSE UP
        private void addRecordsToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the addrecord mouse-up function");
                addRecordsToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the addrecord mouse-up function");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //VIEWRECORD SUB-MENU EVENT LISTNER ON MOUSE HOVER
        private void viewRecordsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-hover viewrecords sub-menu");
                viewRecordsToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the mouse-hover viewrecords sub-menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //VIEWRECORD SUB-MENU EVENT LISTNER ON MOUSE LEAVE
        private void viewRecordsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-leave viewrecords sub-menu");
                viewRecordsToolStripMenuItem.ForeColor = Color.White;
                log.Info("out of the mouse-leave viewrecords sub-menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //VIEWRECORD SUB-MENU EVENT LISTNER ON MOUSE UP
        private void viewRecordsToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the mouse-up of viewrecords sub-menu");
                viewRecordsToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the mouse-up of viewrecords sub-menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //VIEWRECORD SUB-MENU EVENT LISTNER ON MOUSE MOVE
        private void viewRecordsToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the mouse-move of viewrecords sub-menu");
                viewRecordsToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the mouse-move of viewrecords sub-menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //HIDE MENU EVENT LISTNER ON MOUSE LEAVE
        private void hideToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-leave of hide menu");
                hideToolStripMenuItem.ForeColor = Color.White;
                log.Info("out of the mouse-leave of hide menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }

        }

        //HIDE MENU CLICK EVENT LISTNER
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-click of hide menu");
                if (addRecord != null)
                {
                    addRecord.Hide();
                    addRecord = null;
                }
                if (viewRecords != null)
                {
                    viewRecords.Hide();
                    viewRecords = null;
                }
                log.Info("out of the mouse-click of hide menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //HIDE MENU EVENT LISTNER FOR MOUSE HOVER 
        private void hideToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-hover of hide menu");
                hideToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the mouse-hover of hide menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //HIDE MENU EVENT LISTNER FOR MOUSE MOVE
        private void hideToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the mouse-move of hide menu");
                hideToolStripMenuItem.ForeColor = Color.Black;
                log.Info("out of the mouse-move of hide menu");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //CROSS BUTTON (EXIT BUTTON) EVENT LISTNER FOR MOUSE HOVER
        private void button1_MouseHover(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-hover of exit button");
                button1.BackColor = Color.Red;
                log.Info("out of the mouse-hover of exit button");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }

        }

        //CROSS BUTTON (EXIT BUTTON) EVENT LISTNER FOR MOUSE LEAVE
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the mouse-leave of exit button");
                button1.BackColor = Color.LightCoral;
                log.Info("out of the mouse-leave of exit button");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }

        //CROSS BUTTON (EXIT BUTTON) EVENT LISTNER FOR MOUSE MOVE
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                log.Info("into the mouse-move of exit button");
                button1.BackColor = Color.Red;
                log.Info("out of the mouse-move of exit button");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPLICATION ERROR");
            }
        }
        
        //LOGOUT BUTTON ONCLICK EVENT HANDLER.
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the onClick of logout button");
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
                log.Info("out of the onClick of logout button");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("APPILCATION ERROR");
            }
        }
    }
}
