using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BookDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepo<Book> _repo;
        private readonly IMapper _mapper;
        public BooksController(IGenericRepo<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitydto = _mapper.Map<List<PartiallyUpdateBookDTO>>(_repo.GetAll());
            return Ok(entitydto);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitydto = _mapper.Map<PartiallyUpdateBookDTO>(_repo.GetById(id));
            return Ok(entitydto);
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult CreateBook(CreateUpdateBookDTO bookDTO)
        {
            var entitymodel = _mapper.Map<Book>(bookDTO);
            _repo.Add(entitymodel);
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.BookId}, entitymodel);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, CreateUpdateBookDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            _mapper.Map(entitydto, entitymodel);
            _repo.Update(entitymodel);
            return Ok();
        }

        // PATCH api/<BooksController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateBook(int id, PartiallyUpdateBookDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            if(entitydto.Title != null)
            {
                entitymodel.Title = entitydto.Title;
            }
            if(entitydto.Author != null)
            {
                entitymodel.Author = entitydto.Author;
            }
            if(entitydto.AvailableCopies.HasValue)
            {
                entitymodel.AvailableCopies = entitydto.AvailableCopies.Value;
            }
            if(entitydto.PublishedYear.HasValue)
            {
                entitymodel.PublishedYear = entitydto.PublishedYear.Value;
            }
            if(entitydto.Price.HasValue)
            {
                entitymodel.Price = entitydto.Price.Value;
            }
            _repo.Update(entitymodel);
            return Ok();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
