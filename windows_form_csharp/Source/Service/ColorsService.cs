using Source.DataAcess;
using Source.Dtos.Category;
using Source.Dtos.Product;
using Source.Dtos.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Source.Service
{
    public class ColorsService
    {
        private readonly ApiClient _apiClient;
        public ColorsService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        // Create a new color
        public async Task<Models.Color> CreateCollorAsync(ColorDTO colorDto)
        {
            return await _apiClient.PostAsync<Models.Color>("Colors/Create", colorDto);
          
        }

        public async Task<BaseResponse<Models.Color>> GetColorByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<Models.Color>>($"colors/{id}");
        }
        
        public async Task<BaseResponse<IEnumerable<Models.Color>>> GetAllColorsAsync()
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<Models.Color>>>($"colors");
        }
        public async Task<BaseResponse<ColorDTO>> UpdateColorAsync(Guid id, ColorDTO colorDto)
        {
            return await _apiClient.PutAsync<BaseResponse<ColorDTO>>($"colors/{id}", colorDto);
        }
        public async Task<bool> DeleteColorAsync(Guid id)
        {
            return await _apiClient.DeleteAsync($"colors/{id}");
        }
        public async Task<bool> DeleteColorsByProductIdAsync(Guid productId)
        {
            return await _apiClient.DeleteAsync($"colors/DeleteByProductId/{productId}");
        }

      

    }
}
