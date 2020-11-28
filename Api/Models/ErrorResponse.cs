using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Api.Models
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }

        internal static ErrorResponse From(System.Exception e)
        {
            if (e == null)
            {
                return null;
            }
            return new ErrorResponse
            {
                Code = e.HResult,
                Message = e.Message,
                InnerError = ErrorResponse.From(e.InnerException)

            };

        }

        internal static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            return new ErrorResponse
            {
                Code = 100,
                Message = "Houve erro(s) no envio da requisição.",
                Details = erros.Select(e => e.ErrorMessage).ToArray()
            };

        }
    }
}
