using AutoMapper;
using Hairo.Entities;
using Hario.Contract;
using Hario.DataObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hairo.API.Controllers
{
    public class ServiceController : BaseController
    {
        private IMapper _mapper;
        private IServiceRepository _serviceRepository;
        public ServiceController(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var services = await _serviceRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<ServiceDTO>>(services));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var service = await _serviceRepository.FindByIdAsync(id, cancellationToken);
            if (service is null) return NotFound("No service found !!");
            return Ok(_mapper.Map<ServiceDTO>(service));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceDTO dto, CancellationToken cancellationToken = default)
        {
            var service = _mapper.Map<Service>(dto);
            _serviceRepository.Create(service);
            await _serviceRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { service.Id }, _mapper.Map<ServiceDTO>(service));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServiceDTO dto, CancellationToken cancellationToken = default)
        {
            var service = await _serviceRepository.FindByIdAsync(dto.Id, cancellationToken);
            if (service is null) return NotFound();
            _mapper.Map<Service>(service);
            await _serviceRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var service = await _serviceRepository.FindByIdAsync(id, cancellationToken);
            if (service is null) return NotFound();
            _serviceRepository.Delete(service);
            await _serviceRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
