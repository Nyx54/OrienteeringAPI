using Microsoft.AspNetCore.Http;
using OrienteeringModels.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrienteeringAPI.Errors
{
    public static class LogApiGenerator
    {
        public static LogAPI UpdateResponseLog(ref LogAPI log, object responseObject, string exceptionMessage = null)
        {
            StringBuilder ResponseBody = new StringBuilder($"{{{Environment.NewLine}");

            var objectType = responseObject.GetType();
            if (responseObject is IList && objectType.IsGenericType && objectType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                Type elementType = objectType.GenericTypeArguments.Single();
                var count = ((IList)responseObject).Count;
                ResponseBody.Append($"List of {elementType}{Environment.NewLine}");
                ResponseBody.Append($"Number of elements: {count}");
                ResponseBody.Append($"{Environment.NewLine}}}");
            }
            else
            {
                objectType.GetProperties().ToList().ForEach(p =>
                ResponseBody.Append($"{p.Name}: {p.GetValue(responseObject)}{Environment.NewLine}"));
                ResponseBody.Append($"{Environment.NewLine}}}");
            }

            log.Response = ResponseBody.ToString();
            if (responseObject != null && responseObject is ErrorModel)
            {
                log.StatusCode = ((ErrorModel)responseObject).StatusCode;
            }
            else
            {
                log.StatusCode = StatusCodes.Status200OK;
            }
            log.RespondedOn = DateTime.Now;

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                log.Exception = exceptionMessage;
            }

            return log;
        }

        public static LogAPI CreateRequestLog(HttpRequest request, object requestBody = null)
        {
            try
            {
                var log = new LogAPI
                {
                    Path = request.Path,
                    Method = request.Method,
                    QueryString = request.QueryString.ToString()
                };

                if (requestBody != null)
                {
                    StringBuilder listOfProperties = new StringBuilder($"{{{Environment.NewLine}");

                    requestBody.GetType().GetProperties().ToList().ForEach(p =>
                    listOfProperties.Append($"{p.Name}: {p.GetValue(requestBody)}{Environment.NewLine}"));
                    listOfProperties.Append($"{Environment.NewLine}}}");

                    log.Body = listOfProperties.ToString();
                }
                log.RequestedOn = DateTime.Now;
                return log;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
