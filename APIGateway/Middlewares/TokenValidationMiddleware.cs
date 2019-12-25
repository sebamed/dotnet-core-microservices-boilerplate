using Commons.ExceptionHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Middlewares {
    public class TokenValidationMiddleware {

        public static void ValidateToken(String token) {
            if (token != null) {
                // token exists and needs to be validated
                // TODO: add logic for calling the Auth Resource to validate the token
                // [...]
                // [...]
                // [...]
            } else {
                // token does not exist

                throw new UnauthenticatedException("You must provide a token to access this route!");
            }
        }

    }
}
