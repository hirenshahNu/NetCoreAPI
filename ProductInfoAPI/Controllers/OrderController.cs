using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInfoAPI.Model;
using System.Collections.Generic;


namespace ProductInfoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly ProductDbContext _context;

        public OrderController(ProductDbContext context) 
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("GetAllOrders")]
        public List<OrderProductModel> GetOrders()
        {
            List<OrderProductModel> listOrderProduct = new List<OrderProductModel>();
            try
            {
                listOrderProduct = (from order in _context.Orders
                                        join product in _context.Products
                                        on order.OrderProductID equals product.ProductID
                                        select new OrderProductModel
                                        {
                                            OrderID = order.OrderID,
                                            OrderProductID = order.OrderProductID,
                                            OrderQuantity = order.OrderQuantity,
                                            OrderAmount = order.OrderAmount,
                                            OrderDeliveryDate = order.OrderDeliveryDate,
                                            OrderCustomerName = order.OrderCustomerName,
                                            OrderCustomerAddress = order.OrderCustomerAddress,
                                            OrderCustomerMobileNo = order.OrderCustomerMobileNo,
                                            OrderCustomerEmailId = order.OrderCustomerEmailId,
                                            ProductName = product.ProductName,
                                            ProductPrice = product.ProductPrice
                                        }).ToList();
            }
            catch (Exception ex) 
            { 
            }

            return listOrderProduct;
        }

        [Authorize]
        [HttpPost("AddNewOrder")]
        public List<OrderProductModel> AddOrderInfo(OrderModel newOrderModel)
        {

            List <OrderProductModel> listOrderProduct = new List <OrderProductModel> ();
            int countChanges = 0;
            try
            {
                var record = _context.Orders.SingleOrDefault(m => m.OrderID == newOrderModel.OrderID);
                var recordProduct = _context.Products.SingleOrDefault(m => m.ProductID == newOrderModel.OrderProductID);
                if (record == null && recordProduct != null)
                {
                    _context.Orders.Add(newOrderModel);
                    countChanges = _context.SaveChanges();
                }

                if (countChanges > 0)
                {
                    listOrderProduct = (from order in _context.Orders
                                        join product in _context.Products
                                        on order.OrderProductID equals product.ProductID
                                        select new OrderProductModel
                                        {
                                            OrderID = order.OrderID,
                                            OrderProductID = order.OrderProductID,
                                            OrderQuantity = order.OrderQuantity,
                                            OrderAmount = order.OrderAmount,
                                            OrderDeliveryDate = order.OrderDeliveryDate,
                                            OrderCustomerName = order.OrderCustomerName,
                                            OrderCustomerAddress = order.OrderCustomerAddress,
                                            OrderCustomerMobileNo = order.OrderCustomerMobileNo,
                                            OrderCustomerEmailId = order.OrderCustomerEmailId,
                                            ProductName = product.ProductName,
                                            ProductPrice = product.ProductPrice
                                        }).ToList();
                }
            }
            catch (Exception ex)
            { 
            }

            return listOrderProduct;
        }

        [Authorize]
        [HttpPost("UpdateOrderQuantity")]
        public List<OrderProductModel> UpdateQuantity([FromBody] OrderModel orderModel)
        {
            List<OrderProductModel> listOrderProduct = new List<OrderProductModel>();
            int countChanges = 0;
            try
            {
                var record = _context.Orders.SingleOrDefault(m => m.OrderID == orderModel.OrderID);
                if (record != null)
                {
                    record.OrderQuantity = orderModel.OrderQuantity;
                    countChanges = _context.SaveChanges();
                }

                if (countChanges > 0)
                {
                    listOrderProduct = (from order in _context.Orders
                                        join product in _context.Products
                                        on order.OrderProductID equals product.ProductID
                                        select new OrderProductModel
                                        {
                                            OrderID = order.OrderID,
                                            OrderProductID = order.OrderProductID,
                                            OrderQuantity = order.OrderQuantity,
                                            OrderAmount = order.OrderAmount,
                                            OrderDeliveryDate = order.OrderDeliveryDate,
                                            OrderCustomerName = order.OrderCustomerName,
                                            OrderCustomerAddress = order.OrderCustomerAddress,
                                            OrderCustomerMobileNo = order.OrderCustomerMobileNo,
                                            OrderCustomerEmailId = order.OrderCustomerEmailId,
                                            ProductName = product.ProductName,
                                            ProductPrice = product.ProductPrice
                                        }).ToList();
                }
            }
            catch (Exception ex)
            { 
            }

            return listOrderProduct;
        }
    }
}
