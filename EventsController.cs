using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EventManagement.DataLayer;
using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        // GET: /<controller>/
        private readonly ILogger<EventsController> _logger;
        private readonly IMongoHelper _mongo;
        private readonly IConfiguration _config;
        
        public EventsController(ILogger<EventsController> logger,IMongoHelper mongo, IConfiguration config)
        {
            _logger = logger;
            _mongo = mongo;
            _config = config;
            
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            
            return await _mongo.GetAllDocuments<Event>("Events");
        }

        [HttpPost]
        public async Task IActionResult<Event> Create()
        {
            // var doc = new Event { };   
            var result = await _mongo.CreateDocument<Event>("Events", new Event { EventId = 3, Name = "Developer Day" });
            return Created(" ",result);

        }

    }
}


