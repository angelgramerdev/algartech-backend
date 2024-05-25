using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Common;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class OrderRepository : IOrderRepository<Order>
    {
        private ObjResponse _response;   
        private readonly Common.Common _common;

        public OrderRepository(ObjResponse response, 
            RigoStoreContext context,
            Common.Common common
            ) 
        {        
            _response = response;
            _common = common;   
        }

        public async Task<ObjResponse> Create(Order entity)
        {
            try
            {
                //var identification = new SqlParameter("@identification", SqlDbType.NVarChar) { Value = entity.Identification };
                //var deliveryAddress = new SqlParameter("@deliveryaddress", SqlDbType.NVarChar) { Value = entity.DeliveryAddress };
                //var name = new SqlParameter("@name", SqlDbType.NVarChar) { Value = entity.Name };
                //var creationDate = new SqlParameter("@creationdate", SqlDbType.DateTime) { Value = DateTime.Now };

                //var identification = new SqlParameter("identification", entity.Identification);
                //var deliveryAddress = new SqlParameter("deliveryaddress", entity.DeliveryAddress);
                //var name = new SqlParameter("name", entity.Name);
                //var creationDate = new SqlParameter("creationdate", DateTime.Now);

                //DataLayer.DataAccess.AddParamater("@CategoryName", CategoryName, System.Data.SqlDbType.NVarChar, 200)

                //var sqlParams = new SqlParameter[] {
                //  new SqlParameter("@identification", entity.Identification),
                //  new SqlParameter("@deliveryaddress", entity.DeliveryAddress),
                //  new SqlParameter("@name", entity.Name),
                //  new SqlParameter("@creationdate", DateTime.Now)
                //{
                //  Direction = System.Data.ParameterDirection.Input
                //}
                //};
                //var result =_context.CreateOrder("exec create_order", identification, deliveryAddress, name, creationDate);
                //var result = _context.Orders.FromSqlRaw("exec create_order",identification, deliveryAddress, name, creationDate);
                var command = new SqlCommand("create_order",_common.Conectar());
                command.CommandType = CommandType.StoredProcedure;             
                command.Parameters.Add(new SqlParameter("@identification", DbType.String) { Value = entity.Identification });
                command.Parameters.Add(new SqlParameter("@deliveryaddress", DbType.String) { Value = entity.DeliveryAddress });
                command.Parameters.Add(new SqlParameter("@name", DbType.String) { Value = entity.Name });
                command.Parameters.Add(new SqlParameter("@creationdate", DbType.DateTime) { Value = DateTime.Now });

                var res = await command.ExecuteNonQueryAsync();
                if (res < 0)
                {
                    _response =await _common.GetGoodResponse();
                    _response.Message = "Order created";
                    return _response;
                }
                return await _common.GetBadResponse();
            }
            catch (Exception e) 
            {
                return await _common.GetBadResponse();
            }
        }

        public async Task<ObjResponse> GetOrders() 
        {
            try
            {
                var command = new SqlCommand("get_orders", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                var reader=await command.ExecuteReaderAsync();
                if (reader.HasRows) 
                {
                    List<Order> orders = new List<Order>();
                    //await reader.ReadAsync();
                    while (await reader.ReadAsync()) 
                    {
                        var colunm=reader[0];
                        orders.Add(new Order
                        {

                            Id =(int)reader[0],                          
                            Identification = reader[1].ToString(),
                            DeliveryAddress = reader[2].ToString(),
                            Name = reader[3].ToString(),
                            CreationDate =(DateTime)reader[4]
                        });
                    }
                    _response = await _common.GetGoodResponse();    
                    _response.orders = orders;  
                    reader.Close(); 
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
