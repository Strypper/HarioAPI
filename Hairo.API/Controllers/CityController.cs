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
    public class CityController : BaseController
    {
        private IMapper _mapper;
        private ICityRepository _cityRepository;
        public CityController(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var cities = await _cityRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<CityDTO>>(cities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var service = await _cityRepository.FindByIdAsync(id, cancellationToken);
            if (service is null) return NotFound("No city found !!");
            return Ok(_mapper.Map<CityDTO>(service));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityDTO dto, CancellationToken cancellationToken = default)
        {
            var city = _mapper.Map<City>(dto);
            _cityRepository.Create(city);
            await _cityRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { city.Id }, _mapper.Map<CityDTO>(city));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CityDTO dto, CancellationToken cancellationToken = default)
        {
            var city = await _cityRepository.FindByIdAsync(dto.Id, cancellationToken);
            if (city is null) return NotFound();
            _mapper.Map<City>(city);
            await _cityRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var city = await _cityRepository.FindByIdAsync(id, cancellationToken);
            if (city is null) return NotFound();
            _cityRepository.Delete(city);
            await _cityRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
