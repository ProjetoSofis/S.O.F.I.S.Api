namespace Sofis.Api.Application.Interfaces
{
    public interface IPasswordService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
