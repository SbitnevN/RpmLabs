namespace SportRent.Core.Abstractions
{
    public struct ValidateResult
    {
        public bool IsSuccess => string.IsNullOrEmpty(Message);
        public bool IsFail => !IsSuccess;
        public string Message { get; set; }
    }
}