namespace Sofis.Api.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, object key) : base($"{entityName} com chave '{key}' não foi encontrada ")
        {                             
        }
    }
}
