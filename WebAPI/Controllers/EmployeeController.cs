using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contract.Response;
using WebAPI.Models;
using WebAPI.Repository;
using WebAPI.Repository.Contract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee employeeservice;

        public EmployeeController(IEmployee employeeservice)
        {
            this.employeeservice = employeeservice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var emps = employeeservice.GetEmployees();
                var response = new ApiResponse();
                if (emps.Count == 0)
                {
                    response.data = emps;
                    response.error = "employees not found";
                    response.status = 404;
                    response.message = "Employee record not available";

                    return NotFound(response);
                }
                else
                {
                    response.data = emps;
                    response.status = 200;
                    response.message = "Employee record found";

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        [Route("getemployeebyid/{id}")]
        public IActionResult Get(int id)
        {
            try
            {


                var emps = employeeservice.GetEmployeeById(id);
                var response = new ApiResponse();
                if (emps == null)
                {
                    response.data = emps;
                    response.status = 404;
                    response.message = $"Employee record with {id} not found";
                    response.error = "Invalid employee id";
                    return NotFound(response);
                }
                else
                {
                    response.data = emps;
                    response.status = 200;
                    response.message = $"Employee record with {id} found";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public IActionResult Post(Employees employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                else
                {
                    var result = employeeservice.CreateEmployee(employee);
                    return Created("Get", result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    var result = employeeservice.DeleteEmployee(id);
                    if (result)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Update(Employees emp)
        {
            try
           { 
            if (emp == null)
            {
                return BadRequest();
            }
            else
            {
                var result = employeeservice.UpdateEmployee(emp);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
           }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        
        

            

    }

}
