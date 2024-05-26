using Application.Interfaces;
using Azure;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Common;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProductRepository<Product> _productRepository;
        private readonly Common _common;

        public ServiceProduct(IProductRepository<Product> productRepository, Common common) 
        { 
            _productRepository = productRepository;
            _common = common;
        }

        public async Task<ObjResponse> Create(Product product)
        {
            try
            {
                var response = await _productRepository.Create(product);
                return response;
               
            }
            catch (Exception e)
            {
                return await _common.GetBadResponse();
            }
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
