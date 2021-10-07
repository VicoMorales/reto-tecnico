using AutoMapper;
using Project.ApiProduct._2.Layer_Application.Dtos;
using Project.ApiProduct._3.Layer_Persistence._3._1.Model;
using Project.ApiProduct._3.Layer_Persistence._3._2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._2.Layer_Application
{
    public class ProductApplication: IProductApplication
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository,
             IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProduct(ProductDto product)
        {
            var result = await _productRepository.AddProduct(product);
            return result == null ? null : _mapper.Map<ProductDto>(result);
        }

        public async Task<bool> DeleteProduct(Guid guid)
        {
            return await _productRepository.DeleteProductAsync(guid);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = await _productRepository.UpdateProduct(entity, product.Id);
            return result == null ? null : _mapper.Map<ProductDto>(result);
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductById(Guid guid)
        {
            return await _productRepository.GetProductById(guid);
        }
    }
}
