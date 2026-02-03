using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShopNow.Core.Contracts.Results;

namespace ShopNow.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected static HttpStatusCode GetStatusCode(ResultTypeEnum resultType)
        {
            HttpStatusCode statusCode;

            switch (resultType)
            {
                case ResultTypeEnum.NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ResultTypeEnum.Forbidden:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case ResultTypeEnum.Conflict:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case ResultTypeEnum.BadRequest:
                    statusCode = HttpStatusCode.NotAcceptable;
                    break;
                case ResultTypeEnum.Unauthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return statusCode;
        }

        protected IActionResult OkOrError<T>(Result<T> result)
        {
            IActionResult? errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return Ok(result.Value);
        }

        protected IActionResult OkOrError(ResultBase result)
        {
            IActionResult? errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return Ok();
        }

        private IActionResult? GetErrorResponse(ResultBase result)
        {
            if (result.IsFailure)
            {
                HttpStatusCode statusCode = GetStatusCode(result.ResultType);

                var error = new
                {
                    errorCode = result.Message,
                };

                ObjectResult errorResponse = new(error)
                {
                    StatusCode = (int)statusCode
                };

                return errorResponse;
            }

            return null;
        }
    }
}