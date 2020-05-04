using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.DL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mx.lpu2020.StudentDBmanagement.BL
{
    public class StudentRepositery
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        DatabaseManager databaseManager;
        public StudentRepositery()
        {
            try
            {
                log.Info("Into the studentRepository Constructor");
                databaseManager = new DatabaseManager();
                log.Info("out of the studentRepository Constructor");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }
            
        //FOR PERFORMING THE RETRIVAL OF ALL THE DATA 
        public List<Student> Retrive()
        {
            try
            {
                log.Info("Into the retrive function without parameter");
                List<Student> StudentRecord = new List<Student>();
                DbDataReader DbDataReader = databaseManager.RetrieveData("Select * from student");
                while (DbDataReader.Read())
                {
                    Student student = new Student
                    {
                        FirstName = DbDataReader.GetString(0),
                        LastName = DbDataReader.GetString(1),
                        Email = DbDataReader.GetString(2),
                        City = DbDataReader.GetString(3),
                        Gender = DbDataReader.GetString(4),
                        id = DbDataReader.GetString(5),
                    };
                    StudentRecord.Add(student);
                }
                log.Info("out of the retrive function without parameter");
                return StudentRecord;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR PERFORMING THE RETRIVAL OF THE DATA AGAINST ID 
        public List<Student> Retrive(int id)
        {
            try
            {
                log.Info("Into the retrive function with id as parameter");
                List<Student> StudentRecord = new List<Student>();
                DbDataReader DbDataReader = databaseManager.RetrieveData(string.Format("Select * from student where id = '{0}'", id));
                while (DbDataReader.Read())
                {
                    Student student = new Student
                    {
                        FirstName = DbDataReader.GetString(0),
                        LastName = DbDataReader.GetString(1),
                        Email = DbDataReader.GetString(2),
                        City = DbDataReader.GetString(3),
                        Gender = DbDataReader.GetString(4),
                        id = DbDataReader.GetString(5),
                    };
                    StudentRecord.Add(student);
                    log.Info("out of the retrive function with id as parameter");
                }

                return StudentRecord;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR PERFORMING THE RETRIVAL OF THE DATA AGAINST SEARCHINDEX
        public List<Student> Retrive(string searchIndex)
        {
            try
            {
                log.Info("into the retrive function with keyword as parameter");
                List<Student> StudentRecord = new List<Student>();
                string QueryString = string.Format("Select firstname, lastname, email, city, gender,id from student where match( lastname,firstname,email,city, gender,id) against ('{0}*' in boolean MODE)", searchIndex);
                DbDataReader DbDataReader = databaseManager.RetrieveData(QueryString);
                while (DbDataReader.Read())
                {
                    Student student = new Student
                    {
                        FirstName = DbDataReader.GetString(0),
                        LastName = DbDataReader.GetString(1),
                        Email = DbDataReader.GetString(2),
                        City = DbDataReader.GetString(3),
                        Gender = DbDataReader.GetString(4),
                        id = DbDataReader.GetString(5),
                    };
                    StudentRecord.Add(student);
                }
                log.Info("out of the retrive function with keyword as parameter");
                return StudentRecord;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR PERFORMING THE RETRIVAL OF THE SORTED DATA WITHRESPECT TO A PERTICULAR COLUMN.
        public List<Student> Retrive(string sortin, string column)
        {
            try
            {
                log.Info("into the retrive function with two parameter ");
                List<Student> StudentRecord = new List<Student>();
                string QueryString = "select * from student order by " + column + " " + sortin;
                DbDataReader DbDataReader = databaseManager.RetrieveData(QueryString);
                while (DbDataReader.Read())
                {
                    Student student = new Student
                    {
                        FirstName = DbDataReader.GetString(0),
                        LastName = DbDataReader.GetString(1),
                        Email = DbDataReader.GetString(2),
                        City = DbDataReader.GetString(3),
                        Gender = DbDataReader.GetString(4),
                        id = DbDataReader.GetString(5),
                    };
                    StudentRecord.Add(student);
                }
                log.Info("out of the retrive function with two parameter ");
                return StudentRecord;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR PERFORMING THE RETRIVAL OF THE DATA WITHRESPECT TO A PERTICULAR ID.
        public List<Student> Retrive(int id, string sortingOrder, string text)
        {
            try
            {
                log.Info("into the retrive function with three parameter id, sorting order and column name");
                string Query = string.Format("Select * from student where id = '{0}' order by ", id);
                Query += " order by " + text + " " + sortingOrder;
                List<Student> StudentRecord = new List<Student>();
                DbDataReader DbDataReader = databaseManager.RetrieveData(Query);
                while (DbDataReader.Read())
                {
                    Student student = new Student
                    {
                        FirstName = DbDataReader.GetString(0),
                        LastName = DbDataReader.GetString(1),
                        Email = DbDataReader.GetString(2),
                        City = DbDataReader.GetString(3),
                        Gender = DbDataReader.GetString(4),
                        id = DbDataReader.GetString(5),
                    };
                    StudentRecord.Add(student);
                }
                log.Info("out of the retrive function with three parameter id, sorting order and column name");
                return StudentRecord;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }

        }

        //FOR PERFORMING THE RETRIVAL OF DATA SEARCHED WITH AN INDEX AND SORTED ACCORDING TO THE COLUMN
        public List<Student> Retrive(string text1, string sortingOrder, string text2)
        {
            try
            {
                log.Info("into the retrive function with three parameter keyword, sorting order and column name");
                List<Student> StudentRecord = new List<Student>();
                string query = string.Format("Select firstname, lastname, email, city, gender,id from student where match( lastname,firstname,email,city, gender,id) against ('{0}*' in boolean MODE)  order by ", text1);
                query += text2 + " " + sortingOrder;
                DbDataReader DbDataReader = databaseManager.RetrieveData(query);
                while (DbDataReader.Read())
                {
                    Student student = new Student
                    {
                        FirstName = DbDataReader.GetString(0),
                        LastName = DbDataReader.GetString(1),
                        Email = DbDataReader.GetString(2),
                        City = DbDataReader.GetString(3),
                        Gender = DbDataReader.GetString(4),
                        id = DbDataReader.GetString(5),
                    };
                    StudentRecord.Add(student);
                }
                log.Info("out of the retrive function with three parameter id, sorting order and column name");
                return StudentRecord;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR SAVING THE DATA INSIDE THE DATABASE
        public bool Save(Student student)
        {
            try
            {
                log.Info("into the Save function");
                string FirstName = student.FirstName;
                string LastName = student.LastName;
                string Email = student.Email;
                string City = student.City;
                string Gender = student.Gender;
                string QueryString = string.Format("Insert into Student(firstName,lastName,email,city,gender) Values('{0}','{1}','{2}','{3}','{4}')", FirstName, LastName, Email, City, Gender);
                int row_count = databaseManager.UpdateData(QueryString);
                if (row_count > 0)
                {
                    log.Info("out of the Save function with true output");
                    return true;
                }
                log.Info("out of the Save function with false output");
                return false;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR UPDATION OF DATA
        public bool Update(Student student)
        {
            try
            {
                log.Info("into the update function");
                DatabaseManager databaseManager = new DatabaseManager();
                string FirstName = student.FirstName;
                string LastName = student.LastName;
                string Email = student.Email;
                string City = student.City;
                string Gender = student.Gender;
                string id = student.id;               
                string QueryString = "UPDATE student SET firstname = " + "'" + FirstName + "'" + ",lastname=" + "'" + LastName + "'" + ",email=" + "'" + Email + "'" + ",city=" + "'" + City + "'" + ",gender="+"'"+Gender+"'"+" where id = "+ id+"; ";             
                int row_count = databaseManager.UpdateData(QueryString);
                if (row_count > 0)
                {
                    log.Info("out of the update function with true output");
                    return true;
                }
                else {
                    log.Info("out of the update function with false output");
                    return false;
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR ADDING COLUMN TO THE TABLE
        public bool Alter(string FieldType, string FieldName)
        {
            try
            {
                log.Info("into the alter function");
                string query = "ALTER TABLE student ADD " + FieldName + " " + FieldType + " NULL";
                int row_count = databaseManager.UpdateData(query);
                if (row_count == 0)
                {
                    log.Info("out of the alter function with false output");
                    return false;
                }
                log.Info("out of the alter function with true output");
                return true;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        //FOR GETTING THE TOTAL NUMBER OF COLUMNS INSIDE THE TABLE.
        public int GetNumberOfColumns()
        {
            try
            {
                log.Info("into the getNumberOfColumns function");
                string queryString = "SELECT count(*) FROM information_schema.columns WHERE table_name = 'student'";
                int NumberOfColumns = databaseManager.GetNumberOfColumns(queryString);
                log.Info("out of the getNumberOfColumns function");
                return NumberOfColumns;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }


    }
}
