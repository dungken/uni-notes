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
    public class FeedbackService
    {
        private readonly ApiClient _apiClient;
        public FeedbackService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }

       
        // Create a new feedback
        public async Task<BaseResponse<FeedbackDTO>> CreateFeedbackAsync(CreateFeedbackDto feedbackDto)
        {
            return await _apiClient.PostAsync<BaseResponse<FeedbackDTO>>("Feedback", feedbackDto);
        }
        // Get feedback by id
        public async Task<BaseResponse<FeedbackDTO>> GetFeedbackByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<FeedbackDTO>>($"Feedback/{id}");
        }

        // Get all feedbacks for a product
        public async Task<BaseResponse<IEnumerable<FeedbackDTO>>> GetAllFeedbacksForAProductAsync(Guid productId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<FeedbackDTO>>>($"Feedback/product/{productId}");
        }

        // Update feedback
        public async Task<BaseResponse<FeedbackDTO>> UpdateFeedbackAsync(Guid id, UpdateFeedbackDto feedbackDto)
        {
            return await _apiClient.PutAsync<BaseResponse<FeedbackDTO>>($"Feedback/{id}", feedbackDto);
        }

        // Delete feedback
        public async Task<bool> DeleteFeedbackAsync(Guid id)
        {
            return await _apiClient.DeleteAsync($"Feedback/{id}");
        }

    }
}
