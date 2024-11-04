using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public interface IUserModelRepository {

        Task Create(UserModel user);

        Task<UserModel> FindById(Guid id);
        Task Update(UserModel user);
    }
}
