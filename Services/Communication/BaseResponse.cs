namespace freecodecampapi.Services.Communication
{
    public abstract class BaseResponse
    {
        public BaseResponse(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
        }

        public bool Success { get; protected set; }
        public string Message { get; protected set; }
    }
}