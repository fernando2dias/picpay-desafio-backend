using PicPaySimplificado.Domain.Enums;
using PicPaySimplificado.Domain.Exceptions;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace PicPaySimplificado.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public UserType Type { get; private set; }
        public Wallet Wallet { get; private set; }
        protected User() { }
        private User(
            string fullName,
            string document,
            string email,
            UserType type)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Document = document;
            Email = email;
            Type = type;
            Wallet = new Wallet(Id);
        }

        public static User Create(
            string fullName,
            string document,
            string email,
            UserType type)
        {
            // Validações podem ser adicionadas aqui
            Validate(fullName, document, email);

            return new User(fullName, document, email, type);

        }

        private static void Validate(
            string fullName,
            string document,
            string email)
        {
            if (string.IsNullOrWhiteSpace(fullName)) { 
                throw new DomainException("O nome completo é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(document))
            {
                throw new DomainException("Documento é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("Email é obrigatório");
            }
        }

        public bool IsStore() => Type == UserType.Store;
    }
}
