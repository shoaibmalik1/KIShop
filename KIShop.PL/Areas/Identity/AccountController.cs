using KIShop.BLL.Service;
using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;

using Microsoft.AspNetCore.Mvc;

namespace KIShop.PL.Areas.Identity
{
    [Route("Api/auth/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public  AccountController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result=await _authenticationService.RegisterAsync(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token,string userId)
        {
            var result = await _authenticationService.ConfirEmailAsync(token ,userId);
            
            if (!result)
                return BadRequest("Invalid Token");

            return Ok("Email Confirmed");

        }

        [HttpPost("SendCode")]
        public async Task<IActionResult> RequestPasswordReset(ForgetPasswordRequest request)
        {
            var result = await _authenticationService.RequestPasswordReset(request);
            if (!result.Success) { 
            return BadRequest(result);
            }

            return Ok(result);


        }
        [HttpPatch("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequet request)
        {
            var result = await _authenticationService.ResetPassword(request);
            if (!result.Success) { 
            return BadRequest(result);
            }

            return Ok(result);


        }
    }
}
