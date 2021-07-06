using BLL;
using BLL.Models;
using DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ListCalcController : Controller
    {
        IListCalc listCalc;
        string userId;

        public ListCalcController(IListCalc _listCalc)
        {
            listCalc = _listCalc;
          

        }     
        // get the Calculation History by userID

        [HttpGet("getCalculatorHistory")]
        public IActionResult getCalculatorHistory()
        {
           
            return Ok(listCalc.GetHistoryCalculation(getUserID()));
        }


        // send to delete calculation history
        [HttpPost("deleteCalculation")]

        public IActionResult deleteCalculation(Calculation data)
        {
            return Ok(listCalc.DeleteCalculation(getUserID(), data));
        }
        [HttpPost("updateCalculation")]

        public IActionResult updateCalculation(Calculation selectCalc)
        {
            return Ok(listCalc.UpdateCalculation(getUserID(), selectCalc));
        }
       // return the addressIP of the user
     public string   getUserID()
        {
            var ip = HttpContext.Connection.RemoteIpAddress;
            userId = (Dns.GetHostEntry(ip).HostName);
            return userId;
        }

    }
}
