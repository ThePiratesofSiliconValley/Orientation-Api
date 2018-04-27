using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Orientation_API.Models;

namespace Orientation_API.Services
{
    public class DepartmentsRepository
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
        }

        public IEnumerable<DepartmentsDto> GetAll()
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var departments = db.Query<DepartmentsDto>("select * from Departments");

                return departments;
            }
        }

        public bool CreateDepartment(DepartmentsDto department)
        {
            using (var db = CreateConnection())
            {
                db.Open();

                var createDepartment = db.Execute(@"INSERT INTO [dbo].[Departments]
                                                       ([DepartmentName])
                                                 VALUES
                                                       (@DepartmentName)", department);

                return createDepartment == 1;
            }
        }
    }
}