using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlaceOfBirth;
using api.Interfaces;
using api.Mapper;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/placeofbirth")]
    [ApiController]
    public class PlaceOfBirthController : ControllerBase
    {
        private readonly IPlaceOgBirthRepository _placebirth;

        public PlaceOfBirthController(IPlaceOgBirthRepository placebirth)
        {
            _placebirth = placebirth;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var placeOfBirths = await _placebirth.GetAllAsync();

            var placeOfBirthDto = placeOfBirths.Select(s => s.ToPlaceOfBirthDto());

            return Ok(placeOfBirthDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var place = await _placebirth.GetByIdAsync(id);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place.ToPlaceOfBirthDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlaceOfBirthRequestDto placeDto)
        {

            var placeModel = placeDto.ToPlaceOfBirthFromCreateDto();

            if (await _placebirth.PlaceOfBirthExist(placeModel.UserDataId) == true)
            {
                return BadRequest("Place Of Birth to this user is already exist");
            }

            await _placebirth.CreateAsync(placeModel);
            return CreatedAtAction(nameof(GetById), new { id = placeModel.Id }, placeModel.ToPlaceOfBirthDto());
        }

        [HttpPut]
        [Route("{userDataId}")]
        public async Task<IActionResult> Update([FromRoute] int userDataId, [FromBody] UpdatePlaceOfBirthRequestDto updateDto)
        {
            var placeModel = await _placebirth.UpdateAsync(userDataId, updateDto);

            if (placeModel == null)
            {
                return NotFound("Place Of Birth not found");
            }

            return Ok(placeModel.ToPlaceOfBirthDto());

        }
    }
}