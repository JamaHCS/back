using AutoMapper;
using Domain.DTO.Users;
using Domain.Entities.Global;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result<GetUserDTO?>> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null) return Result.Failure<GetUserDTO?>("El usuario no fue encontrado", null, 404);
            else return Result.Ok<GetUserDTO?>(_mapper.Map<GetUserDTO>(user), 200);
        }
    }
}
