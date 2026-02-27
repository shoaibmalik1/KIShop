using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using KIShop.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }
        public async Task<ProductResponse> CreateProduct(ProductRequest request)
        {
            var product = request.Adapt<Product>();

            if (request.MainImage != null)
            {

                var imagePath = await _fileService.UploadAsync(request.MainImage);
                product.MainImage = imagePath;
            }
            if (request.SubImages != null)
            {
                product.SubImages=new List<ProductImage>();
                foreach (var file in request.SubImages)
                {
                    var imagePath = await _fileService.UploadAsync(file);
                    product.SubImages.Add(new ProductImage
                    {
                        ImageName = imagePath

                    });

                }
                var imagepath = await _fileService.UploadAsync(request.MainImage);
               
            }
            await _productRepository.AddAsync(product);


                return product.Adapt<ProductResponse>();

        }

        public async Task<List<ProductUserResponse>> GetAllProductsForUser(string lang="en")
        {
            var products = await _productRepository.GetAllAsync();

            var response = products.BuildAdapter().AddParameters("lang", lang).AdaptToType<List<ProductUserResponse>>();
            return response;
        }

        public async Task<ProductUserDetails> GetAllProductsDetailsForUser(int id,string lang = "en")
        {
            var products = await _productRepository.FindByIdAsync(id);

            var response = products.BuildAdapter().AddParameters("lang", lang).AdaptToType<ProductUserDetails>();
            
            return response;
        }


        public async Task<List<ProductResponse>> GetAllProductsForAdmin()
        {
            var products = await _productRepository.GetAllAsync();

            var response = products.Adapt<List<ProductResponse>>();
            return response;
        }
   
    }
}

