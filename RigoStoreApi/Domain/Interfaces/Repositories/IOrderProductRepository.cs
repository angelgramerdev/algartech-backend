﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderProductRepository<TEntity>:ICreateOrderProduct<TEntity>,
        ITotalOrder,IGetOrderProducts
    {
    }
}
