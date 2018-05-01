using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Orientation_API.Services
{
    public class EmployeeModifier
    {
        public StatusCode EditEmployee(Employee employee)
        {
            var repo = new EmployeeRepository();
            Employee getEmployee;

            try
            {
                getEmployee = repo.GetSingleEmployee(employee.EmployeeId);
            }
            catch (SqlException)
            {
                return StatusCode.Unsuccessful;
            }
            catch (Exception)
            {
                return StatusCode.NotFound;
            }

            
            var updateEmployee = repo.UpdateEmployee(employee);

            return updateEmployee
                ? StatusCode.Success
                : StatusCode.Unsuccessful;
        }
    }
}