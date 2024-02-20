

using Enums;

namespace Dto.User
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? AppRegisterToken { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
