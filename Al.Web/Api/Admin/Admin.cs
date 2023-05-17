using Al.Core.IServices.Admin;
using Al.Core.Tools.Image;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Group;
using Al.Domain.IRepository.Products.Image;
using Al.Domain.IRepository.Products.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Al.Web.Api.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class Admin : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IAdminProductService _adminProductService;

        public Admin(IGroupRepository groupRepository,IImageRepository imageRepository, IAdminProductService adminProductService)
        {
            _groupRepository = groupRepository;
            _imageRepository = imageRepository;
            _adminProductService = adminProductService;
        }

        [HttpGet]
        [Route("GetAllGroups")]
        [Produces("application/json")]
        public IActionResult GetAllGroups()
        {
            return Ok(_groupRepository.GetAllParentGroups());
        }

        [HttpGet]
        [Route("SearchProduct")]
        [Produces("application/json")]
        public async Task<IActionResult> SearchProduct()
        {
            try
            {
                string filter = HttpContext.Request.Query["term"].ToString();
                List<string> result = _adminProductService.SearchProduct(filter);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("SearchProductNotSlide")]
        public async Task<IActionResult> SearchProductNotSlide()
        {
            try
            {
                string filter = HttpContext.Request.Query["term"].ToString();
                List<string> result = _adminProductService.SearchProductNotSlide(filter);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        

        [HttpGet]
        [Produces("application/json")]
        [Route("GetSubGroupsByParentId/{parentId}")]
        public IActionResult GetSubGroupsByParentId(int parentId) {
            return Ok(_groupRepository.GetSubGroupsByParentId(parentId));
        }

        [HttpPost]
        [Route("UploadProductImage")]
        [Produces("application/json")]
        public IActionResult UploadProductImage(IFormFile file)
        {
            string name = UploadImage.UploadFileImage(file, "wwwroot/images/products/normal");
            UploadImage.UploadFileImage(file, "wwwroot/images/products/thumb", name);

            var resizer = new Al.Core.Tools.ImageResizer.ImageConvertor();

            string fullNormalPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/normal/" + name;
            string fullThumbPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/thumb/" + name;

            resizer.Image_resize(fullNormalPath, fullThumbPath, 200);

            return Ok(new { name = name });
        }

        [HttpPost]
        [Route("UploadProductImageForEdit")]
        [Produces("application/json")]
        public IActionResult UploadProductImageForEdit(IFormFile file, [FromForm] string productId)
        {
            string name = UploadImage.UploadFileImage(file, "wwwroot/images/products/normal");
            UploadImage.UploadFileImage(file, "wwwroot/images/products/thumb", name);

            var resizer = new Al.Core.Tools.ImageResizer.ImageConvertor();
            string fullNormalPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/normal/" + name;
            string fullThumbPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/thumb/" + name;

            resizer.Image_resize(fullNormalPath, fullThumbPath, 200);

            ProductImage image = new ProductImage()
            {
                ImageAddress = name,
                ProductId = Int32.Parse(productId),
            };

            _imageRepository.AddImage(image);
            _imageRepository.SaveChanges();

            return Ok(new { name = name });
        }

        [HttpPost]
        [Route("UploadBannerImage")]
        [Produces("application/json")]
        public IActionResult UploadBannerImage(IFormFile file, [FromForm] string previous)
        {
            Console.WriteLine("previous : " + previous);
            string name = UploadImage.UploadFileImage(file, "wwwroot/images/banners");

            if(previous != "null")
            {
                string fullPath = Directory.GetCurrentDirectory() + "/wwwroot/images/banners/" + previous;
                UploadImage.DeleteFile(fullPath);
            }

            return Ok(new { name = name });
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("DeleteProductImage/{name}")]
        public IActionResult DeleteProductImage(string name)
        {
            string fullNormalPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/normal/" + name;
            string fullThumbPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/thumb/" + name;

            UploadImage.DeleteFile(fullNormalPath);
            UploadImage.DeleteFile(fullThumbPath);

            return Ok();
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("DeleteProductEditImage/{name}/{productId}")]
        public IActionResult DeleteProductEditImage(string name, string productId)
        {
            string fullNormalPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/normal/" + name;
            string fullThumbPath = Directory.GetCurrentDirectory() + "/wwwroot/images/products/thumb/" + name;

            UploadImage.DeleteFile(fullNormalPath);
            UploadImage.DeleteFile(fullThumbPath);

            ProductImage product = _imageRepository.GetImageByValueAndProductId(name, Int32.Parse(productId));

            if(product == null)
            {
                return Ok();
            }

            _imageRepository.RemoveImage(product);
            _imageRepository.SaveChanges();

            return Ok();
        }
    }
}
