using RestSharp;
using Source.DataAcess;
using Source.Dtos.Account;
using Source.Dtos.Reponse;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.Service
{
    public class AccountService
    {
        private readonly ApiClient _apiClient;
        public AccountService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }
        public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginUserDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<LoginResponse>>("Account/Login", model);
        }


        public async Task<BaseResponse<User>> RegisterAsync(RegisterUserDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<User>>("Account/RegisterWithCode", model);
        }


        // Can change the object to a more specific type example BaseResponse<object>
        public async Task<BaseResponse<User>> ConfirmEmail(ConfirmEmailDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<User>>("Account/ConfirmEmailWithCode", model);
        }


        public async Task<BaseResponse<MessageRespone>> Logout()
        {
            return await _apiClient.PostAsync<BaseResponse<MessageRespone>>("Account/SocialLogin");
        } 


        public async Task<BaseResponse<LoginResponse>> SocialLogin(SocialLoginDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<LoginResponse>>("Account/SocialLogin", model);
        }

        // get
        public async Task<BaseResponse<Enable2FARespone>> Enable2FA()
        {
            return await _apiClient.GetAsync<BaseResponse<Enable2FARespone>>("Account/Enable2FA");
        }

        public async Task<BaseResponse<Verify2FARespone>> Verify2FA(Verify2FADto model)
        {
            return await _apiClient.PostAsync<BaseResponse<Verify2FARespone>>("Account/Verify2FA", model);
        }

        public async Task<BaseResponse<Verify2FARespone>> Disable2FA()
        {
            return await _apiClient.GetAsync<BaseResponse<Verify2FARespone>>("Account/Disable2FA");
        }


        public async Task<BaseResponse<Verify2FARespone>> GetTwoFAStatus()
        {
            return await _apiClient.GetAsync<BaseResponse<Verify2FARespone>>("Account/TwoFAStatus");
        }

        public async Task<BaseResponse<ForgotPasswordRespone>> ForgotPassword(ForgotPasswordDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<ForgotPasswordRespone>>("Account/ForgotPassword", model);
        }


        public async Task<BaseResponse<object>> ResetPassword(ResetPasswordDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<object>>("Account/ResetPassword", model);
        }


        public async Task<BaseResponse<object>> ChangePassword(ChangePasswordDto model)
        {
            return await _apiClient.PostAsync<BaseResponse<object>>("Account/ChangePassword", model);
        }

        public async Task<BaseResponse<CheckEnableVerifyDto>> CheckEnableVerifyAsync(string username)
        {
            return await _apiClient.GetAsync<BaseResponse<CheckEnableVerifyDto>>($"Account/CheckEnableVerify/{username}");
        }
        public async Task<BaseResponse<SendCodeForForgetPasswordRespone>> SendCodeForForgetPasswordAsync(SendCodeForForgetPassword model)
        {
            return await _apiClient.PostAsync<BaseResponse<SendCodeForForgetPasswordRespone>>("Account/SendCodeForForgetPassword", model);
        }

        

    }
}
