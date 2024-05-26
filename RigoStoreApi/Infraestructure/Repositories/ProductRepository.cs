using Domain.Entities;
using Domain.Interfaces.Repositories;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {

        
        private readonly Common.Common _common;
        public ProductRepository(ObjResponse response, Common.Common common) 
        { 
            _common = common;
        }
        public async Task<ObjResponse> GetProducts()
        {
            try
            {
                ObjResponse response = null;
                var command = new SqlCommand("get_products", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader =await command.ExecuteReaderAsync();
                if (reader.HasRows) 
                { 
                    List<Product> products = new List<Product>();   
                    while(await reader.ReadAsync()) 
                    {
                        products.Add(new Product() { 
                         Id =(int)reader.GetInt32("id"),
                         Reference = reader.GetString("reference"),
                         Name = reader.GetString("name"),
                         Price =reader.GetDecimal("price")
                        
                        });
                    }
                    response =await _common.GetGoodResponse();
                    response.products = products;  
                }

                return response;
            }
            catch (Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        }

        public async Task<ObjResponse> GetProduct(int id)
        {
            try
            {
                ObjResponse response = null;
                var command = new SqlCommand("get_product", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", DbType.Int32) { Value = id });
                SqlDataReader reader = await command.ExecuteReaderAsync();
                    
                if (reader.HasRows) 
                {
                    Product product = new Product();
                    while (await reader.ReadAsync()) 
                    { 
                        product.Id=id;
                        product.Name = reader.GetString("name");
                        product.Price = reader.GetDecimal("price");
                    }
                
                   response=await _common.GetGoodResponse();
                   response.product = product;

                  return response;
                }

               return await _common.GetGoodResponse();
            }
            catch (Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        }

        public async Task<ObjResponse> Create(Product entity)
        {
            try
            {

                ObjResponse response = null;
                var command = new SqlCommand("create_product", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@price", DbType.Decimal) { Value = entity.Price });
                command.Parameters.Add(new SqlParameter("@reference", DbType.String) { Value = entity.Reference });
                command.Parameters.Add(new SqlParameter("@name", DbType.String) { Value = entity.Name });
                

                var res = await command.ExecuteNonQueryAsync();
                if (res < 0)
                {
                    response = await _common.GetGoodResponse();
                    response.Message = "Product created";
                    return response;
                }
                return await _common.GetBadResponse();
            }
            catch (Exception e)
            {
                return await _common.GetBadResponse();
            }
        }
    }
}
