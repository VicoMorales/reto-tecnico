using Microsoft.AspNetCore.Mvc;
using Project.ApiProduct._2.Layer_Application;
using Project.ApiProduct._2.Layer_Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._1.Layer_Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            try
            {
                var result = await _productApplication.AddProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un Error");                
            }

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto product)
        {
            try
            {
                var result = await _productApplication.UpdateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un Error");
            }

        }
        [HttpDelete]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            try
            {
                var result = await _productApplication.DeleteProduct(guid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un Error");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productApplication.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un Error");
            }

        }
        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            try
            {
                var result = await _productApplication.GetProductById(guid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un Error");
            }

        }
    }
}
