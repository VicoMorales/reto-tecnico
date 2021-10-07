using Dapper;
using Project.ApiProduct._2.Layer_Application.Dtos;
using Project.ApiProduct._3.Layer_Persistence._3._1.Model;
using Project.ApiProduct._3.Layer_Persistence._3._2.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._3.Layer_Persistence._3._2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString;
        public ProductRepository() 
        {
            connectionString = @"Server=DESKTOP-KHQCBJ0\VICOSERVER;Database=project_reto_tecnico;Integrated Security=True;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public async Task<Product> AddProduct(ProductDto product)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductName", product.ProductName);
                    parameters.Add("@Price", product.Price);
                    parameters.Add("@Stock", product.Stock);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<Product>(
                        "dbo.usp_ProductCreate",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return excute.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<bool> DeleteProductAsync(Guid guid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", guid);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<Product>(
                        "dbo.usp_ProductDelete",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<Product>(
                        "dbo.usp_ProductGetAll",
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return excute;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<Product> GetProductById(Guid guid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", guid);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryFirstAsync<Product>(
                        "dbo.usp_ProductGetById",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return excute;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<Product> UpdateProduct(Product product, Guid guid)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", guid);
                    parameters.Add("@ProductName", product.ProductName);
                    parameters.Add("@Price", product.Price);
                    parameters.Add("@Stock", product.Stock);
                    dbConnection.Open();
                    var excute = await dbConnection.QueryAsync<Product>(
                        "dbo.usp_ProductUpdate",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    if (excute != null)
                        return excute.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
