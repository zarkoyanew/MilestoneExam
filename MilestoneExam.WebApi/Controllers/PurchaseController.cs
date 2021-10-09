using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilestoneExam.Data.Models;
using MilestoneExam.Services.Interfaces;
using MilestoneExam.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneExam.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IServiceFactory factory;

        public PurchaseController(IServiceFactory serviceFactory)
        {
            factory = serviceFactory;
        }

        [HttpGet("ByProductName")]
        public async Task<PurchaseReportByProductModel> GetPurchasesByProductName(string productName)
        {
            var purchaseService = factory.GetPurchaseService();

            var product = await purchaseService.GetPurchasesByProductName(productName);

            return new PurchaseReportByProductModel
            {
                Purchases = product.Purchases.Select(p => new PurchaseModel
                {
                    CustomerId = p.CustomerId,
                    ProductId = p.ProductId,
                    ProductQuantity = p.ProductQuantity
                }).ToList(),
                TotalPaidPrice = product.Purchases.Sum(p => p.ProductQuantity) * product.Price
            };
        }

        [HttpGet("ByCustomerName")]
        public async Task<PurchaseReportByCustomerModel> GetPurchasesByCustomerName(string customerName)
        {
            var purchaseService = factory.GetPurchaseService();

            var customer = await purchaseService.GetPurchasesByCustomerName(customerName);

            return new PurchaseReportByCustomerModel
            {
                Purchases = customer.Purchases.Select(p => new PurchaseModel
                {
                    CustomerId = p.CustomerId,
                    ProductId = p.ProductId,
                    ProductQuantity = p.ProductQuantity
                }).ToList(),
                UniqueProductsCount = customer.Purchases.Count
            };
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseModel purchase)
        {
            var purchaseService = factory.GetPurchaseService();

            var purchaseEntity = new Purchase
            {
                CustomerId = purchase.CustomerId,
                ProductId = purchase.ProductId,
                ProductQuantity = purchase.ProductQuantity
            };

            await purchaseService.AddAsync(purchaseEntity);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] PurchaseModel purchase)
        {
            var purchaseService = factory.GetPurchaseService();

            var purchaseEntity = new Purchase
            {
                CustomerId = purchase.CustomerId,
                ProductId = purchase.ProductId,
                ProductQuantity = purchase.ProductQuantity
            };

            await purchaseService.DeleteAsync(purchaseEntity);

            return Ok();
        }
    }
}
