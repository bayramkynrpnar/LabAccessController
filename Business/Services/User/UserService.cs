using Data.Model;
using DataAcces.Context;
using DataAcces.Uow;
using Dto.User;
using SkiLabUtils.TokenFactory;

namespace Services.User
{
    public class UserService : IUserService
    {
        public int AddUser(AddUserDto addUser)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var userModel = new UserModel();
                userModel.Name = addUser.Name;
                userModel.Surname = addUser.Surname;
                userModel.Email = addUser.EMail;
                userModel.Phone = addUser.Phone;
                userModel.Password = addUser.Pass;
                userModel.UserType = 0;
                userModel.AppRegisterToken = JWTTokenFactory.Instance.CreateToken(userModel);

                uow.GetRepository<UserModel>().Add(userModel);

                return uow.SaveChanges();
            }
        }


        public int DeleteUser(int userId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var user = uow.GetRepository<UserModel>().Get(x => x.Id == userId);
                uow.GetRepository<UserModel>().Delete(user);
                return uow.SaveChanges();
            }
        }


        public List<UserModel> GetAllUser()
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var userList = uow.GetRepository<UserModel>().GetAll().ToList();
                return userList;
            }
        }


        public UserModel GetUser(int userId)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var user = uow.GetRepository<UserModel>().Get(x => x.Id == userId);
                return user;
            }
        }

        public bool IsExistsUser(string phoneNumber)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                return true; /*uow.GetRepository<UserModel>().Any(x => x.Phone.Equals(phoneNumber));*/
            }
        }

        public int UpdateUser(UpdateUserDto updateUser)
        {
            using (var uow = new UnitOfWork<PostgresContext>())
            {
                var user = uow.GetRepository<UserModel>().Get(x => x.Id == updateUser.UserId);
                user.Name = updateUser.Name;
                user.Surname = updateUser.Surname;

                return uow.SaveChanges();
            }
        }
    }
}