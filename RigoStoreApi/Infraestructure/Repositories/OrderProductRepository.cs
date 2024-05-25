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
    public class OrderProductRepository : IOrderProductRepository<OrderProduct>
    {
        private readonly Common.Common _common;

        public OrderProductRepository(Common.Common common, ObjResponse response) 
        { 
            _common = common;
        } 
        public async Task<ObjResponse> Create(OrderProduct entity)
        {
            try 
            {
                ObjResponse response = null;
                var command = new SqlCommand("create_order", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", DbType.String) { Value = entity.Name });
                command.Parameters.Add(new SqlParameter("@price", DbType.Decimal) { Value = entity.Price });
                command.Parameters.Add(new SqlParameter("@productid", DbType.Int32) { Value = entity.ProductId });
                command.Parameters.Add(new SqlParameter("@orderid", DbType.String) { Value = entity.OrderId });
                var result=command.ExecuteNonQuery();

                if (result <=0) 
                {
                    response =await _common.GetGoodResponse();
                    return response;
                }

                return await _common.GetBadResponse();    
            }
            catch(Exception ex) 
            {
                return await _common.GetBadResponse();
            }
        }
    }
}
