using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using Orientation_API.Models;
using Orientation_API.Controllers;

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

        internal Computer ConvertComputer(ComputerDto computer)
        {
            var result = new Computer
            {
                ComputerManufacturer = computer.ComputerManufacturer,
                ComputerMake = computer.ComputerMake,
                PurchaseDate = computer.PurchaseDate
            };

            return result;
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

        public bool GetSingleComputer(int computerId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.QuerySingleOrDefault("select * from employees where computerId = @computerId", new { computerId });

                return result == null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.Execute("delete from computers where computerId = @id", new { id });

                return result == 1;
            }
        }

        public List<Computer> GetAllUnassigned()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var result = db.Query<Computer>(@"select c.ComputerID, c.ComputerMake, c.ComputerManufacturer from Computers c
                                                  left join Employees e on e.ComputerId = c.ComputerID
                                                  where e.ComputerId is null
                                                  ").ToList();

                return result;
            }
        }
    }

}