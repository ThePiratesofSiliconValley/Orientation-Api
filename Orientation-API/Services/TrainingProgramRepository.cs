using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Orientation_API.Controllers;
using Orientation_API.Models;

namespace Orientation_API.Services
{
    public class TrainingProgramRepository
    {
        public bool CreateTraining(TrainingProgramDto training)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var createTraining = db.Execute(@"INSERT INTO [dbo].[TrainingPrograms]
                                           ([TrainingName]
                                           ,[StartDay]
                                           ,[EndDay]
                                           ,[MaxAttendees]
                                           ,[Details])
                                     VALUES
                                           (@TrainingName
                                           ,@StartDay
                                           ,@EndDay
                                           ,@MaxAttendees
                                           ,@Details)", training);
                return createTraining == 1;
            }
        }

        public IEnumerable<TrainingProgramDto> GetAllTrainings()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();
                var trainings = db.Query<TrainingProgramDto>("select * from TrainingPrograms where StartDay >= GETDATE()");
                return trainings;
            }
        }

        public TrainingProgramDto GetSingleTrainingProgram(int trainingId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();
                var singleTrainingProgram = db.QueryFirstOrDefault<TrainingProgramDto>(@"SELECT * 
                                                                                         FROM TrainingPrograms 
                                                                                         WHERE TrainingId = @trainingId", new { trainingId });

                return singleTrainingProgram;
            }
        }
    }
}