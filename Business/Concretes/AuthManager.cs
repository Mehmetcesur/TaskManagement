using Business.Abstracts;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Business.Dtos.Requests.UserRequest;
using Business.Messages;
using Business.Rules;
using Core.CrossCutingConcerns.Exceptions.Types;
using Core.CrossCutingConcerns.Types;
using Core.DataAccess.Paging;
using Core.Entities.Concretes;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private UserBusinessRules _userBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<AccessToken> CreateAccessToken(UserBase user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, BusinessMessages.CreatedMessage);
        }

        public async Task<IDataResult<UserBase>> Login(UserForLoginRequest userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                throw new BusinessException(BusinessMessages.EmailOrPasswordIsWrong);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new BusinessException(BusinessMessages.EmailOrPasswordIsWrong);
            }

            return new SuccessDataResult<UserBase>(userToCheck, BusinessMessages.OkayMessage);
        }

        public async Task<IDataResult<UserBase>> Register(UserForRegisterRequest userForRegisterDto, string password)
        {
            await _userBusinessRules.UserShouldNotExistsWithSameEmail(userForRegisterDto.Email);
            await _userBusinessRules.UserShouldNotExistsWithSameUsername(userForRegisterDto.Username);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new UserBase
            {
                Email = userForRegisterDto.Email,
                Username = userForRegisterDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _userService.AddAsync(user);

            var createdUser = await _userService.GetByMail(user.Email);
            if (createdUser == null)
            {
                throw new BusinessException(BusinessMessages.OccuredAnErrorDuringRegister);
            }


            var userRole = await _operationClaimService.GetListAsync(new PageRequest { PageIndex = 0, PageSize = 10 });
            var userRoleId = userRole.Items.FirstOrDefault(c => c.Name == "User")?.Id;

            if (userRoleId == null)
            {
                throw new Exception(BusinessMessages.UserRoleNotFound);
            }

            var createUserOperationClaimRequest = new CreateUserOperationClaimRequest
            {
                UserId = createdUser.Id,
                OperationClaimId = userRoleId.Value
            };

            await _userOperationClaimService.AddAsync(createUserOperationClaimRequest);

            return new SuccessDataResult<UserBase>(user, BusinessMessages.OkayMessage);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(BusinessMessages.UserIsAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
