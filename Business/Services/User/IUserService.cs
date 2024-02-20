using Data.Model;
using Dto.User;

namespace Services.User
{
    public interface IUserService
    {
        public int AddUser(AddUserDto addUser);
        public int UpdateUser(UpdateUserDto updateUser);
        public int DeleteUser(int userId);
        public UserModel GetUser(int userId);
        public List<UserModel> GetAllUser();
        public bool IsExistsUser(string phoneNumber);
    }
}
