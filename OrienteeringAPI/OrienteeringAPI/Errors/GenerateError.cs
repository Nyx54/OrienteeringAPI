using Microsoft.AspNetCore.Http;
using OrienteeringModels.Dtos;
using System.Collections.Generic;
using System.Text;

namespace OrienteeringAPI.Errors
{
    public static class GenerateError
    {
        public static ErrorModel BadRequestError(List<string> missingsParams)
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.Append(ErrorConstants._BadRequestErrorMessage);
            messageBuilder.Append(string.Join(", ", missingsParams));
            var badRequestError = new ErrorModel()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = messageBuilder.ToString(),
                IsCustomException = true
            };
            return badRequestError;
        }

        public static ErrorModel LoginError()
        {
            var loginError = new ErrorModel()
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Message = ErrorConstants._UnauthorizeErrorMessage,
                IsCustomException = true
            };
            return loginError;
        }

        public static ErrorModel ObjectNotFound<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            var notFoundError = new ErrorModel()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = string.Format(ErrorConstants._NotFoundErrorMessage, type.Name),
                IsCustomException = true
            };
            return notFoundError;
        }

        public static ErrorModel UnexpectedError()
        {
            var unexpectedError = new ErrorModel()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = ErrorConstants._UnexpectedErrorMessage,
                IsCustomException = true
            };
            return unexpectedError;
        }
    }
}
