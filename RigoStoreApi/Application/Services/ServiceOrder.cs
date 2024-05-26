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
        private readonly Common _common;
        
        public ServiceOrder(ObjResponse response, 
            IOrderRepository<Order> orderRepository,
            Common common
            ) 

        { 
            _orderRepository = orderRepository;
            _response = response;
            _common = common;
        }

        public async Task<ObjResponse> Create(Order order)
        {
            try
            {
               _response=await _orderRepository.Create(order);
                if (_response.Code == 400) 
                {
                  return  await _common.GetBadResponse();
                }

                return _response;
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
                var response= await _orderRepository.GetOrders(); 
                return response;    
            }
            catch (Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        }

        public async Task<ObjResponse> Edit(Order entity) 
        {
            try 
            { 
                var response=await _orderRepository.Edit(entity);   
                return response;    
            } catch (Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        
        }

        public async Task<ObjResponse> GetOrder(int id)
        {
            try 
            { 
                var response=await _orderRepository.GetOrder(id); 
                return response;
            }
            catch (Exception e) 
            { 
                return await _common.GetBadResponse();
            }
        
        }

        public async Task<ObjResponse> Delete(int id)
        {
            try
            {   
                var response = await _orderRepository.Delete(id);
                return response;
            }
            catch (Exception e)
            {
                return await _common.GetBadResponse();
            }
        }
    }
}
