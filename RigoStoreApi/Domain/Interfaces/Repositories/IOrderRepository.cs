using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository<TEntity>:ICreateOrder<TEntity>,IGetOrders,
        IEditOrder<TEntity>, IGetOrder, IDeleteOrder
    {
    }
}
