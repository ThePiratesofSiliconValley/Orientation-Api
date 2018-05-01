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
        public IEnumerable<EmployeeTrainingDto> GetSingle(int employeeId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var query =
                    @"select et.EmployeeTrainingId, e.EmployeeId, e.ComputerId, c.ComputerID, t.TrainingId, c.ComputerMake, t.TrainingName, t.StartDay, t.EndDay from EmployeeTraining et
                            join Employees e on e.EmployeeId = et.EmployeeId
                            join TrainingPrograms t on t.TrainingId = et.TrainingId
                            join Computers c on c.ComputerID = e.ComputerId
                            where et.EmployeeId = @employeeId
                            ";
                var listOfEmployeeTraining = db.Query<EmployeeTrainingDto>(query,employeeId);
                
                
                return listOfEmployeeTraining;
            }

           
        }
    }
}