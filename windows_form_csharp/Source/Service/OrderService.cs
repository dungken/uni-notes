using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Source.DataAcess;
using Source.Dtos.Order;
using Source.Dtos.Reponse;
using Source.Dtos.Voucher;
using Source.Models;

namespace Source.Service
{
    public class OrderService
    {
        private readonly ApiClient _apiClient;
        public OrderService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        public async Task<BaseResponse<OrderDto>> CreateOrderAsync(CreateOrderDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<OrderDto>>("Order", model);
        }
        public async Task<BaseResponse<OrderDto>> GetOrderByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<OrderDto>>($"Order/{id}");
        }
        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetAllOrdersAsync()
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<OrderDto>>>("Order");
        }

        public async Task<BaseResponse<bool>> UpdateOrderStatus(Guid id, UpdateOrderDto status)
        {
            return await _apiClient.PutAsync<BaseResponse<bool>>($"Order/status/{id}", status);
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetAllOrdersByUserIdAsync(Guid userId)
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<OrderDto>>>($"Order/user/{userId}");
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
          return await _apiClient.DeleteAsync($"Order/{id}");
           
        }

        public async Task<BaseResponse<Order>> AssignVoucherToOrder(Guid orderId, Guid voucherId)
        {
            return await _apiClient.PostAsync<BaseResponse<Order>>($"Order/{orderId}/voucher/{voucherId}");
             
        }

        public async Task<bool> RemoveVoucherFromOrder(Guid orderId)
        {
           return await _apiClient.DeleteAsync($"Order/{orderId}/voucher");
         
        }

        public async Task<BaseResponse<GetVoucherFromOrderDto>> GetVoucherByOrder(Guid orderId)
        {
            return await _apiClient.GetAsync<BaseResponse<GetVoucherFromOrderDto>>($"Order/{orderId}/voucher");
        }


    }
}
