using AutoMapper;
using Hairo.Entities.Location;
using Hario.Contract;
using Hario.DataObject.LocationDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hairo.API.Controllers
{
    public class DistrictController : BaseController
    {
        private IMapper _mapper;
        private IDistrictRepository _districtiRepository;
        public DistrictController(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtiRepository = districtRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var districts = await _districtiRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<DistrictDTO>>(districts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var disttrict = await _districtiRepository.FindByIdAsync(id, cancellationToken);
            if (disttrict is null) return NotFound("No district found !!");
            return Ok(_mapper.Map<DistrictDTO>(disttrict));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DistrictDTO dto, CancellationToken cancellationToken = default)
        {
            var district = _mapper.Map<District>(dto);
            _districtiRepository.Create(district);
            await _districtiRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { district.Id }, _mapper.Map<DistrictDTO>(district));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DistrictDTO dto, CancellationToken cancellationToken = default)
        {
            var disttrict = await _districtiRepository.FindByIdAsync(dto.Id, cancellationToken);
            if (disttrict is null) return NotFound();
            _mapper.Map<District>(disttrict);
            await _districtiRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var disttrict = await _districtiRepository.FindByIdAsync(id, cancellationToken);
            if (disttrict is null) return NotFound();
            _districtiRepository.Delete(disttrict);
            await _districtiRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
