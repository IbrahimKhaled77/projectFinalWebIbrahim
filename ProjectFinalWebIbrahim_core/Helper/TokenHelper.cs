
using Microsoft.IdentityModel.Tokens;
using ProjectFinalWebIbrahim_core.Model.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static ProjectFinalWebIbrahim_core.Helper.Enums.SystemEnums;

namespace ProjectFinalWebIbrahim_core.Helper
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(User input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("LongSecrectStringForModulekodestartppopopopsdfjnshbvhueFGDKJSFBYJDSAGVYKDSGKFUYDGASYGFskc#$vhHJVCBYHVSKDGHASVBCL");
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Email",input.Email),
                        new Claim("UserId",input.UserId.ToString()),
                        new Claim("UserType",input.UserType.ToString()),
                     
                }),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }



        public static UserType IsValidToken(string tokenString) 
        {
            String toke = "Bearer " + tokenString;
            var jwtEncodedString = toke.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            if (token.ValidTo > DateTime.UtcNow)
            {

               // int userId = int.Parse((token.Claims.First(c => c.Type == "UserId").Value.ToString()));

                UserType userType = (UserType)Enum.Parse(typeof(UserType), token.Claims.First(c => c.Type == "UserType").Value);


                return userType;
            }
            else {

                throw new Exception("token is not valid");
            
            }
            
        }
    }
}
