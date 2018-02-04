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
     
        private Dictionary<string,string> _errors;
        public Dictionary<string, string> Errors { get { return _errors; } }

        public void AddSuccess(bool any)
        {
            this._success = any;
        }

        public void AddError(string control,string Errormessagetext)
        {
            if (string.IsNullOrEmpty(Errormessagetext))
            {
                return;
            }
            if (this._errors == null)
            {
                this._errors = new Dictionary<string, string>();
            }
            this._errors.Add(control, Errormessagetext);
        }


        
    }
}
