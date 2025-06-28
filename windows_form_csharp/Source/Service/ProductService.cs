using api.Dtos.Product;
using Source.DataAcess;
using Source.Dtos.Order;
using Source.Dtos.Product;
using Source.Dtos.Reponse;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Service
{
    public class ProductService
    {
        private readonly ApiClient _apiClient;
        public ProductService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        // Create a new product
        public async Task<BaseResponse<Dtos.Product.ProductDTO>> CreateProductAsync(CreateProductDto productDto)
        {
            return await _apiClient.PostAsync<BaseResponse<Dtos.Product.ProductDTO>>("Products/Create", productDto);
        }
        // Get product by id
        public async Task<BaseResponse<Dtos.Product.ProductDTO>> GetProductByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<Dtos.Product.ProductDTO>>($"Products/{id}");
        }
        // Get all products
        public async Task<BaseResponse<IEnumerable<Dtos.Product.ProductDTO>>> GetAllProductsAsync()
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<Dtos.Product.ProductDTO>>>($"Products");
        }
        // Get Products by category
        public async Task<BaseResponse<IEnumerable<Dtos.Product.ProductDTO>>> GetProductsByCategory(Guid categoryId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<Dtos.Product.ProductDTO>>>($"Products/Category/{categoryId}");
        }

        // Update product
        public async Task<BaseResponse<Models.ProductDTO>> UpdateProductAsync(Guid id, UpdateProductDTO productDto)
        {
            return await _apiClient.PutAsync<BaseResponse<Models.ProductDTO>>($"Products/{id}", productDto);
        }

        // Delete product
        public async Task<bool> DeleteProductAsync(Guid id)
        {
            return await _apiClient.DeleteAsync($"Products/{id}");
        }

        // Get all colors from product by id
        public async Task<BaseResponse<IEnumerable<GetColorDto>>> GetAllColorsFromProductById(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<GetColorDto>>>($"Products/{productId}/Colors");
        }

        // Get all sizes from product by id
        public async Task<BaseResponse<IEnumerable<GetSizeDto>>> GetAllSizesFromProductById(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<GetSizeDto>>>($"Products/{productId}/Sizes");
        }

        // Get all images from product by id
        public async Task<BaseResponse<IEnumerable<GetImageDto>>> GetAllImagesFromProductById(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<GetImageDto>>>($"Products/{productId}/Images");
        }

        // Get all feedbacks from product by id
        public async Task<BaseResponse<IEnumerable<GetFeedbackDto>>> GetAllFeedbacksFromProductById(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<GetFeedbackDto>>>($"Products/{productId}/Feedbacks");
        }

        // Get order details from product by id
        public async Task<BaseResponse<IEnumerable<GetOrderDetailDto>>> GetOrderDetailsFromProductById(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<GetOrderDetailDto>>>($"Products/{productId}/OrderDetails");
        }

        // Add existing color to product
        public async Task<BaseResponse<Dtos.Product.ProductDTO>> AddExistingColorToProduct(Guid productId, Guid colorId)
        {
            return await _apiClient.PostAsync<BaseResponse<Dtos.Product.ProductDTO>>($"Products/{productId}/AddExistingColorToProduct/{colorId}");
        }
    }
}
