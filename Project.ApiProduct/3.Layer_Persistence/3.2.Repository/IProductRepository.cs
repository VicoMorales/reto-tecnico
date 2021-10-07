using Project.ApiProduct._2.Layer_Application.Dtos;
using Project.ApiProduct._3.Layer_Persistence._3._1.Model;
using Project.ApiProduct._3.Layer_Persistence._3._2.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._3.Layer_Persistence._3._2.Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(ProductDto product);
        Task<Product> UpdateProduct(Product product,Guid guid);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductById(Guid guid);
        Task<bool> DeleteProductAsync(Guid guid);

    }
}
