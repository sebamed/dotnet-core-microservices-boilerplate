using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.DTO.User;
using UserMicroservice.DTO.User.Request;

namespace UserMicroservice.Services {
    public interface IUserService : ICrudService<UserResponseDTO> {

        UserResponseDTO Create(CreateUserRequestDTO requestDTO);

        UserResponseDTO Update(UpdateUserRequestDTO requestDTO);

    }
}
