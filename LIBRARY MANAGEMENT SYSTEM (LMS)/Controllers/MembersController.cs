using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.DTOs.MemberDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Models;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IGenericRepo<Member> _repo;
        private readonly IMapper _mapper;
        public MembersController(IGenericRepo<Member> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entitydto = _mapper.Map<List<PartiallyUpdateMemberDTO>>(_repo.GetAll());
            return Ok(entitydto);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entitydto = _mapper.Map<PartiallyUpdateMemberDTO>(_repo.GetById(id));
            return Ok(entitydto);
        }

        // POST api/<MembersController>
        [HttpPost]
        public IActionResult CreateMember(CreateUpdateMemberDTO MemberDTO)
        {
            var entitymodel = _mapper.Map<Member>(MemberDTO);
            _repo.Add(entitymodel);
            return CreatedAtAction(nameof(GetById), new { id = entitymodel.MemberId}, entitymodel);
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, CreateUpdateMemberDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            _mapper.Map(entitydto, entitymodel);
            _repo.Update(entitymodel);
            return Ok();
        }

        // PATCH api/<MembersController>/5
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateMember(int id, PartiallyUpdateMemberDTO entitydto)
        {
            var entitymodel = _repo.GetById(id);
            if(entitydto.FullName != null)
            {
                entitymodel.FullName = entitydto.FullName;
            }
            if(entitydto.Email != null)
            {
                entitymodel.Email = entitydto.Email;
            }
            if(entitydto.PhoneNumber != null)
            {
                entitymodel.PhoneNumber = entitydto.PhoneNumber;
            }
            _repo.Update(entitymodel);
            return Ok();
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
