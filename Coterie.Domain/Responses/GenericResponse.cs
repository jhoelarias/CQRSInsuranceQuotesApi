namespace Coterie.Domain.Responses
{
    using System;

    public class GenericResponse<TResult>
    {
        public GenericResponse()
        {
        }

        public GenericResponse(string message, TResult result, object error)
        {
            Message = message;
            Result = result;
            Error = error;
        }

        public string Message { get; init; }
        public TResult Result { get; init; }
        public object Error { get; init; }
        public string TransactionId { get; } = Guid.NewGuid().ToString();
    }
}