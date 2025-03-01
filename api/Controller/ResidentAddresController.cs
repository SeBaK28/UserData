using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ResidentialAddres;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/residentialaddress")]
    [ApiController]
    public class ResidentAddresController : ControllerBase
    {
        private readonly IResidentialAddresRepository _residentAddress;

        public ResidentAddresController(IResidentialAddresRepository residentAddress)
        {
            _residentAddress = residentAddress;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resident = await _residentAddress.GetAllAsync();
            var residentDto = resident.Select(s => s.ToAddresStockDto());
            return Ok(residentDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAddres([FromRoute] int id, [FromBody] UpdateResidentialAddresRequestDto adressDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addresModel = await _residentAddress.UpdateAddresAsync(id, adressDto);

            if (addresModel == null)
            {
                return NotFound("Resident Address not found");
            }

            return Ok(addresModel.ToAddresStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRessidentAddressRequestDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addresModel = createDto.ToAddresStockFromCreateDto();

            if (await _residentAddress.ResidentialAddresExist(addresModel.UserDataId) == true)
            {
                return BadRequest("Resident Addres to this user is already exist");
            }

            await _residentAddress.CreateAddressAsync(addresModel);
            return CreatedAtAction(nameof(_residentAddress.GetByIdAsync), new { id = addresModel.Id }, addresModel.ToAddresStockDto());
        }
    }
}