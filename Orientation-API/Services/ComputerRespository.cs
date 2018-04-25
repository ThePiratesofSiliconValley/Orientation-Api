using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using Orientation_API.Models;

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

        public List<ComputerOutputDto> ComputerReturn(List<Computer> results)
        {
            var computersDto = new List<ComputerOutputDto>();

            foreach (var result in results)
            {
                var computerDto = new ComputerOutputDto
                {
                    ComputerId = result.ComputerId,
                    ComputerManufacturer = result.ComputerManufacturer,
                    ComputerMake = result.ComputerMake,
                    PurchaseDate = result.PurchaseDate
                };

                computersDto.Add(computerDto);
            }

            return computersDto;
        }

        public bool AddNewComputer(Computer computer)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.Execute(@"INSERT INTO Computers
                                                       (ComputerManufacturer
                                                       ,ComputerMake
                                                       ,PurchaseDate)
                                                 VALUES
                                                       (@ComputerManufacturer
                                                       ,@ComputerMake
                                                       ,@PurchaseDate)", computer);
                return result == 1;
            }
        }
    }

}