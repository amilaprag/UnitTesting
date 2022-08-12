﻿using BaseAPI.Data.Models;
using BaseAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var items = _service.GetAll();
            return Ok(items);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id)
        {
            var item = _service.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var existingItem = _service.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return Ok();
        }
    }
}