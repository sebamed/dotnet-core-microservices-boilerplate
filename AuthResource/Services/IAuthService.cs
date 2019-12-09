using AuthResource.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthResource.Services {
    public interface IAuthService {

        SignInResponseDTO SignIn(SignInRequestDTO requestDTO);

    }
}
