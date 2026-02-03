namespace ShopNow.Core.Contracts.Results
{
    public class ResultBase
    {
        public bool IsFailure { get; }

        public string? Message { get; }

        public bool IsSuccess => !IsFailure;

        /// <summary>
        /// Type of the result shown as enumeration
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ResultTypeEnum ResultType { get; }

        public bool IsNotFound => ResultType == ResultTypeEnum.NotFound;

        protected ResultBase(ResultTypeEnum resultType, bool isFailure, string? message)
        {
            if (isFailure)
            {
                if (string.IsNullOrEmpty(message))
                {
                    throw new ArgumentException($"{nameof(ResultBase)} with failure can not have null or empty {nameof(message)}");
                }

                if (resultType == ResultTypeEnum.Ok)
                {
                    throw new ArgumentException("There should be error type for failure.", nameof(resultType));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(message))
                {
                    throw new ArgumentException($"{nameof(message)} should not be provided for success result");
                }

                if (resultType != ResultTypeEnum.Ok)
                {
                    throw new ArgumentException("There should be no error type for success.", nameof(resultType));
                }
            }

            IsFailure = isFailure;
            Message = message;
            ResultType = resultType;
        }
    }
}