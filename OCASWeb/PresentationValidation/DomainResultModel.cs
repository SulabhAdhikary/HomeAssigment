using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.PresentationValidation
{
    public class DomainResultModel
    {
        private object _success;
        public object Success
        {
            get
            {
                return _success;
            }
        }

        private List<string> _errors;
        public List<string> Errors { get { return _errors; } }

        public void AddSuccess(object any)
        {
            this._success = any;
        }

        public void AddError(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (this._errors == null)
            {
                this._errors = new List<string>();
            }
            this._errors.Add(text);
        }


        
    }
}
