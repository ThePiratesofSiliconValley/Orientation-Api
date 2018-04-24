using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace Orientation_API.Services
{
    public class ComputerRespository
    {
        public List<Computer> GetAllComputers()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.Query<Computer>("select * from Computers").ToList();

                return result;
            }
        }
    }

    public class Computer
    {
        public int ComputerId { get; set; }
        public string ComputerManufacturer { get; set; }
        public string ComputerMake { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}