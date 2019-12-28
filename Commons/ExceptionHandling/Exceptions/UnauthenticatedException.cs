using System;

namespace Commons.ExceptionHandling.Exceptions {
    public class UnauthenticatedException : BaseException {

        public UnauthenticatedException(string message, string origin) : base(message, origin) {
            this.message = message;
            this.origin = origin;
        }

    }
}
