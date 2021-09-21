using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProceedToBuy.API.Models
{
    public class CartModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int CustomerId{get; set;}
        public int ProductId { get; set; }
        public int Zipcode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public VendorModel vendors{ get; set; }
    }
}
