using AutoMapper;
using ListingApi.Data;
using ListingApi.Data.Dto;
using ListingApi.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDto>>(hotels);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpGet("{id:int}", Name= "GetHotel")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDto>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDto hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDTO);
                await _unitOfWork.Hotels.Insert(hotel);
                await _unitOfWork.Save();
                
                return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDto hotelDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
                if (hotel == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(hotelDTO, hotel);
                _unitOfWork.Hotels.Update(hotel);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize]
        [HttpDelete("{id:int}")]
         public async Task<IActionResult> DeleteHotel(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
                if (hotel == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Hotels.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

    }
}
