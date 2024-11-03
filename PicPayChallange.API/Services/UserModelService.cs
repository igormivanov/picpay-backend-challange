using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PicPayChallange.API.Models;
using PicPayChallange.API.Models.Dtos;
using PicPayChallange.API.Repositories;

namespace PicPayChallange.API.Services {
    public class UserModelService : IUserModelService {

        private readonly IUserModelRepository _userModelRepository;

        public UserModelService(IUserModelRepository userModelRepository) {
            _userModelRepository = userModelRepository;
        }

        public async Task CreateUser(UserModelRequestDTO user) { 
           

            var userModel = new UserModel {
                Id = Guid.NewGuid(),
                CPF = user.CPF,
                Email = user.Email,
                FullName = user.FullName,
                Password = user.Password,
                UserType = user.UserType, 
                Balance = user.Balance,
            };

            await _userModelRepository.Create(userModel);
        }
    }
}
