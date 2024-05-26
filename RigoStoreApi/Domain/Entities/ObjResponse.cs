using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ObjResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Order order { get; set; }
        public List<Order> orders { get; set; }  
        public List<Product> products { get; set; } 
        public List<OrderProduct> OrderProducts { get; set; }
        public Product product { get; set; } 
        public decimal? total { get; set; }

    }
}
