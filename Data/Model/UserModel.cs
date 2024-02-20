using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class UserModel : BaseEntity
    {
        public string Name { get; set; } = " ";
        public string Surname { get; set; } = " ";
        public string Email { get; set; } = " ";
        public string Password { get; set; } = " ";
        public string Phone { get; set; } = " ";
        public string Number { get; set; } = " ";
        public string AppRegisterToken { get; set; } = " ";
        public UserTypeEnum UserType { get; set; } = 0;
    }
}
