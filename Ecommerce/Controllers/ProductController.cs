using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("{productId}")]
        public IActionResult GetById(int productId)
        {
            var product = _unitOfWork.Product.GetBy(a => a.ProductId == productId, new[] { "Category" });
            if (product != null)
            {
                ProductDTO productDTO = new ProductDTO();
                productDTO.ProductId = product.ProductId;
                productDTO.ProductName = product.ProductName;
                productDTO.ProductPrice = product.Price;
                productDTO.ProductDescription = product.ProductDescription;
                productDTO.ImagePath = product.ImagePath;
                productDTO.CategoryName = product.Category.CategoryName;
                return Ok(productDTO);


            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Product.GetAll("Category");
            if (products.Any())
            {
                List<ProductDTO> list = new List<ProductDTO>();
                foreach (var product in products)
                {
                    ProductDTO PDTO = new ProductDTO()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.Price,
                        ProductDescription = product.ProductDescription,
                        ImagePath = product.ImagePath,
                        CategoryName = product.Category.CategoryName
                    };
                    list.Add(PDTO);

                }
                return Ok(list);
            }
            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ProductPostDTO productdto)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.ProductName = productdto.ProductName;
                product.ProductDescription = productdto.ProductDescription;
                product.Price = productdto.ProductPrice;
                product.CategoryId = productdto.ProductCategoryId;
                product.StockQuantity = productdto.StockQuantity;
                product.ImagePath = productdto.ImagePath;
                product.Active = true;

                _unitOfWork.Product.Add(product);
                _unitOfWork.Complete();
                return Ok(product);

            }
            return BadRequest();


        }

        [HttpGet("categoryproduct/{categoryId}")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var products = _unitOfWork.Product.GetAllBy(a => a.CategoryId == categoryId, "Category");
            if (products.Any())
            {
                List<ProductDTO> productsDTO = new List<ProductDTO>();
                foreach (var product in products)
                {
                    productsDTO.Add(new ProductDTO()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.Price,
                        ProductDescription = product.ProductDescription,
                        CategoryName = product.Category.CategoryName
                    });
                }
                return Ok(productsDTO);

            }
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{productiId}")]
        public IActionResult Update(int productiId, ProductPostDTO productdto)
        {
            if (ModelState.IsValid)
            {
                var product = _unitOfWork.Product.GetBy(a => a.ProductId == productiId, new[] { "Category" });

                if (product != null && product.ProductId == productiId)
                {
                    ProductDTO productDTO = new ProductDTO();

                    product.ProductName = productdto.ProductName;
                    product.ProductDescription = productdto.ProductDescription;
                    product.Price = productdto.ProductPrice;
                    product.CategoryId = productdto.ProductCategoryId;
                    product.StockQuantity = productdto.StockQuantity;
                    product.ImagePath = productdto.ImagePath;

                    _unitOfWork.Product.Update(product);
                    _unitOfWork.Complete();

                    return Ok(productDTO);
                }
                return BadRequest();


            }

            return BadRequest();

        }


        [HttpGet("Filtering")]
        public IActionResult Filtering(string CategoryName = null, decimal Maxprice = 0, decimal MinPrice = 0, string KeyWord = null)
        {
            if (ModelState.IsValid)
            {
                var products = _unitOfWork.Product.GetAll("Category");

                if (CategoryName != null)
                {
                    products = _unitOfWork.Product.GetAllBy(a => a.Category.CategoryName.Contains(CategoryName), "Category");
                }

                if (Maxprice > 0)
                {
                    products = _unitOfWork.Product.GetAllBy(a => a.Price < Maxprice, "Category");
                }

                if (MinPrice > 0)
                {
                    products = _unitOfWork.Product.GetAllBy(a => a.Price > MinPrice, "Category");
                }
                if (KeyWord != null)
                {
                    products = _unitOfWork.Product.GetAllBy(a => a.ProductName.Contains(KeyWord), "Category");

                }

                if (products.Any())
                {
                    List<ProductDTO> list = new List<ProductDTO>();
                    foreach (var product in products)
                    {
                        ProductDTO PDTO = new ProductDTO()
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            ProductPrice = product.Price,
                            ProductDescription = product.ProductDescription,
                            ImagePath = product.ImagePath,
                            CategoryName = product.Category.CategoryName
                        };
                        list.Add(PDTO);

                    }
                    return Ok(list);

                }
                return NoContent();
            }

            return BadRequest();

        }



        //[HttpGet("{name:alpha}")]
        //public IActionResult Search(string name)
        //{
        //    var products = _unitOfWork.Product.GetAllBy(a => a.ProductName.Contains(name), "Category");
        //    if (products.Any())
        //    {
        //        List<ProductDTO> list = new List<ProductDTO>();
        //        foreach (var product in products)
        //        {
        //            ProductDTO PDTO = new ProductDTO()
        //            {
        //                ProductId = product.ProductId,
        //                ProductName = product.ProductName,
        //                ProductPrice = product.Price,
        //                ProductDescription = product.ProductDescription,
        //                ImagePath = product.ImagePath,
        //                CategoryName = product.Category.CategoryName
        //            };
        //            list.Add(PDTO);

        //        }
        //        return Ok(list);
        //    }
        //    return NoContent();

        //}

        [Authorize(Roles = "Admin")]
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId) 
        {
            var product =_unitOfWork.Product.GetById(productId);
            if (product != null) 
            { 
                _unitOfWork.Product.DeleteById(productId);
                _unitOfWork.Complete();
                return Ok(product);
            }
            return BadRequest();
        }





    }
}
