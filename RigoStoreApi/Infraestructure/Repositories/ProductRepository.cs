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
    public class ProductRepository : IProductRepository
    {

        private ObjResponse _response;
        private readonly Common.Common _common;
        public ProductRepository(ObjResponse response, Common.Common common) 
        { 
            _common = common;
            _response = response;
        }
        public async Task<ObjResponse> GetProducts()
        {
            try
            {
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
                    _response =await _common.GetGoodResponse();
                    _response.products = products;  
                }

                return _response;
            }
            catch (Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        }
    }
}
