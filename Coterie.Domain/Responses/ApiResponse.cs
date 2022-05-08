using System;

namespace Coterie.Domain.Responses
{
    public class ApiResponse<TResult>
    {
        public ApiResponse()
        {
        }

        public ApiResponse(string message, TResult result, object error)
        {
            Message = message;
            Result = result;
            Error = error;
        }

        public string Message { get; set; }
        public TResult Result { get; set; }
        public object Error { get; set; }
        public string TransactionId { get; } = Guid.NewGuid().ToString();
    }
}