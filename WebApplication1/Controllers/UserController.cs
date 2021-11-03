using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll();
                var results = _mapper.Map<IList<UserDTO>>(users);
                return Ok(results);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "internal server error.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(q => q.UserId == id, new List<string> { "Devices" });
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDTO UserDTO)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(UserDTO);
            await _unitOfWork.Users.Insert(user);
            await _unitOfWork.Save();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO UserDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {

                return BadRequest(ModelState);
            }


            var user = await _unitOfWork.Users.Get(q => q.UserId == id);
            if (user == null)
            {

                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(UserDTO, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();

            return NoContent();

        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id < 1)
            {
             
                return BadRequest();
            }

            var hotel = await _unitOfWork.Users.Get(q => q.UserId == id);
            if (hotel == null)
            {
              
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }


    }
}
