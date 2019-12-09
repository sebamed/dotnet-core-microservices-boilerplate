using Microsoft.AspNetCore.Mvc;
using AuthResource.DTO.User;
using AuthResource.Localization;
using AuthResource.Services;

namespace AuthResource.Controllers {
    [Route(RouteConsts.ROUTE_AUTH_BASE)]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            this._authService = authService;
        }

        [HttpPost(RouteConsts.ROUTE_AUTH_SIGN_IN)]
        public ActionResult<SignInResponseDTO> HandleSignIn(SignInRequestDTO requestDTO) {
            return Ok(this._authService.SignIn(requestDTO));
        }


    }
}