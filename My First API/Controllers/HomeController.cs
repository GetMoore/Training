using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Converters;
using My_First_API.Models;
using My_Firt_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;

namespace My_First_API.Controllers
{
    [Route("Employees")]
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index() 
        {
            return Ok( Json(_employeeService.GetAll()) );
        }

        [HttpPost("Create")]
        public IActionResult CreateEmployee([FromBody] EmployeeModel employee)
        {
            if (employee == null)
                return StatusCode(StatusCodes.Status406NotAcceptable);

            if (_employeeService.Exists(employee.Name, employee.Age, employee.Title))
                return StatusCode(StatusCodes.Status302Found);

            var createdEmployee = _employeeService.Create(employee.Name, employee.Age, employee.Title);

            //Look into using CreatedAtRoute instead
            return Ok(Json(createdEmployee));
        }

        [HttpGet("{Id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(Json(employee));
        }

        [HttpDelete("Delete/{Id}")]
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return _employeeService.Delete(id) ?
                Ok() :
                StatusCode(StatusCodes.Status404NotFound) ;
        }

        [HttpPatch("Update/{Id}")]
        public IActionResult PartialUpdateEmployee(int id, [FromBody] JsonPatchDocument<EmployeeModel> patchDocument)
        {
            var employee = _employeeService.Get(id);
            if (employee == null)
                return StatusCode(StatusCodes.Status404NotFound);

            if (patchDocument == null)
                return BadRequest();

            try
            {
                patchDocument.ApplyTo(employee);
            }
            catch(JsonPatchException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }
    }
}