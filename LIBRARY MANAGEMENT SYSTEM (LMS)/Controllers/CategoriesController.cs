using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOS;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepo<Category> _repo;
        private readonly IMapper _mapper;
        public CategoriesController(IGenericRepo<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitydto = _mapper.Map<List<PartiallyUpdateCategoryDTO>>(_repo.GetAll());
            return Ok(entitydto);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitydto = _mapper.Map<PartiallyUpdateCategoryDTO>(_repo.GetById(id));
            return Ok(entitydto);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult CreateCategory(CreateUpdateCategoryDTO CategoryDTO)
        {
            var entitymodel = _mapper.Map<Category>(CategoryDTO);
            _repo.Add(entitymodel);
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.CategoryId}, entitymodel);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CreateUpdateCategoryDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            _mapper.Map(entitydto, entitymodel);
            _repo.Update(entitymodel);
            return Ok();
        }

        // PATCH api/<CategoriesController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCategory(int id, PartiallyUpdateCategoryDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            if(entitydto.Name != null)
            {
                entitymodel.Name = entitydto.Name;
            }
            _repo.Update(entitymodel);
            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
