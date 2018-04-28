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

        public bool AddNewEmployee(NewEmployeeDto employee)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var newEmployeeRecord = db.Execute(@"INSERT INTO [dbo].[Employees]
                                                ([FirstName]
                                                ,[LastName]
                                                ,[DepartmentName]
                                                ,[HireDate])
                                            VALUES
                                                (< FirstName, nvarchar(200),>
                                                ,< LastName, nvarchar(200),>
                                                ,< DepartmentId, ,>
                                                ,< HireDate, date,>
                                                ,< SeparationDate, date,>)", employee);

                return newEmployeeRecord == 1;
            }

        }
    }
}