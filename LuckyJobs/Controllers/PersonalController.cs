using Business.Services;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyJobs.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;
        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet]
        public IActionResult GetPersonal()
        {
            var personal = _personalService.GetPersonal();
            return Ok(personal);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonalById(int id)
        {
            var personal = _personalService.GetPersonalById(id);
            return Ok(personal);
        }

        [HttpPost]
        public IActionResult AddPersonal(Personal personal)
        {
            bool isPersonalAdded = _personalService.AddPersonal(personal);
            if (isPersonalAdded)
            {
                return Ok(personal);
            }
            else
            {
                return BadRequest(isPersonalAdded);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePersonal(int id, Personal personal)
        {
            bool isPersonalEdited = _personalService.UpdatePersonal(id, personal);
            if (isPersonalEdited)
            {
                return Ok(personal);
            }
            else
            {
                return BadRequest(isPersonalEdited);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeletePersonal(int id)
        {
            bool isPersonalDeleted = _personalService.DeletePersonal(id);
            if (isPersonalDeleted)
            {
                return Ok(isPersonalDeleted);
            }
            else
            {
                return BadRequest(isPersonalDeleted);
            }

        }
    }
}
