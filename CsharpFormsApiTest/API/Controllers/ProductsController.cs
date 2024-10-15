using API.Application.Dto;
using API.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Search([FromBody] ProductSearch searchDto)
        {
            return Ok(_unitOfWork.ProductRepository.SearchWithPagination(searchDto));
        }
        [HttpPost]
        public IActionResult Post([FromBody] ProductInsertData data)
        {
            _unitOfWork.ProductRepository.InsertNewProduct(data);
            _unitOfWork.Save();
            return StatusCode(201);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            _unitOfWork.ProductRepository.Remove(id);
            _unitOfWork.Save();
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update([FromBody] ProductUpdateData data)
        {
            _unitOfWork.ProductRepository.UpdateProduct(data);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
