using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.DataAcess;
using Source.Dtos.Order;
using Source.Dtos.Payment;
using Source.Dtos.Reponse;

namespace Source.Service
{
    public class PaymentService
    {
        private readonly ApiClient _apiClient;
        public PaymentService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        public async Task<CreatePaymentDto> CreatePayment(CreatePaymentDto model)
        {
            return await _apiClient.PostAsync<CreatePaymentDto>("Payment", model);
        }
        public async Task<BaseResponse<PaymentDto>> GetPaymentByOrderId(Guid orderId)
        {
            return await _apiClient.GetAsync<BaseResponse<PaymentDto>>($"Payment/{orderId}");
        }
    }
}
