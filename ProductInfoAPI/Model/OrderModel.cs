using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductInfoAPI.Model
{
    public class OrderModel
    {
        [Key]
        public string OrderID { get; set; }

        [ForeignKey("ProductModel")]
        public string? OrderProductID { get; set; }        
        public decimal OrderQuantity { get; set; }
        public decimal? OrderAmount { get; set; }
        public DateOnly? OrderDeliveryDate { get; set; }
        public string? OrderCustomerName { get; set; }
        public string? OrderCustomerAddress { get; set; }
        public string? OrderCustomerMobileNo { get; set; }
        public string? OrderCustomerEmailId { get; set; }

        //public ProductModel Product { get; set; }
    }
}
