namespace Sofis.Api.Domain.Exceptions
{
    public class InvalidOperationException : Exception
    {
        public int ErrorCode { get; }
        public string Details { get; }
        public DateTime Timestamp { get; }

        public InvalidOperationException() : base()
        {
            Timestamp = DateTime.UtcNow;
        }

        public InvalidOperationException(string message) : base(message)
        {
            Timestamp = DateTime.UtcNow;
        }

        public InvalidOperationException(string message, Exception innerException) : base(message, innerException)
        {
            Timestamp = DateTime.UtcNow;
        }

        public InvalidOperationException(string message, int errorCode, string details = null) : base(message)
        {
            ErrorCode = errorCode;
            Details = details;
            Timestamp = DateTime.UtcNow;
        }
    }
}
// Comentario - Gabriel: Exception personalizadas para operacoes nao validas no dominio da aplicacao
