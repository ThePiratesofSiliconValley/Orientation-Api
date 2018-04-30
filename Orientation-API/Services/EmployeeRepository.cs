using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;

namespace Orientation_API.Services
{
    public class EmployeeRepository
    {
        public IEnumerable<EmployeeDto> Get()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var listOfEmployees = db.Query<EmployeeDto>(@"SELECT e.FirstName + ' ' + e.LastName as EmployeeName,
                                                                     d.DepartmentName
                                                              FROM Employees e
                                                              JOIN Departments d on d.DepartmentId = e.DepartmentId
                                                              WHERE e.SeparationDate is null
                                                              ORDER BY d.DepartmentId");
                return listOfEmployees;
            }            
        }

        internal Employee GetSingleEmployee(int id)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var singleEmployee = db.QueryFirst<Employee>(@"SELECT * from employees where employeeId = @id", new { id });

                return singleEmployee;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.Execute(@"UPDATE Employees
                                                       SET FirstName = @FirstName
                                                          ,LastName = @LastName
                                                          ,DepartmentId = @DepartmentId
                                                          ,HireDate = @HireDate
                                                          ,SeparationDate = @SeparationDate
                                                          ,ComputerId = @ComputerId
                                                     WHERE employeeId = @EmployeeId", employee);
                return result == 1;
            }
        }

        public Employee ConvertEmployee(EmployeeEditDto employee, int id)
        {
            var convertedEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DepartmentId = employee.DepartmentId,
                EmployeeId = id,
                HireDate = employee.HireDate,
                SeparationDate = employee.SeparationDate,
                ComputerId = employee.ComputerId
            };

            return convertedEmployee;
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime SeparationDate { get; set; }
        public int ComputerId { get; set; }
    }
}