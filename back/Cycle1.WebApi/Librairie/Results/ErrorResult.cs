namespace A3.Librairie.Results
{
    public class ErrorResult
    {
        public ErrorResult(int errorId, string message)
        {
            this.ErrorId = errorId;
            this.Message = message;
        }

        public string Message { get; }

        public int ErrorId { get; }
    }
}
