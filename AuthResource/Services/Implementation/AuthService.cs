using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthResource.DTO.User;
using AuthResource.Utils;

namespace AuthResource.Services.Implementation {
    public class AuthService : IAuthService {

        private readonly JwtGenerator _jwtGenerator;
        public AuthService(JwtGenerator jwtGenerator) {
            this._jwtGenerator = jwtGenerator;
        }

        public SignInResponseDTO SignIn(SignInRequestDTO requestDTO) {
            // todo (get the actual data from db, check the passwords etc.)
            return new SignInResponseDTO() { 
                username = requestDTO.username, 
                uuid = "123", 
                token = this._jwtGenerator.Generate(requestDTO.username, "User")
            };
        }
    }
}
