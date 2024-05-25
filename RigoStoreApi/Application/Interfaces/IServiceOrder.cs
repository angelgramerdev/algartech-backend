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
        Task<ObjResponse> Create(Order order);
        Task<ObjResponse> GetOrders();
    }
}
