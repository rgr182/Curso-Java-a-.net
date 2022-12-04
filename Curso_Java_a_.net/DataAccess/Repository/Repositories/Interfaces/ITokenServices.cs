using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Services;


namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{

    public interface ITokenServices
    {

        Tokens GenerateTokens();

        bool CreationDate(string tokenId);

        bool ExpirationDate(string tokenId);

       // bool kill (string tokenId);

       




    }










}
