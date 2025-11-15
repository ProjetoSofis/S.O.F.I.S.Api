using Sofis.Api.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Sofis.Api.Application.Services
{
    public class PasswordService : IPasswordService
    {
        private const int KeySize = 64; // 512 bits
        private const int Iterations = 350000; // Número de iterações para PBKDF2
        private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Senha não pode ser nula ou vazia.", nameof(password));
            }
            // Vinicius: Gera um salt aleatório para a senha
            passwordSalt = RandomNumberGenerator.GetBytes(KeySize);
            // Vinicius: Gera o hash da senha usando PBKDF2 com o salt gerado
            passwordHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                passwordSalt,
                Iterations,
                _hashAlgorithm,
                KeySize
            );
        }

        public bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Senha não pode ser nula ou vazia.", nameof(password));
            }
            // Gera o hash da senha fornecida usando o salt armazenado
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                passwordSalt,
                Iterations,
                _hashAlgorithm,
                KeySize
            );

            // Compara o hash gerado com o hash armazenado
            return CryptographicOperations.FixedTimeEquals(hashToCompare, passwordHash);
        }
    }
}
