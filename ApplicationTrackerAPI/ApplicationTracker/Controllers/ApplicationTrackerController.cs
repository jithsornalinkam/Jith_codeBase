using ApplicationTracker.Contract;
using ApplicationTracker.Models;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace ApplicationTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationTrackerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public ApplicationTrackerController(IRepositoryManager repository)
        {
              _repository = repository;
        }

       
        [HttpGet]
        [Route("applications")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetApplications()
        {
            var applications = _repository.TrackeRepository.GetAllApplications();
            return Ok(applications);
        }


        [HttpGet]
        [Route("applications/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetApplications(int id)
        {
            var application = _repository.TrackeRepository.FindApplicationById(id);
            return Ok(application);
        }


   

        [HttpPost("applications")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult SaveApplications([FromBody] Object input)
        {
           
            var data = JsonConvert.DeserializeObject<Application>(input.ToString());

             _repository.TrackeRepository.CreateApplication(data);
             _repository.Save();
            return Created(); 
        }

    }
}
