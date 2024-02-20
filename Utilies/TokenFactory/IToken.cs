using Data.Model;
namespace SkiLabUtils.TokenFactory
{
    public interface IToken
    {
        public string CreateToken(UserModel userModel);
        public bool IsTokenValid(string token);
    }
}
