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
    public class ServiceOrder:IServiceOrder
    {
        private ObjResponse _response;
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly Common _commonResponse;
        
        public ServiceOrder(ObjResponse response, 
            IOrderRepository<Order> orderRepository,
            Common commonResponse
            ) 

        { 
            _orderRepository = orderRepository;
            _response = response;
            _commonResponse = commonResponse;
        }

        public async Task<ObjResponse> Create(Order order)
        {
            try
            {
               _response=await _orderRepository.Create(order);
                if (_response.Code == 400) 
                {
                  return  await _commonResponse.GetBadResponse();
                }

                return _response;
            }
            catch (Exception e) 
            {
                return await _commonResponse.GetBadResponse();
            }
        }

        public async Task<ObjResponse> GetOrders() 
        {
            try 
            { 
                var response= await _orderRepository.GetOrders(); 
                return response;    
            }
            catch (Exception e) 
            { 
                return await _commonResponse.GetBadResponse();
            }
        }
    }
}
