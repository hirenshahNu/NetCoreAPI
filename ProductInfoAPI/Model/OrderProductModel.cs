using System.ComponentModel.DataAnnotations.Schema;

namespace ProductInfoAPI.Model
{
    public class OrderProductModel
    {
        public string? OrderID { get; set; }      
        public string OrderProductID { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal? OrderAmount { get; set; }
        public DateOnly? OrderDeliveryDate { get; set; }
        public string? OrderCustomerName { get; set; }
        public string? OrderCustomerAddress { get; set; }
        public string? OrderCustomerMobileNo { get; set; }
        public string? OrderCustomerEmailId { get; set; }        
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }

    }
}
