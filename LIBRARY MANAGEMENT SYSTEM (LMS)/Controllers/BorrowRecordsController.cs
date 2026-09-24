using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.BorrowRecordDTOS;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordsController : ControllerBase
    {
        private readonly IGenericRepo<BorrowRecord> _repo;
        private readonly IMapper _mapper;
        public BorrowRecordsController(IGenericRepo<BorrowRecord> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/<BorrowRecordsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitydto = _mapper.Map<List<PartiallyUpdateBorrowRecordDTO>>(_repo.GetAll());
            return Ok(entitydto);
        }

        // GET api/<BorrowRecordsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitydto = _mapper.Map<PartiallyUpdateBorrowRecordDTO>(_repo.GetById(id));
            return Ok(entitydto);
        }

        // POST api/<BorrowRecordsController>
        [HttpPost]
        public IActionResult CreateBorrowRecord(CreateUpdateBorrowRecordDTO BorrowRecordDTO)
        {
            var entitymodel = _mapper.Map<BorrowRecord>(BorrowRecordDTO);
            _repo.Add(entitymodel);
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.BorrowRecordId}, entitymodel);
        }

        // PUT api/<BorrowRecordsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBorrowRecord(int id, CreateUpdateBorrowRecordDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            _mapper.Map(entitydto, entitymodel);
            _repo.Update(entitymodel);
            return Ok();
        }

        // PATCH api/<BorrowRecordsController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateBorrowRecord(int id, PartiallyUpdateBorrowRecordDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            if(entitydto.BorrowDate.HasValue)
            {
                entitymodel.BorrowDate = entitydto.BorrowDate.Value;
            }
            if(entitydto.ReturnDate.HasValue)
            {
                entitymodel.ReturnDate = entitydto.ReturnDate.Value;
            }
            _repo.Update(entitymodel);
            return Ok();
        }

        // DELETE api/<BorrowRecordsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
