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
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly Common _common;

        public ServiceProduct(IProductRepository productRepository, Common common) 
        { 
            _productRepository = productRepository;
            _common = common;
        }

        public async Task<ObjResponse> GetProducts()
        {
            try
            {
                var response=await _productRepository.GetProducts();
                return response;
            }
            catch(Exception e) 
            {
                return await _common.GetBadResponse();
            }
        }
    }
}
