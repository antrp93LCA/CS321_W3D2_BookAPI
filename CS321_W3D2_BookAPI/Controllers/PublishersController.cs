using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D2_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        //Constructor
        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        //GET api/publishers'
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_publisherService.GetPublishers());
        }

        //GET api/publishers/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        //create new publisher
        //POST api/publishers
        [HttpPost]
        public IActionResult Post([FromBody] Publisher newPublisher)
        {
            try
            {
                _publisherService.Add(newPublisher);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("Add Publisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        //PUT api/publishers/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher updatedpublisher)
        {
            var publisher = _publisherService.Update(updatedpublisher);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        //DELETE api/publishers/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);
            return NoContent();
        }
    }
}
