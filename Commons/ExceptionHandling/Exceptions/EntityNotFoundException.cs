using System;

namespace Commons.ExceptionHandling.Exceptions {
    public class EntityNotFoundException : BaseException {

        public EntityNotFoundException(string message, string origin) : base(message, origin) {
            this.message = message;
            this.origin = origin;
        }

    }
}
