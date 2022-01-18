namespace A3.Library.Results
{
    /// <summary>
    /// Classe représentant le résultat de l'execution d'un traitement
    /// </summary>
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
                    this._errors = new List<ErrorResult>();
                }
                this._errors.AddRange(resultat._errors);
            }
        }

        public IEnumerable<ErrorResult> GetErrors()
        {
            if (this._errors != null)
            {
                return this._errors;
            }
            return new List<ErrorResult>(0);
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

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Result<T> : Result
    {
        public T? Value { get; set; }

        public new Result<T> AddError(int errorId, string message)
        {
            _ = base.AddError(errorId, message);
            return this;
        }

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