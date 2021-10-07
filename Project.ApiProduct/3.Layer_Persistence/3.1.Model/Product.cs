using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._3.Layer_Persistence._3._1.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
