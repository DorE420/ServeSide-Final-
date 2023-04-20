using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using DATA;
using WebApplication2check.DTO;
using NLog;
namespace WebApplication2check.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/Employee/5


        [HttpGet]
        [Route("api/employee/get")]
        public IHttpActionResult Get()
        {
            igroup196DbContext1 db = new igroup196DbContext1();

            try
            {
                var employess = db.Employee.Select(x => new EmployeeDTO()
                {
                    employee_name = x.employee_name,
                    employee_id = x.employee_id,
                    employee_familyname = x.employee_familyname,
                    employee_PhoneNumber = x.employee_PhoneNumber,
                    employee_gender = x.employee_gender,
                    employee_pw = x.employee_pw,
                    employee_email = x.employee_email,
                    employee_startDate = x.employee_startDate,
                    isActive = x.isActive,
                    employee_picture = x.employee_picture




                });

                return Ok(employess);


            }
            catch (Exception)
            {
                logger.Error("Cant Connect with DataBase");
                return BadRequest("Cant Fetch Employee Data");

            }






        }



        // POST: api/Employee
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        [Route("api/employee/login")]
        public IHttpActionResult Login([FromBody] LoginModelDTO login)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            // Authenticate the user using the provided username and password
            bool isAuthenticated = AuthenticateUser(login.username, login.password);

            if (isAuthenticated)
            {
                //possible added security token 
                logger.Info($"User {login.username} Entered System");
                return Ok("User Authenticated Successfully");
            }
            else
            {
                // Return an error response
                logger.Error("User didnt Log into System");
                return BadRequest("Invalid username or password");

            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            igroup196DbContext1 db = new igroup196DbContext1();


            var user = db.Employee.FirstOrDefault(x => x.employee_id.ToString() == username);
            if (user != null && user.employee_pw == password)
            {
                return true;
                //User is authenticated
            }
            else
            {
                return false;
                // Authentication failed
            }


        }

        [HttpPost]
        [Route("api/employee/resetpw")]
        public IHttpActionResult Post([FromBody] LoginModelDTO resetpw)
        {
            igroup196DbContext1 db = new igroup196DbContext1();

            var userResetpw = db.Employee.FirstOrDefault(x => x.employee_id.ToString() == resetpw.username && x.employee_email == resetpw.EmployeeEmail);
            try
            {
                if (userResetpw != null)
                {
                    string newPassword = GeneratePassword(9);
                    userResetpw.employee_pw = newPassword;
                    db.SaveChanges();
                    // will change to be send dierctly to User E-mail Address
                    logger.Info($"User {resetpw.username} Changed PW");
                    return Ok($"Your new password is: {newPassword}");
                }
                else
                {
                    logger.Error("User PW not changed");
                    return BadRequest("User Information Not Found");
                }
            }
            catch (Exception)
            {
                logger.Warn("exception on PW Change");
                return BadRequest("Server Issue");
            }


        }

        private static string GeneratePassword(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:,.<>?";

            var random = new Random();
            var password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }



        [HttpPost]
        [Route("api/employee/post")]
        public IHttpActionResult Post([FromBody] EmployeeDTO emp)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            try
            {
                var newEmployee = new Employee
                {

                    employee_name = emp.employee_name,
                    employee_id = emp.employee_id,
                    employee_familyname = emp.employee_familyname,
                    employee_PhoneNumber = emp.employee_PhoneNumber,
                    employee_gender = emp.employee_gender,
                    employee_pw = emp.employee_pw,
                    employee_email = emp.employee_email,
                    isActive = emp.isActive,
                    employee_startDate = emp.employee_startDate,
                    employee_picture = emp.employee_picture
                };

                db.Employee.Add(newEmployee);
                db.SaveChanges();
                logger.Info("New Employee Added");
                return Ok("Employee Added successfully");

            }
            catch (Exception)
            {
                logger.Error("Error Uploading New Employee");
                return BadRequest("Error");
            }




        }


        // PUT: api/Employee/5


        [HttpPut]
        [Route("api/employee/put")]
        public IHttpActionResult Put([FromBody] EmployeeDTO emp)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            Employee employee1 = db.Employee.Where(x => x.employee_id == emp.employee_id).FirstOrDefault();
            try
            {
                if (employee1 != null)
                {
                    employee1.employee_id = emp.employee_id;
                    employee1.employee_name = emp.employee_name;
                    employee1.employee_familyname = emp.employee_familyname;
                    employee1.employee_pw = emp.employee_pw;
                    employee1.employee_gender = emp.employee_gender;
                    employee1.employee_PhoneNumber = emp.employee_PhoneNumber;
                    employee1.employee_startDate = emp.employee_startDate;
                    employee1.employee_picture = emp.employee_picture;
                    db.SaveChanges();
                    logger.Info($"Employee {emp.employee_id} updated");
                    return Ok("Employee Updated Successfully");
                }

                logger.Error("Update Try Failure");
                return BadRequest("Cant Update, Employee info not found");
            }
            catch (Exception)
            {
                logger.Warn("Exception");
                return BadRequest("cant update");
            }





        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {

        }


        [HttpDelete]
        [Route("api/employee/delete")]
        public IHttpActionResult Delete([FromBody] EmployeeDTO emp)
        {
            igroup196DbContext1 db = new igroup196DbContext1();
            var user = db.Employee.FirstOrDefault(x => x.employee_id == emp.employee_id);
            if (user != null)
            {
                db.Employee.Remove(user);
                db.SaveChanges();
                logger.Info($"User {emp.employee_id} Deleted");
                return Ok("Employee deleted");
            }
            else
            {
                logger.Error("User Not deleted Not Found");
                return BadRequest("Invalid username or password");
            }


        }
    }
}
