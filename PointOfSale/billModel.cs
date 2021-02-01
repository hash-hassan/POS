using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class billModel
    {
       

        public long order_ID { get; set; }
        public float paid_Amount { get; set; }
        public DateTime date_time { get; set; }
        public string order_Type { get; set; }

        public float discount { get; set; }

        public billModel(long order_ID, float paid_amount, DateTime date_time, string order_type, float discount)
        {
            this.order_ID = order_ID;
            this.paid_Amount = paid_amount;
            this.date_time = date_time;
            this.order_Type = order_type;
            this.discount = discount;
        }

    }
}
