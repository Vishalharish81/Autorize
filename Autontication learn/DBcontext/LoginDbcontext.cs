using Autontication_learn.InputModel;
using Autontication_learn.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Autontication_learn.DBcontext
{
    public class LoginDbcontext : Login
    {
        private readonly IConfiguration _logger;
        private readonly IDbConnection _db;
        public IDbTransaction DbTransaction { get; set; }

        public LoginDbcontext(IConfiguration configuration, IDbConnection db)
        {
            _logger = configuration;
            _db = db;
        }


        

        public List<Https> Https()
        {
            string sql = @"select plantcode,status from wm_shipmentheader";

            var result = _db.Query<Https>(sql, new {  }, transaction: DbTransaction).ToList();
            return result;
        }

        public LoginOutputdatacs Login(LoginInputModel LoginInputModel)
        {
            var res = new  LoginOutputdatacs();
            if (LoginInputModel.Email == "Vishal" && LoginInputModel.Password =="Vishal")
            {
                res.Status = "Success";
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                                  {
                                  new Claim("sub", LoginInputModel.Email),
                                  new Claim("SGID",LoginInputModel.Email),
                                  new Claim("MailID",LoginInputModel.Email),
                                  new Claim("Username",LoginInputModel.Email)
                                  }),
                    IssuedAt = DateTime.UtcNow,
                    Issuer = LoginInputModel.Email,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_logger["JwtSettings:SecretKey"])),
                    SecurityAlgorithms.HmacSha256Signature)

                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                string token = tokenHandler.WriteToken(securityToken);
                res.BearerToken = token;
                res.UserName  = LoginInputModel.Password;
                res.Email = LoginInputModel.Password;
                return res;


            }
            else
            {
                res.Status = "Failure";

            }
            return res;


        }
        

        public string delegat(int x, int y)
        {
            CalculateDelegae calculateDelegae ;

            int result  = calculator.sub(x,y);
            string res= result.ToString();
            return "a delegeta is resuable and more flexible in the code , code clean and startagy pattern and it will be use for function point and avoid also if else control statement";
        }

        public string structkey(int x, int y)
        {
            authorixd authorixd = new authorixd();

            return "Stored on stack (usually) , Cannot inherit from another struct or class";

        }
        

        public string abstractc(int x, int y)
        {
            circle circle = new circle();
            circle.i = 10;
            circle.Y = 10;
            circle.b = 10;


            return "Stored on stack (usually) , Cannot inherit from another struct or class";

        }

        public decimal ApplyDiscount(decimal price)
        {
            IDiscountStrategy discountStrategy = new TenPercentDiscount();
            decimal result = discountStrategy.ApplyDiscount(price);
            return result;

        }

        public interface IDiscountStrategy
        {
            decimal ApplyDiscount(decimal price);
        }


        public class TenPercentDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price)
            {
                return price * 5;
            }
        }

        // 20% discount
        public class TwentyPercentDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price)
            {
                return price * 0.8m;
            }
        }

        // No discount
        public class NoDiscount : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price)
            {
                return price;
            }
        }

    }
}
