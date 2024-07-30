

using Enums;

namespace Dto.User
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Pass { get; set; }
        public int Number { get; set; }
        public string Phone { get; set; }
    }
}
