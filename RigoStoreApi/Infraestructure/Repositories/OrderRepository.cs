﻿using Domain.Entities;
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
          
        private readonly Common.Common _common;
        private readonly IOrderProductRepository<OrderProduct> _orderProductRepository;

        public OrderRepository(ObjResponse response, 
            Common.Common common,
            IOrderProductRepository<OrderProduct> orderProductRepository
            ) 
        {        
            _orderProductRepository = orderProductRepository;
            _common = common;   
        }

        public async Task<ObjResponse> Create(Order entity)
        {
            try
            {
               
                ObjResponse response = null;
                var command = new SqlCommand("create_order",_common.Conectar());
                command.CommandType = CommandType.StoredProcedure;             
                command.Parameters.Add(new SqlParameter("@identification", DbType.String) { Value = entity.Identification });
                command.Parameters.Add(new SqlParameter("@deliveryaddress", DbType.String) { Value = entity.DeliveryAddress });
                command.Parameters.Add(new SqlParameter("@name", DbType.String) { Value = entity.Name });
                command.Parameters.Add(new SqlParameter("@creationdate", DbType.DateTime) { Value = DateTime.Now });

                var res = await command.ExecuteNonQueryAsync();
                if (res < 0)
                {
                    response =await _common.GetGoodResponse();
                    response.Message = "Order created";
                    return response;
                }
                return await _common.GetBadResponse();
            }
            catch (Exception e) 
            {
                return await _common.GetBadResponse();
            }
        }

        public Task<ObjResponse> Edit(Order entity)
        {
            try 
            {
                ObjResponse response = null;
                var command = new SqlCommand("create_order", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@identification", DbType.String) { Value = entity.Identification });
                command.Parameters.Add(new SqlParameter("@deliveryaddress", DbType.String) { Value = entity.DeliveryAddress });
                command.Parameters.Add(new SqlParameter("@name", DbType.String) { Value = entity.Name });
                command.Parameters.Add(new SqlParameter("@creationdate", DbType.DateTime) { Value = DateTime.Now });
            }
            catch (Exception e) 
            { 
            
            }
        }

        public async Task<ObjResponse> GetOrders() 
        {
            try
            {
                ObjResponse response = null;
                var command = new SqlCommand("get_orders", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                var reader=await command.ExecuteReaderAsync();
                if (reader.HasRows) 
                {
                    List<Order> orders = new List<Order>();
                    //await reader.ReadAsync();
                    while (await reader.ReadAsync()) 
                    {
                        var order = await _orderProductRepository.CalculateOrder(reader.GetInt32("id"));
                        orders.Add(new Order
                        {

                            Id =(int)reader[0],                          
                            Identification = reader[1].ToString(),
                            DeliveryAddress = reader[2].ToString(),
                            Name = reader[3].ToString(),
                            Total =order.total,
                            CreationDate =(DateTime)reader[4]
                        });
                    }
                    response = await _common.GetGoodResponse();    
                    response.orders = orders;  
                    reader.Close(); 
                }
                return response;
            }
            catch (Exception e) 
            {
              return await _common.GetBadResponse();
            }
        }
    }
}