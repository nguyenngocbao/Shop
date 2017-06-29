using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? CustomerID { get; set; }

      

        public bool? Status { get; set; }
    }
}
