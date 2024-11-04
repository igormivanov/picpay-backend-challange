using Microsoft.AspNetCore.Mvc;
using PicPayChallange.API.Models;
using PicPayChallange.API.Models.Dtos;

namespace PicPayChallange.API.Services {
    public interface IUserModelService {
        Task<Result<bool>> CreateUser(UserModelRequestDTO user);
    }
}
