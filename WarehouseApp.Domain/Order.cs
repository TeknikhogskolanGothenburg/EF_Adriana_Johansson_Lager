using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApp.Domain
{
    public class Order
    {
        public Order()
        {
            Product = new List<Product>();
            OrderRow = new List<OrderRow>();
        }
        public int Id { get; set; }
        public string Adress { get; set; }
        public int CustomerId { get; set; }
        public List<Product> Product { get; set; }
        public List <OrderRow> OrderRow { get; set; }
        

    }
}
