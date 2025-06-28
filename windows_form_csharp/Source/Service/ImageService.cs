using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Source.DataAcess;
using Source.Dtos.Account;
using Source.Dtos.Image;
using Source.Dtos.Product;
using Source.Dtos.Reponse;
using Source.Models;

namespace Source.Service
{
    public class ImageService
    {
        private readonly ApiClient _apiClient;
        public ImageService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        public async Task<BaseResponse<IEnumerable<ImageDTO>>> UploadMultipleImages(IFormFile[] files, Guid productId, string altText)
        {
            return await _apiClient.PostAsync<BaseResponse<IEnumerable<ImageDTO>>>("Images/UploadMultiple",  files, productId, altText);
        }
        public async Task<BaseResponse<ImageDTO>> GetImagesByProductId(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<ImageDTO>>($"Images/GetByProductId/{productId}");
        }
        public async Task<BaseResponse<IEnumerable<ImageDTO>>> UpdateImages(Guid productId, IFormFile[] newFiles, IEnumerable<Guid> imageIdsToDelete, string altText)
        {

            return await _apiClient.PutAsync<BaseResponse<IEnumerable<ImageDTO>>>("Images/UpdateMultiple", productId, newFiles, imageIdsToDelete, altText);
        }
        public async Task<bool> DeleteImage(Guid id)
        {
            return await _apiClient.DeleteAsync($"Images/Delete/{id}");
        }
        public async Task<bool> DeleteImagesByProductIdAsync(Guid productId)
        {
            return await _apiClient.DeleteAsync($"Images/DeleteByProductId/{productId}");
        }
        
    }
}
