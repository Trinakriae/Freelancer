using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Freelancer.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<ProjectController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        // Post api/invoice/user/{idUser}/allocatedtimes
        [HttpPost("user/{idUser}/allocatedtimes")]
        public ActionResult PostAllocatedTimesToInvoice([FromRoute] int idUser, [FromBody] List<int> allocatedTimes)
        {
            try
            {
                if (allocatedTimes == null || allocatedTimes.Count() == 0)
                {
                    return BadRequest("The list of allocated times cannot be empty");
                }

                List<int> invoiceIdList = _invoiceService.CreateInvoices(idUser, allocatedTimes);

                return Ok(new { invoiceIdList });
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}