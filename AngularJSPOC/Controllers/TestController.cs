using AngularJSPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSPOC.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Emp/
        public ActionResult Index()
        {
            return View();
        }

        // GET: All Employees
        public JsonResult GetAllEmployees()
        {
            using (ApplicationDbContext contextObj = new ApplicationDbContext())
            {
                var EmployeeList = contextObj.Emp.ToList();
                return Json(EmployeeList, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Employee by Id
        public JsonResult GetEmployeeById(string id)
        {
            using (ApplicationDbContext contextObj = new ApplicationDbContext())
            {
                var EmployeeId = Convert.ToInt32(id);
                var getEmployeeById = contextObj.Emp.Find(EmployeeId);
                return Json(getEmployeeById, JsonRequestBehavior.AllowGet);
            }
        }
        //Update Employee
        public string UpdateEmployee(Employee emp)
        {
            if (emp != null)
            {
                using (ApplicationDbContext contextObj = new ApplicationDbContext())
                {
                    int Empid = Convert.ToInt32(emp.Id);
                    Employee _emp = contextObj.Emp.Where(b => b.Id == Empid).FirstOrDefault();
                    _emp.Firstname = emp.Firstname;
                    _emp.Lastname = emp.Lastname;
                    _emp.EmailID = emp.EmailID;
                    _emp.Address = emp.Address;

                    contextObj.SaveChanges();
                    return "Employee record updated successfully";
                }
            }
            else
            {
                return "Invalid Employee record";
            }
        }
        // Add Employee
        public string AddEmployee(Employee emp)
        {
            if (emp != null)
            {
                using (ApplicationDbContext contextObj = new ApplicationDbContext())
                {
                    contextObj.Emp.Add(emp);
                    contextObj.SaveChanges();
                    return "Employee record added successfully";
                }
            }
            else
            {
                return "Invalid Employee record";
            }
        }
        // Delete Employee
        public string DeleteEmployee(string EmployeeId)
        {

            if (!String.IsNullOrEmpty(EmployeeId))
            {
                try
                {
                    int _EmpId = Int32.Parse(EmployeeId);
                    using (ApplicationDbContext contextObj = new ApplicationDbContext())
                    {
                        var _Employee = contextObj.Emp.Find(_EmpId);
                        contextObj.Emp.Remove(_Employee);
                        contextObj.SaveChanges();
                        return "Selected Employee record deleted sucessfully";
                    }
                }
                catch (Exception)
                {
                    return "Employee details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
	}
}