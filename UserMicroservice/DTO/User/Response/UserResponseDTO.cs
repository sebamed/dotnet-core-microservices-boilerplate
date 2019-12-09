using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.DTO.User {
    public class UserResponseDTO {

        public string uuid {get; set; }
        public string username { get; set; }
        public int age { get; set;  }

    }
}
