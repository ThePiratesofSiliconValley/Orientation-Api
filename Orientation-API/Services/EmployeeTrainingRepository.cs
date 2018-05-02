using Dapper;
using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Orientation_API.Services
{
    public class EmployeeTrainingRepository
    {
        public EmployeeTrainingDto GetSingle(int employeeId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var query =
                    @"select  
                        e.FirstName,
                        e.LastName,
                        e.EmployeeId, 
                        d.DepartmentName,
                        c.ComputerMake

                        from Employees e
		
                                join Departments d on d.DepartmentId = e.DepartmentId
                                join Computers c on c.ComputerID = e.ComputerId
                                where e.EmployeeId = @employeeId

                        select 
                        t.TrainingName
	
                        from EmployeeTraining et
	                        join TrainingPrograms t on t.TrainingId = et.TrainingId		
	                        where et.EmployeeId = @employeeId";

                var employee = new EmployeeTrainingDto();
                using (var multi = db.QueryMultiple(query, new {employeeId}))
                {
                    employee = multi.Read<EmployeeTrainingDto>().First();
                    employee.TrainingName = multi.Read<string>().ToList();
                }
              
                
                return employee;
            }

           
        }
    }
}