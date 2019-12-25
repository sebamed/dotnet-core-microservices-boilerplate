using System;

namespace Commons.ExceptionHandling.Exceptions {
    public class UnauthenticatedException : Exception {

        public string message { get; set; }

        public override string Message {
            get { return this.message; }
        }

        public UnauthenticatedException(string message) {
            this.message = message;
        }

        

    }
}
