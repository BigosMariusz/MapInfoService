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
    public class MapController : Controller
    {
        private readonly IMapService _service;
        public MapController(IMapService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult GetInfo()
        {
            var points = _service.GetInfoSync();
            return Ok(points);
        }

        [HttpGet("GetPlaces")]
        public async Task<IActionResult> GetPlaces()
        {
            var places = await _service.GetPlacesAsync();
            return Ok(places);
        }
    }
}