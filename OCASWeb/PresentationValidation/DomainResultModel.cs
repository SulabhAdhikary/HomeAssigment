using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCASWeb.PresentationValidation
{
    public class DomainResultModel
    {
        private bool _success;
        public bool Success
        {
            get
            {
                return _success;
            }
        }
     
        private List<string> _errors;
        public List<string> Errors { get { return _errors; } }

        public void AddSuccess(bool any)
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
