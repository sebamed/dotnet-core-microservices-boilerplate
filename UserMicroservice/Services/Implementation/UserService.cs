using Commons.ExceptionHandling.Exceptions;
using System.Collections.Generic;
using UserMicroservice.Consts;
using UserMicroservice.DTO.User;
using UserMicroservice.DTO.User.Request;

namespace UserMicroservice.Services.Implementation {
    public class UserService : IUserService {
        public UserResponseDTO Create(CreateUserRequestDTO requestDTO) {
            // todo
            return new UserResponseDTO();
        }

        public List<UserResponseDTO> GetAll() {
            // todo
            return new List<UserResponseDTO>();
        }
        public UserResponseDTO GetOneByUuid(string uuid) {
            // todo
            throw new EntityNotFoundException($"User with uuid: {uuid} does not exist!", GeneralConsts.MICROSERVICE_NAME);
        }

        public UserResponseDTO Update(UpdateUserRequestDTO requestDTO) {
            // todo
            return new UserResponseDTO();
        }
    }
}
