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
    public class StoreController : BaseController
    {
        private IMapper _mapper;
        private IStoreRepository _storeRepository;
        public StoreController(IMapper mapper, IStoreRepository storeRepository)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var stores = await _storeRepository.FindAll().ToListAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<StoreDTO>>(stores));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindByIdAsync(id, cancellationToken);
            if (store is null) return NotFound("No store found !!");
            return Ok(_mapper.Map<StoreDTO>(store));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoreDTO dto, CancellationToken cancellationToken = default)
        {
            var store = _mapper.Map<Store>(dto);
            _storeRepository.Create(store);
            await _storeRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(Get), new { store.Id }, _mapper.Map<StoreDTO>(store));
        }

        [HttpPut]
        public async Task<IActionResult> Update(StoreDTO dto, CancellationToken cancellationToken = default)
        {
            var store = await _storeRepository.FindByIdAsync(dto.Id, cancellationToken);
            if (store is null) return NotFound();
            _mapper.Map<Store>(store);
            await _storeRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var user = await _storeRepository.FindByIdAsync(id, cancellationToken);
            if (user is null) return NotFound();
            _storeRepository.Delete(user);
            await _storeRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
