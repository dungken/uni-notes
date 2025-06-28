using api.Dtos.Product;
using Source.DataAcess;
using Source.Dtos.Product;
using Source.Dtos.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Service
{
    public class SizeService
    {
        private readonly ApiClient _apiClient;
        public SizeService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        // Create a new size
        public async Task<CreateSizeforProductDto> CreateSizeAsync(CreateSizeforProductDto sizeDto)
        {
            return await _apiClient.PostAsync<CreateSizeforProductDto>("Sizes", sizeDto);
        }

        // Get size by id
        public async Task<BaseResponse<SizeDTO>> GetSizeByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<SizeDTO>>($"Sizes/{id}");
        }

        // Get all sizes
        public async Task<BaseResponse<List<GetAllSizeRespone>>> GetAllSizes()
        {
            return await _apiClient.GetAsync<BaseResponse<List<GetAllSizeRespone>>>($"Sizes");
        }

        // Update size
        public async Task<BaseResponse<CreateSizeforProductDto>> UpdateSize(Guid id, CreateSizeforProductDto sizeDto)
        {
            return await _apiClient.PutAsync<BaseResponse<CreateSizeforProductDto>>($"Sizes/{id}", sizeDto);
        }

        // Delete size
        public async Task<bool> DeleteSize(Guid? id)
        {
            return await _apiClient.DeleteAsync($"Sizes/{id}");
        }
        // Delete size by product id
        public async Task<bool> DeleteSizeByProductIdAsync(Guid productId)
        {
            return await _apiClient.DeleteAsync($"Sizes/product/{productId}");
        }

    }
}
