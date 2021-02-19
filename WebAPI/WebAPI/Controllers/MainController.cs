using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public MainController(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }
        [HttpGet("Incident")]

        public async Task<IEnumerable<Incidents>> GetIncident()
        {
            var result = await _taskRepository.GetIncident();
            return result;
        }
        [HttpGet("Accounts")]

        public async Task<IActionResult> GetAccount(string username)
        {
            var result = await _taskRepository.GetAccount(username);
            if (result.Count() != 0)
            {
                return Ok(result);
            }

            else
               return Ok(Response.StatusCode = 404);
                
        }
        [HttpPut("Accounts")]
        public ActionResult UpdateProduct([FromBody] Accounts account)
        {

            try
            {
                _taskRepository.UpdateAccount(account);
                return new ObjectResult("Update");
            }
            catch (Exception)
            {

                throw new Exception("Not Update");
            }

        }
        [HttpGet("Contact")]

        public async Task<IActionResult> GetContact(string email)
        {
            var result = await _taskRepository.GetContact(email);
            if (result.Count() != 0)
                return Ok(result);
            else
                return Ok(Response.StatusCode = 404);
            
        }
        [HttpPost("Incidents")]
        public ActionResult PostIncident([FromBody] Incidents incident)
        {
            if (incident == null)
            {
                return BadRequest("Not Date");
            }
            var result= _taskRepository.CreateIncident(incident);
            if (result != 0)
            {
                return new ObjectResult("Added Incident");
            }
            else 
            {
                return new ObjectResult("Not Found");
            }
           

        }
        [HttpPost("Contact")]
        public ActionResult PostContact([FromBody] Contacts contact)
        {
            if (contact == null)
            {
                return BadRequest("Not Date");
            }
            _taskRepository.CreateContact(contact);
            return new ObjectResult("Added Contact");
        }
        [HttpPost("Account")]
        public ActionResult PostAccount([FromBody] Accounts account)
        {

            if (account == null)
            {
                return BadRequest("Not Date");
            }
            _taskRepository.CreateAccount(account);
            return new ObjectResult("Added Account");
        }
    }
}
