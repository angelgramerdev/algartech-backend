using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Identification { get; set;}
        [MaxLength(200)]
        public string DeliveryAddress { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public decimal? Total { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual List<Product>? Products { get; set; } 

    
    }
}
