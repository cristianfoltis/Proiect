using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeviceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetDevices()
        {
            try
            {
                var devices = await _unitOfWork.Devices.GetAll(includes: new List<string> { "User" });
                var results = _mapper.Map<IList<DeviceDTO>>(devices);
                return Ok(results);
            }
            catch (Exception ex)
            {

                return BadRequest("internal server error.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            try
            {
                var device = await _unitOfWork.Devices.Get(q => q.DeviceId == id, new List<string> { "User" });
                var result = _mapper.Map<DeviceDTO>(device);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error.");
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> PostDevice([FromBody] DeviceDTO deviceDTO)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var device = _mapper.Map<Device>(deviceDTO);
            device.User = null; 
           
            await _unitOfWork.Devices.Insert(device);
            await _unitOfWork.Save();


            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateDevice(int id, [FromBody] DeviceDTO deviceDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {

                return BadRequest(ModelState);
            }


            var device = await _unitOfWork.Devices.Get(q => q.DeviceId == id);
            if (device == null)
            {
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(deviceDTO, device);
            device.User = await _unitOfWork.Users.Get(q => q.UserId == deviceDTO.UserId, new List<string> { });
            _unitOfWork.Devices.Update(device);
            await _unitOfWork.Save();

            return NoContent();

        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteDevice(int id)
        {
            if (id < 1)
            {

                return BadRequest();
            }

            var device = await _unitOfWork.Devices.Get(q => q.DeviceId == id);
            if (device == null)
            {

                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Devices.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

    }
}
