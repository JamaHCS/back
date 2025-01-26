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
            var userResult = await _userRepository.GetByIdAsync(id);

            if (!userResult.Success) return Result.Failure<GetUserDTO?>(userResult.Errors?.ToString(), null, userResult.Status);

            var userDto = _mapper.Map<GetUserDTO?>(userResult.Value);
            
            return Result.Ok(userDto, 200);
        }

        public async Task<Result> UpdateLastLoginAsync(Guid userId)
        {
            var updateResult = await _userRepository.UpdateLastLoginAsync(userId);

            return updateResult.Success
                ? Result.Ok(204)
                : Result.Failure(updateResult.Errors?.ToString(), updateResult.Status);
        }
    }
}
