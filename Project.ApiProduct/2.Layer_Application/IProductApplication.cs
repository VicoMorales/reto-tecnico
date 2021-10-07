using Project.ApiProduct._2.Layer_Application.Dtos;
using Project.ApiProduct._3.Layer_Persistence._3._1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._2.Layer_Application
{
    public interface IProductApplication
    {
        Task<ProductDto> AddProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(Guid guid);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(Guid guid);
    }
}
