using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace calculatorService.Controllers
{
    [ProducesResponseType(StatusCodes.Status200OK)]

    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {

        ICalculator calculator;
        string userId;
        public CalcController(ICalculator _calculator, IHttpContextAccessor httpContextAccessor)
        {
            calculator = _calculator;
          
        }


        // return the list of operation
        [HttpGet("GetOperation")]
        public IActionResult GetOperation() 
        {
            return Ok(calculator.Operators.Select(x => x.Name));
        }

         //get calculation and return th result
        [HttpPost("CalcResult")]
        public IActionResult Post (Calculation data)
        {
         
            return Ok(calculator.calculate(data, getUserID()));
        }

        // return the addressIP of the user

        public string getUserID()
        {
            var ip = HttpContext.Connection.RemoteIpAddress;
            userId = (Dns.GetHostEntry(ip).HostName);
            return userId;
        }

    }
}
