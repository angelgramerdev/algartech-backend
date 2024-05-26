using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IServiceOrder
    {
        Task<ObjResponse> Create(Order entity);
        Task<ObjResponse> GetOrders();
        Task<ObjResponse> GetOrder(int id);
        Task<ObjResponse> Edit(Order entity);
        Task<ObjResponse> Delete(int id);   
    }
}
