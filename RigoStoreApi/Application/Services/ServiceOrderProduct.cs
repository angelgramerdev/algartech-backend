using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceOrderProduct:IServiceOrderProduct
    {
        private readonly IOrderProductRepository<OrderProduct> _orderProductRepository;
        private readonly Common _common;
        public ServiceOrderProduct(IOrderProductRepository<OrderProduct> orderProductRepository, Common common) 
        { 
            _orderProductRepository = orderProductRepository;
            _common = common;
        }    

        public async Task<ObjResponse> Create(OrderProduct orderProduct)
        {
            try
            {
                ObjResponse response = null;
                response =await _orderProductRepository.Create(orderProduct);
                return response;    
            }
            catch (Exception e) 
            {
                return await _common.GetBadResponse();
            }
        }

        public async Task<ObjResponse> GetOrderProducts(int orderId) 
        {
            try
            {
                ObjResponse response = null;
                response = await _orderProductRepository.GetOrderProducts(orderId);
                return response;
            }
            catch (Exception e)
            {
                return await _common.GetBadResponse();
            }
        }
    }
}
