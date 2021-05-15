using System;
using System.Threading.Tasks;
using DataFiller.Service;
using Microsoft.AspNetCore.Mvc;

namespace Holdings.External.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillerController : ControllerBase
    {
        private readonly IDataFillerService _dataFiller;
        public FillerController(IDataFillerService dataFiller)
        {
            _dataFiller = dataFiller;
        }

        [HttpGet]
        public async Task<IActionResult> FillData()
        {
            try
            {
                return Ok(await _dataFiller.FillData());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("fill-dates")]
        public async Task<IActionResult> FillDates()
        {
            try
            {
                return Ok(await _dataFiller.FillDates());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
