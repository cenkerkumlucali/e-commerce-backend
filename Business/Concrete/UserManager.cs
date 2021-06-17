using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<UserDetailDto>> GetUsersDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IDataResult<List<UserDetailDto>> GetUserDetailsById(int userId)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(c => c.UserId == userId));
        }


        [CacheAspect]
        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return new List<OperationClaim>(_userDal.GetClaims(user));
        }
        [CacheAspect]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        public async Task<IResult> Add(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [CacheRemoveAspect("IUserService.Get")]
        public IResult EditProfil(User user)
        {
            var updatedUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            };
            _userDal.UpdateAsync(updatedUser);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult EditPassword(UserForUpdateDto userForUpdateDto, string newPassword, string newPasswordVerify)
        {
            byte[] passwordHash, passwordSalt;
            IResult result = BusinessRules.Run(CheckPasswordTheSame(newPassword, newPasswordVerify),CheckIsOldPasswordCorrect(userForUpdateDto));
            if (result != null)
            {
                return result;
            }
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            var updatePassword = new User
            {
                Id = userForUpdateDto.User.Id,
                Email = userForUpdateDto.User.Email,
                FirstName = userForUpdateDto.User.FirstName,
                LastName = userForUpdateDto.User.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForUpdateDto.User.Status
            };
            _userDal.UpdateAsync(updatePassword);
            return new SuccessResult(Messages.UserUpdated);
        }


        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(b => b.Id == id));
        }


        public IResult Delete(User user)
        {
            _userDal.DeleteAsync(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IDataResult<User> GetUserByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        private IResult CheckIsOldPasswordCorrect(UserForUpdateDto userForUpdateDto)
        {
            var userToCheck = this.GetByMail(userForUpdateDto.User.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForUpdateDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.OldPasswordWrong);
            }

            return new SuccessResult();
        }
        private IResult CheckPasswordTheSame(string newPassword, string newPasswordVerify)
        {
            var result = newPassword == newPasswordVerify;
            if (!result)
            {
                return new ErrorResult("Şifreler aynı değil");
            }
            return new SuccessResult();
        }
    }
}