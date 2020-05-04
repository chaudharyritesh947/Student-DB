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
    
    public class DatabaseController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
       

        StudentRepositery studentRepository = new StudentRepositery();

        //FOR HANDLING THE GET REQUEST WHICH DISPLAYS ALL THE DATA PRESENT IN THE TABLE.
        //api/Database
        [Route("api/Database")]
        [HttpGet]        
        public IEnumerable<Student> Get()
        {
            try
            {
                log.Info("get without parameters");
                return studentRepository.Retrive();
               
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
        }

        //FOR HANDLING THE GET REQUEST AS PER ID 
        //api/Database/id?id='value'
        [Route("api/Database/id")]
        [HttpGet]       
        public IEnumerable<Student> Get(int id)
        {
            try
            {
                log.Info("Into the get with id as a parameter");
                return studentRepository.Retrive(id);
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
        }

        //FOR HANDLING THE GET REQUEST AS PER THE SEARCHED INDEX
        //api/Database/index?index='value'
        [Route("api/Database/index")]
        [HttpGet]        
        public HttpResponseMessage Get(string index)
        {
            try
            {
                log.Info("into the with index as a parameter");
                return Request.CreateResponse(studentRepository.Retrive(index));
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }

        }

        //FOR HANDING THE GET REQUEST BASED THE SORTING ORDER AS PER DIFFERENT COLUMNS.
        //api/Database/sortbycolumn?sortin='value1'&column='value2'
        [Route("api/Database/sortbycolumn")]
        [HttpGet]        
        public HttpResponseMessage Get(string sortin, string column)
        {
            try
            {
                log.Info("into the get which takes two parameters");
                return Request.CreateResponse(studentRepository.Retrive(sortin, column));
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
        }

        //GET METHOD FOR GETING THE RESULT SEARCHED ACCORDING TO THE INDEX, AND SORTED ACCORDING TO COLUMN 
        //api/Database/sortbycolumnindex?index='value1'&sortin='value2'&column='value3'
        [Route("api/Database/sortbycolumnindex")]
        [HttpGet]        
        public HttpResponseMessage Get(string index, string sortin, string column)
        {
            try
            {
                log.Info("into the get which takes three parameters");
                return Request.CreateResponse(studentRepository.Retrive(index, sortin, column));
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
        }

        //FOR HANDING THE POST REQUEST, IN POST REQUEST DATA IS UPLOADED TO THE DATABASE
        //api/Database/Save
        [Route("api/Database/Save")]
        [HttpPost]      
        public IHttpActionResult Post([FromBody]Student student)
        {
            try
            {
                log.Info("into the post function");       
                studentRepository.Save(student);
                return Ok("Success");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
        }


        //FOR HANDING THE PUT REQUEST, IN PUT REQUEST DATA IS UPDATED
        //api/Database/Update
        [Route("api/Database/Update")]
        [HttpPut]       
        public IHttpActionResult Put([FromBody]Student student)
        {
            try
            {
                log.Info("into the put function");
                studentRepository.Update(student);
                return Ok("Success");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
        }

    }
}
