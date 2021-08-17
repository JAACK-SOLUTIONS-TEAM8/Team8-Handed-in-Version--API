﻿using Louman.Models.DTOs.Employee;
using Louman.Repositories.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Louman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpPost("Upsert")]
        public async Task<IActionResult> Add([FromBody] EmployeeDto employee)
        {
            var emp = await _employeeRepository.Add(employee);
            if (emp != null)
                return Ok(new { Employee = emp, statusCode = StatusCodes.Status200OK });
            return Ok(new { Employee = emp, statusCode = StatusCodes.Status400BadRequest });
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _employeeRepository.DeleteAsync(id);
            if (isDeleted != false)
                return Ok(new { Employee = isDeleted, StatusCode = StatusCodes.Status200OK });
            return Ok(new { Employee = isDeleted, StatusCode = StatusCodes.Status400BadRequest });
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            if (employees != null)
                return Ok(new { Employees = employees, StatusCode = StatusCodes.Status200OK });
            return Ok(new { Employees = employees, StatusCode = StatusCodes.Status404NotFound });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
                return Ok(new { employee = employee, statusCode = StatusCodes.Status200OK });
            return Ok(new { employee = employee, statusCode = StatusCodes.Status400BadRequest });
        }

        [HttpGet("emp")]
        public async Task<IActionResult> GetById([FromQuery] string name)
        {
            var emp = await _employeeRepository.SearchByNameAsync(name);
            if (emp != null)
                return Ok(new { clients = emp, statusCode = StatusCodes.Status200OK });
            return Ok(new { clients = emp, statusCode = StatusCodes.Status400BadRequest });
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var reponse = await _employeeRepository.SearchByNameAsync(name);
            if (reponse != null)
                return Ok(new { Employees = reponse, StatusCode = StatusCodes.Status200OK });
            else
                return Ok(new { Employees = reponse, StatusCode = StatusCodes.Status400BadRequest });

        }
        [HttpGet("EmployeeMonthlyAttendanceHistory")]
        public async Task<IActionResult> GetEmployeeMonthlyAttendanceHistory([FromQuery] string dateInfo)
        {
            var history = await _employeeRepository.GetEmployeeMonthlyAttendanceReport(dateInfo);
            if (history != null)
                return Ok(new { History = history, StatusCode = StatusCodes.Status200OK });
            else
                return Ok(new { History = history, StatusCode = StatusCodes.Status400BadRequest });

        }
    }
}