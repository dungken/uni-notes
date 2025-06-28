using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;

namespace api.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto dto);
        Task<OrderDto> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersByUserIdAsync(Guid userId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<bool> UpdateOrderStatusAsync(Guid orderId, string status);
        Task<bool> AddToCartAsync(Guid orderId, List<CartItemDto> cartItems);
        Task<bool> DeleteOrderAsync(Guid orderId);
    }
}