namespace ShopNow.Core.Contracts.Results
{
    /// <summary>
    /// Enumeration for result types
    /// </summary>
    public enum ResultTypeEnum
    {
        /// <summary>
        /// Internal server error
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// Bad request
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Unauthorized access
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Forbidden access
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// Resource not found
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Conflict in resource state
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Operation successful
        /// </summary>
        Ok = 200,

        /// <summary>
        /// Resource created successfully
        /// </summary>
        Created = 201,

        /// <summary>
        /// No content to return
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// Too many requests (rate limiting)
        /// </summary>
        TooManyRequests = 429,

        /// <summary>
        /// Service unavailable
        /// </summary>
        ServiceUnavailable = 503
    }
}