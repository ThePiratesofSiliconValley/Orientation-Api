using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Orientation_API.Models;
using Orientation_API.Services;

namespace Orientation_API.Controllers
{
    [RoutePrefix("api/trainings")]
    public class TrainingProgramsController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            var trainingProgramRepository = new TrainingProgramRepository();
            var allTrainings = trainingProgramRepository.GetAllTrainings();
            return Request.CreateResponse(HttpStatusCode.OK, allTrainings);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage CreateTraining(TrainingProgramDto training)
        {
            var repository = new TrainingProgramRepository();
            var result = repository.CreateTraining(training);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Training has been created");
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Training didn't save, try again");
        }

        [HttpGet, Route("{trainingId}")]
        public HttpResponseMessage GetSingle(int trainingId)
        {
            var trainingProgramRepository = new TrainingProgramRepository();
            var singleTrainingProgram = trainingProgramRepository.GetSingleTrainingProgram(trainingId);
            return Request.CreateResponse(HttpStatusCode.OK, singleTrainingProgram);
        }

        [HttpPut, Route("{trainingId}")]
        public HttpResponseMessage Edit(int trainingId, TrainingProgramDto training)
        {
            var trainingProgramModifier = new TrainingProgramModifier();
            var editTrainingProgram = trainingProgramModifier.Update(trainingId, training);

            return Request.CreateResponse(HttpStatusCode.OK, editTrainingProgram);
        }
    }
}