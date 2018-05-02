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
    public class TrainingProgramModifier
    {
        public bool Update(int trainingId, TrainingProgramDto training)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var updateTraining = db.Execute(@"UPDATE TrainingPrograms
                                                     SET TrainingName = @TrainingName,
                                                         StartDay = @StartDay,
                                                         EndDay = @EndDay,
                                                         MaxAttendees = @MaxAttendees,
                                                         Details = @Details
                                                     WHERE trainingId = @trainingId", new
                                                {
                                                    training.TrainingName,
                                                    training.StartDay,
                                                    training.EndDay,
                                                    training.MaxAttendees,
                                                    training.Details,
                                                    trainingId
                                                });

                return updateTraining == 1;
            }
        }

        public bool Delete(int trainingId)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            {
                db.Open();

                var deleteTraining = db.Execute(@"DELETE FROM TrainingPrograms
                                                    WHERE TrainingId = @trainingId", new { trainingId });

                return deleteTraining == 1;
            }
        }
    }
}