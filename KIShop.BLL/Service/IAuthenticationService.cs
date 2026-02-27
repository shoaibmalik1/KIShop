using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.BLL.Service
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task<bool> ConfirEmailAsync(string token, string userId);
        Task<ForgetPasswordResponse> RequestPasswordReset(ForgetPasswordRequest request);
        Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequet request);
        Task<LoginResponse> RefreshTokenAsync(TokenApiModel request);
    }
}
