using API.DTOs;
using API.Interfaces;
using Data_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IUnitOfWork uow;

        public BrandController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        #region GetBrands
        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await uow.BrandRepo.GetBrandsAsync();

            var brandsDto = from c in brands
                            select new BrandsDto()
                            {
                                BrandId = c.BrandID,
                                Title = c.Title,
                                Description = c.Description
                            };

            return Ok(brandsDto);
        }
        #endregion


        #region PostBrand
        [HttpPost("PostBrand")]
        public async Task<IActionResult> PostBrand(BrandsDto brandsDto)
        {
            Brands brand = new();

            brand.BrandID = brandsDto.BrandId;
            brand.Title = brandsDto.Title;
            brand.Description = brandsDto.Description;

            uow.BrandRepo.AddBrand(brand);

            await uow.SaveAsync();

            return CreatedAtAction("GetBrands", new { id = brand.BrandID }, brand);
        }
        #endregion


        #region DeleteBrand
        [HttpDelete("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var isValid = await uow.BrandRepo.GetBrandById(id);
            if (isValid == null)
            {
                return BadRequest("No such brand exists");
            }

            uow.BrandRepo.DeleteBrand(id);
            await uow.SaveAsync();

            return Ok(id);
        }
        #endregion


        #region PutBrand
        [HttpPut("PutBrand/{id}")]
        public async Task<IActionResult> PutBrand(int id, BrandsDto brandsDto)
        {
            if(id != brandsDto.BrandId)
            {
                return BadRequest();
            }

            var brand = await uow.BrandRepo.GetBrandById(id);

            brand.Title = brandsDto.Title;
            brand.BrandID = brandsDto.BrandId;
            brand.Description = brandsDto.Description;

            await uow.SaveAsync();

            return StatusCode(200);
        }
        #endregion
    }
}
