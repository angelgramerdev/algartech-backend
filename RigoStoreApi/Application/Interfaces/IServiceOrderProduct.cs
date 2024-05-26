using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceOrderProduct
    {
        Task<ObjResponse> Create(OrderProduct orderProduct);
        Task<ObjResponse> GetOrderProducts(int orderId);
    }
}
