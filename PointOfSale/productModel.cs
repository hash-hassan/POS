using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class productModel
    {
       

        public string prod_Name { get; set; }
        public int prod_ID { get; set; }
        public float price { get; set; }
        public string type { get; set; }
        public int quantity { get; set; }
        public float total { get; set; }
        public productModel(string prod_Name, int prod_ID, float price, string type, int qty = 1, int total = 0)
        {
            this.prod_Name = prod_Name;
            this.prod_ID = prod_ID;
            this.price = price;
            this.type = type;
            quantity = qty;
            this.total = price * quantity;

        }
    }
}
