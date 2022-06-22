using ETicaretAPI.Application.Pagination;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModel.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IReadProductRepository _readProductRepository;
        private readonly IWriteProductRepository _writeProductRepository;
        public ProductsController(IReadProductRepository readProductRepository, IWriteProductRepository writeProductRepository)
        {
            _readProductRepository = readProductRepository;
            _writeProductRepository = writeProductRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination  pagination)
        {
            var totalCount = _readProductRepository.GetAll(tracking:false).Count();
            var product = _readProductRepository.GetAll(tracking: false).Skip(pagination.size * pagination.page).Take(pagination.size);
            return Ok(new
            {
                product,
                totalCount
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_readProductRepository.GetByIDAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_CreateProducts model)
        {
            if (ModelState.IsValid)
            {

                await _writeProductRepository.AddAsync(new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Stock = model.Stock,
                });
                await _writeProductRepository.SaveAsync();
                return Ok();
            }

            return Ok();
         
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_CreateProducts model)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _writeProductRepository.RemoveAsync(id);
            await _writeProductRepository.SaveAsync();
            return Ok();
        }
    }
}
