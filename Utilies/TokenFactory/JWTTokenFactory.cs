using Data.Model;
using Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkiLabUtils.TokenFactory
{
    public class JWTTokenFactory
    {
        #region Singletion

        private static readonly Lazy<JWTTokenFactory> _instance = new Lazy<JWTTokenFactory>(() => new JWTTokenFactory());
        private JWTTokenFactory()
        {
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        public static JWTTokenFactory Instance = _instance.Value;

        #endregion

        #region Members
        private string issuer
        {
            get
            {
                return Environment.GetEnvironmentVariable("TOKEN_ISSUER");
            }
        }

        private string _key
        {
            get
            {
                return Environment.GetEnvironmentVariable("TOKEN_SECURITY_KEY");
            }
        }

        private SymmetricSecurityKey securityKey;
        private SigningCredentials signingCredentials;

        #endregion

        #region Methods

        /// <summary>
        /// token oluşturur
        /// </summary>
        /// <param name="user">kullanıcı bilgilerini alır</param>
        /// <returns>token verisi döner geriye</returns>
        public string CreateToken(UserModel userDto)
        {
            Claim[] claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Typ, "Bearer"),
                new Claim("name",$"{userDto.Name} {userDto.Surname}"),
                new Claim("usertype", userDto.UserType.ToString())
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                expires: DateTime.Now.AddDays(365),
                claims: claim,
                signingCredentials: signingCredentials);
            //JWT Güvenlik Belirteç token'i işlemek için
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        /// <summary>
        /// Token doğrular
        /// </summary>
        /// <param name="token">token alır</param>
        /// <returns>boolena değer döner</returns>
        public UserTypeEnum? IsTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.FromDays(365)
                }, out SecurityToken validatedToken);

                UserTypeEnum userTypeEnum = Enum.Parse<UserTypeEnum>(claims.Claims.Where(x => x.Type.Equals("usertype")).FirstOrDefault().Value);
                return userTypeEnum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
