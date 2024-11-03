using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public interface IUserModelRepository {

        Task Create(UserModel user);

        Task<UserModel> findById(Guid id);
    }
}
