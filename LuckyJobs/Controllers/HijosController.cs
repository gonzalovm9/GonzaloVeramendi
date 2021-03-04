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
    public class HijosController : ControllerBase
    {
        private readonly IHijosService _hijosService;

        public HijosController(IHijosService hijosService)
        {
            _hijosService = hijosService;
        }

        [HttpGet]
        public IActionResult GetHijo()
        {
            var hijos = _hijosService.GetHijos();
            return Ok(hijos);
        }

        [HttpGet("{id}")]
        public IActionResult GetHijoById(int id)
        {
            var hijo = _hijosService.GetHijoById(id);
            return Ok(hijo);
        }

        [HttpGet]
        [Route("personal/{id}")]
        public IActionResult GetHijoByIdPersonal(int id)
        {
            var hijo = _hijosService.GetHijoByIdPersonal(id);
            return Ok(hijo);
        }

        [HttpPost]
        public IActionResult AddHijo(Hijo hijo)
        {
            bool isHijoAdded = _hijosService.AddHijo(hijo);
            if (isHijoAdded)
            {
                return Ok(hijo);
            }
            else
            {
                return BadRequest(isHijoAdded);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateHijo(int id, Hijo hijo)
        {
            bool isHijoEdited = _hijosService.UpdateHijo(id, hijo);
            if (isHijoEdited)
            {
                return Ok(hijo);
            }
            else
            {
                return BadRequest(isHijoEdited);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHijo(int id)
        {
            bool isHijoDeleted = _hijosService.DeleteHijo(id);
            if (isHijoDeleted)
            {
                return Ok(isHijoDeleted);
            }
            else
            {
                return BadRequest(isHijoDeleted);
            }

        }
    }
}
