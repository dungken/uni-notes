using Source.DataAcess;
using Source.Dtos.Category;
using Source.Dtos.Product;
using Source.Dtos.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Service
{
    public class CategoriesService
    {
        private readonly ApiClient _apiClient;

        public CategoriesService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);

        }
        public async Task<BaseResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            return await _apiClient.PostAsync<BaseResponse<CategoryDto>>("Categories", categoryDto);
        }
        public async Task<BaseResponse<CategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<CategoryDto>>($"Categories/{id}");
        }

        public async Task<BaseResponse<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<CategoryDto>>>($"Categories");
        } 
        
        public async Task<BaseResponse<IEnumerable<CategoryDto>>> GetSubCategories(Guid parentCategoryId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<CategoryDto>>>($"Categories/subcategories/{parentCategoryId}");
        }

        public async Task<BaseResponse<IEnumerable<ProductDTO>>> GetProductsByCategoryIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<ProductDTO>>>($"Categories/{id}/products");
        }
         public async Task<BaseResponse<CategoryDto>> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            return await _apiClient.PutAsync<BaseResponse<CategoryDto>>($"Categories/{id}", categoryDto);
        }
        public async Task<bool> DeleteCategory(Guid id)
        {
            return await _apiClient.DeleteAsync($"Categories/{id}");
        }



    }
}
