using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.ExceptionHandling.Exceptions {
    public class EntityNotFoundException : Exception {

        public string message { get; set; }

        public override string Message {
            get { return this.message; }
        }

        public EntityNotFoundException(string message) {
            this.message = message;
        }

        

    }
}
