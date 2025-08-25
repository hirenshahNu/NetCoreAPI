using System.ComponentModel.DataAnnotations;

namespace ProductInfoAPI.Model
{
    public class ProductModel
    {
        [Key]
        public string ProductID { get; set; }            
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductManufacturer { get; set; }
        public DateOnly? ProductManufacturingDate { get; set; }
        public DateOnly? ProductExpiryDate { get; set; }
        public string? ProductManufacturerMobileNo { get; set; }
        public string? ProductManufacturerEmailId { get; set; }
        public string? ProductBatchNumber { get; set; }        
    }
}
