﻿using Domain.Entities;
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
        private readonly IProductRepository _productRepository;

        public OrderProductRepository(Common.Common common, IProductRepository productRepository) 
        { 
            _common = common;
            _productRepository = productRepository;
        }

        public async Task<ObjResponse> CalculateOrder(int orderId)
        {
            try 
            {
                ObjResponse response = null;
                decimal total = 0;
                var command = new SqlCommand("calculate_total_order", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@orderid", DbType.Int32) { Value = orderId });
                var result =await command.ExecuteReaderAsync();
                if (result.HasRows) 
                { 
                    while (await result.ReadAsync()) 
                    {
                        total = result.GetDecimal("total");
                    }
                    response =await _common.GetGoodResponse();
                    response.total = total;
                }

                return response;
            }
            catch(Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        }

        public async Task<ObjResponse> Create(OrderProduct entity)
        {
            try 
            {
                ObjResponse response = null;
                response=await _productRepository.GetProduct(entity.ProductId);
                var command = new SqlCommand("create_order_product", _common.Conectar());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", DbType.String) { Value = response.product.Name });
                command.Parameters.Add(new SqlParameter("@price", DbType.Decimal) { Value = response.product.Price });
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