using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInfoAPI.Model;

namespace ProductInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("GetAllProducts")]
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> listProduct = new List<ProductModel>();
            try
            {
                listProduct = _context.Products.ToList();
            }
            catch (Exception ex)
            {
            }
            
            return listProduct;
        }

        [Authorize]
        [HttpPost("AddNewProduct")]
        public List<ProductModel> AddProductInfo(ProductModel newProductModel)
        {
            List<ProductModel> listProduct = new List<ProductModel>();
            int countChanges = 0;
            try
            {
                var record = _context.Products.SingleOrDefault(m => m.ProductID == newProductModel.ProductID);
                if (record == null)
                {
                    _context.Products.Add(newProductModel);
                    countChanges = _context.SaveChanges();
                }

                if (countChanges > 0)
                {
                    listProduct = _context.Products.ToList();
                }

            }
            catch (Exception ex)
            {
            }

            return listProduct;
        }

        [Authorize]
        [HttpPost("UpdateProductPrice")]
        public List<ProductModel> UpdatePrice(ProductModel productModel)
        {
            List<ProductModel> listProduct = new List<ProductModel>();
            int countChanges = 0;
            try
            {
                var record = _context.Products.SingleOrDefault(m => m.ProductID == productModel.ProductID);
                if (record != null)
                {
                    record.ProductPrice = productModel.ProductPrice;
                    countChanges = _context.SaveChanges();
                }

                if (countChanges > 0)
                {
                    listProduct = _context.Products.ToList();
                }

            }
            catch (Exception ex)
            {
            }

            return listProduct;
        }        
    }
}
