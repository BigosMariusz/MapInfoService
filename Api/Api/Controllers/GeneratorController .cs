using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using ViewModel;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : Controller
    {
        private readonly IGeneratorService _service;
        public GeneratorController(IGeneratorService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPointsInfo([FromBody] List<VMAddPointsInfo> info)
        {
            await _service.AddPointsInfoAsync(info);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaceIds()
        {
            var idList = await _service.GetPlaceIdsAsync();
            return Ok(idList);
        }
    }
}