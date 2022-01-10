namespace A3.Librairie.Results
{
    public class Result
    {
        private List<ErrorResult>? _errors;

        public bool IsValid
        {
            get
            {
                return this._errors == null || !this._errors.Any();
            }
        }

        protected void InternalMerge(Result resultat)
        {
            if (resultat != null && resultat._errors != null)
            {
                if (this._errors == null)
                {
                    this._errors = new List<ErrorResult>(resultat._errors.Count);
                }
                this._errors.AddRange(resultat._errors);
            }
        }

        public Result Merge(params Result[] results)
        {
            foreach (Result result in results)
            {
                this.InternalMerge(result);
            }
            return this;
        }

        public Result AddError(int errorId, string message)
        {
            if (this._errors == null)
            {
                this._errors = new List<ErrorResult>();
            }
            this._errors.Add(new ErrorResult(errorId, message));
            return this;
        }
    }

    public sealed class Result<T> : Result
    {
        public T? Value { get; set; }

        public new Result<T> Merge(params Result[] results)
        {
            foreach (Result result in results)
            {
                this.InternalMerge(result);
            }
            return this;
        }
    }
}