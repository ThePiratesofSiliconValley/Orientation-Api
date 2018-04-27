using Orientation_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Orientation_API.Services
{
    public class ComputerModifier
    {
        public StatusCode DeleteComputer(int id)
        {
            var repo = new ComputerRespository();
            bool employeeCheck;

            try
            {
                employeeCheck = repo.GetSingleComputer(id);
            }
            catch (SqlException)
            {
                return StatusCode.Unsuccessful;
            }
            catch (Exception)
            {
                return StatusCode.NotFound;
            }

            var deleteComputer = repo.Delete(id);

            return deleteComputer
                   ? StatusCode.Success
                   : StatusCode.Unsuccessful;
            
        }
    }
}