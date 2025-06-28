
using Source.DataAcess;
using Source.Dtos.Reponse;
using Source.Dtos.Voucher;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Service
{
   
    public class VoucherService
    {
        private readonly ApiClient _apiClient;
        public VoucherService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        // Get all vouchers
        public async Task<BaseResponse<IEnumerable<Voucher>>> GetAllVouchersAsync()
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<Voucher>>>("Voucher");
        }

        // Get voucher by id
        public async Task<BaseResponse<Voucher>> GetVoucherByIdAsync(Guid id)
        {
            return await _apiClient.GetAsync<BaseResponse<Voucher>>($"Voucher/{id}");
        }

        // Get voucher by code
        public async Task<BaseResponse<Voucher>> GetVoucherByCodeAsync(string code)
        {
            return await _apiClient.GetAsync<BaseResponse<Voucher>>($"Voucher/Code/{code}");
        }

        //// Get user vouchers
        //public async Task<BaseResponse<IEnumerable<Voucher>>> GetUserVouchersAsync(Guid userId)
        //{
        //    return await _apiClient.GetAsync<BaseResponse<IEnumerable<Voucher>>>("Voucher/User/{userId}");
        //}

        // Create voucher
        public async Task<BaseResponse<Voucher>> CreateVoucherAsync(CreateVoucherDto voucherDto)
        {
            return await _apiClient.PostAsync<BaseResponse<Voucher>>("Voucher/Create", voucherDto);
        }

        // Update voucher
        public async Task<BaseResponse<Voucher>> UpdateVoucherAsync(Guid voucherId, CreateVoucherDto voucherDto)
        {
            return await _apiClient.PutAsync<BaseResponse<Voucher>>($"Voucher/Update/{voucherId}", voucherDto);
        }

        // Delete voucher
        public async Task<BaseResponse<bool>> DeleteVoucherAsync(Guid id)
        {
            bool result = await _apiClient.DeleteAsync($"Voucher/{id}");
            return new BaseResponse<bool> { Data = result, Success = result };
        }

        // Apply voucher
        public async Task<BaseResponse<bool>> ApplyVoucherAsync(Guid voucherId)
        {
            bool result = await _apiClient.PostAsync<bool>($"Voucher/Apply/{voucherId}");
            return new BaseResponse<bool> { Data = result, Success = result };
        }

        // Check if voucher is available
        public async Task<BaseResponse<bool>> IsVoucherAvailableAsync(string code)
        {
            bool result = await _apiClient.GetAsync<bool>($"Voucher/IsAvailable/{code}");
            return new BaseResponse<bool> { Data = result, Success = result };
        }

        // Check if voucher is valid
        public async Task<BaseResponse<bool>> IsVoucherValidAsync(string code, decimal orderAmount)
        {
            bool result = await _apiClient.GetAsync<bool>($"Voucher/IsValid/{code}/{orderAmount}");
            return new BaseResponse<bool> { Data = result, Success = result };
        }
    }
}
