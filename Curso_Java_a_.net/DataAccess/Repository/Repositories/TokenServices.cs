using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Microsoft.CodeAnalysis;
using System.Data.Entity;
using Microsoft.Extensions.Options;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class TokenServices : Interfaces.ITokenServices
    {
        public Microsoft.EntityFrameworkCore.DbContextOptions<SchoolSystemTestContext> options;

        public Tokens GenerateToken()
        {
            SchoolSystemTestContext schoolSystemTestContext = new SchoolSystemTestContext(options);
            string token = Guid.NewGuid().ToString();   
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddDays(1);
            var tokenDomain = new Tokens
            {
                
                RealToken = token,
                CreationDate = issuedOn,
                ExpiresDate = expiredOn
            };
            schoolSystemTestContext.Tokens.Add(tokenDomain);
            schoolSystemTestContext.SaveChanges();
            return tokenDomain;
        }

        public bool ValidateToken(string tokenId)
        {
            SchoolSystemTestContext schoolSystemTestContext = new SchoolSystemTestContext(options);
            var token = schoolSystemTestContext.Tokens.FirstOrDefault(x => x.ExpiresDate > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresDate))
            {
                token.ExpiresDate = DateTime.Now.AddDays(1);
                schoolSystemTestContext.Entry(token).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                schoolSystemTestContext.SaveChanges();
                return true;
            }
            return false;
        }

        bool Interfaces.ITokenServices.CreationDate(string tokenId)
        {
            throw new NotImplementedException();
        }

        bool Interfaces.ITokenServices.ExpirationDate(string tokenId)
        {
            throw new NotImplementedException();
        }

        Tokens Interfaces.ITokenServices.GenerateTokens()
        {
            throw new NotImplementedException();
        }
    }
 }   
    