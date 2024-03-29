﻿using Core.entities.Concrete;
using Core.extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accesTokenExpireDate;
        public JwtHelper(IConfiguration _configuration)
        {
            configuration = _configuration;
            // _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();// Extensiond.configration.binder kurulmalı !!
        }



        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims, int companyid, string companyName)
        {
            _accesTokenExpireDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpireDate);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signinCredentials = SigningCredentialsHelper.CreateSigningCredential(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signinCredentials, operationClaims, companyid, companyName);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accesTokenExpireDate,
                Companyid = companyid
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials,
                List<OperationClaim> operationClaims, int companyid,string companyName)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(SetClaims(user, operationClaims, companyid, companyName));
            var securityTokenDescriptor =  new SecurityTokenDescriptor()
            {
                Issuer = tokenOptions.Issuer,
                Audience = tokenOptions.Audience,
                SigningCredentials = signingCredentials,
                Expires = _accesTokenExpireDate,
                NotBefore = DateTime.Now,
                Subject = claimsIdentity
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt2 = jwtSecurityTokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);
            /*
            var jwt = new JwtSecurityToken(issuer: tokenOptions.Issuer, audience: tokenOptions.Audience, expires: _accesTokenExpireDate,
                                           notBefore: DateTime.Now, claims: SetClaims(user, operationClaims, companyid),
                                           signingCredentials: signingCredentials
                                         );*/

            return jwt2;

        }
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims, int companyId,string companyName)
        {
             


            var claims = new List<Claim>();
            //claims.AddNameIdentifier(user.Id.ToString());
            // claims.AddEmail(user.Email);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Anonymous, companyId.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Country, companyName));
            claims.AddName($"{user.Name}");

            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            //claims.AddCompany(companyId.ToString());
            return claims;

        }
    }
}
