using API.DTOs;
using API.Interfaces;
using Data_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IUnitOfWork uow;

        public ProductController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await uow.ProductRepo.GetProductsAsync();

            var productDto = from c in products
                             select new ProductsDto()
                             {
                                 ProductID = c.ProductID,
                                 CategoryName = uow.ProductRepo.GetCategoryName(c.CategoryID),
                                 BrandName = uow.ProductRepo.GetBrandName(c.BrandID),
                                 Title = c.Title,
                                 Price = c.Price,
                                 Description = c.Description
                             };

            return Ok(productDto);
        }


        [HttpPost("PostProduct")]
        public async Task<IActionResult> PostProduct(ProductsDto productsDto)
        {
            var CId = uow.ProductRepo.GetCategoryId(productsDto.CategoryName);

            var BId = uow.ProductRepo.GetBrandId(productsDto.BrandName);

            var product = new Products()
            {
                ProductID = productsDto.ProductID,
                CategoryID = CId,
                BrandID = BId,
                Title = productsDto.Title,
                Description = productsDto.Description,
                Price = productsDto.Price
            };

            uow.ProductRepo.AddProduct(product);
            await uow.SaveAsync();

            return CreatedAtAction("GetProducts", new { id = product.ProductID }, product);
        }


        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            uow.ProductRepo.DeleteProduct(id);

            await uow.SaveAsync();

            return Ok(id);
        }


        [HttpPut("PutProduct/{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductsDto productsDto)
        {

            var product = uow.ProductRepo.GetProductById(id).Result;

            var CId = uow.ProductRepo.GetCategoryId(productsDto.CategoryName);

            var BId = uow.ProductRepo.GetBrandId(productsDto.BrandName);


            product.ProductID = productsDto.ProductID;
            product.CategoryID = CId;
            product.BrandID = BId;
            product.Title = productsDto.Title;
            product.Description = productsDto.Description;
            product.Price = productsDto.Price;

            await uow.SaveAsync();

            return StatusCode(200);
        }
    }
}
