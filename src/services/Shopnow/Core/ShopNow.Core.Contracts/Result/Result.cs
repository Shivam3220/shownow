namespace ShopNow.Core.Contracts.Results
{

    /// <summary>
    /// Standard result class to represent success or failure of an operation
    /// </summary>
    public class Result : ResultBase
    {

        /// <summary>
        /// Protected constructor to initialize the result
        /// </summary>
        /// <param name="resultType"></param>
        /// <param name="isFailure"></param>
        /// <param name="message"></param>
        protected Result(ResultTypeEnum resultType, bool isFailure, string? message = null) : base(resultType, isFailure, message)
        {
        }

        /// <summary>
        /// Creates a successful result
        /// </summary>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result(resultType: ResultTypeEnum.Ok, isFailure: false);
        }

        /// <summary>
        /// Creates a successful result with a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value: value);
        }

        /// <summary>
        /// Creates a failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Failure(string message)
        {
            return new Result(resultType: ResultTypeEnum.InternalServerError, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> Failure<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.InternalServerError, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a created result
        /// </summary>
        /// <returns></returns>
        public static Result Created()
        {
            return new Result(resultType: ResultTypeEnum.Created, isFailure: false);
        }

        /// <summary>
        /// Creates a created result with a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result<T> Created<T>(T value)
        {
            return new Result<T>(value: value);
        }

        /// <summary>
        /// Creates a not found failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result NotFound(string message)
        {
            return new Result(resultType: ResultTypeEnum.NotFound, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a not found failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> NotFound<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.NotFound, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a no content result
        /// </summary>
        /// <returns></returns>
        public static Result NoContent(string message)
        {
            return new Result(resultType: ResultTypeEnum.NoContent, isFailure: false, message: message);
        }

        /// <summary>
        /// Creates a no content result with a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Result<T> NoContent<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.NoContent, isFailure: false, message: message);
        }

        /// <summary>
        /// Creates a bad request failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result BadRequest(string message)
        {
            return new Result(resultType: ResultTypeEnum.BadRequest, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a bad request failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> BadRequest<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.BadRequest, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates an unauthorized failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Unauthorized(string message)
        {
            return new Result(resultType: ResultTypeEnum.Unauthorized, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates an unauthorized failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> Unauthorized<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.Unauthorized, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a forbidden failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Forbidden(string message)
        {
            return new Result(resultType: ResultTypeEnum.Forbidden, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a forbidden failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> Forbidden<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.Forbidden, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a conflict failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Conflict(string message)
        {
            return new Result(resultType: ResultTypeEnum.Conflict, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a conflict failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> Conflict<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.Conflict, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a no content result
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result TooManyRequests(string message)
        {
            return new Result(resultType: ResultTypeEnum.TooManyRequests, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a no content result with a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> TooManyRequests<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.TooManyRequests, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a service unavailable failure result with a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result ServiceUnavailable(string message)
        {
            return new Result(resultType: ResultTypeEnum.ServiceUnavailable, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a service unavailable failure result with a message and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> ServiceUnavailable<T>(string message)
        {
            return new Result<T>(resultType: ResultTypeEnum.ServiceUnavailable, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a failure result with a specific result type and a message
        /// </summary>
        /// <param name="resultType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result FromError(ResultTypeEnum resultType, string message)
        {
            return new Result(resultType: resultType, isFailure: true, message: message);
        }

        /// <summary>
        /// Creates a failure result with a specific result type and a value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Result<T> FromError<T>(ResultBase result)
        {
            return new Result<T>(resultType: result.ResultType, isFailure: result.IsFailure, message: result.Message);
        }

    }

    public class Result<T> : ResultBase
    {
        /// <summary>
        /// Contain the actual data for the result is the result is ok
        /// </summary>
        public T Value { get; }

        internal Result(ResultTypeEnum resultType, bool isFailure, string? message = null) : base(resultType, isFailure, message)
        {
            Value = default!;
        }

        internal Result(T value) : base(resultType: ResultTypeEnum.Ok, isFailure: false, null)
        {
            Value = value;
        }

    }
}