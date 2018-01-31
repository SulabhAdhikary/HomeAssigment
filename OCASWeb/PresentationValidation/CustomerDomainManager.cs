using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Models;

////https://codereview.stackexchange.com/questions/135945/validation-that-also-returns-error-messages
namespace TestWebApplication.PresentationValidation

{
    public class CustomerDomainManager
    {

        private const string EmptyErrorSuffix = "is empty";
        private const string LengthErrorSuffix = "has exceeded its length";
        private const string InvalidDate = "is invalid date";
        private const short MaxCountryLength = 3;
        private const short MaxProvinceLength = 2;
        private const short MaxCustomerLength = 50;


        public DomainResultModel ValidateCustomerModel(CustomerDomainModel customerModel)
        {
            var _domainResultModel = new DomainResultModel();

            if (customerModel == null)
            {
                _domainResultModel.AddError(string.Format("Customer model{0} ", EmptyErrorSuffix));
            }
            else
            {
                _domainResultModel.AddError(CheckString(customerModel.CustomerName, "Customer Name", MaxCustomerLength));
                _domainResultModel.AddError(CheckString(customerModel.Country, "Country", MaxCountryLength));
                _domainResultModel.AddError(CheckDate(customerModel.ValidationDate, "Date"));
            }
            return _domainResultModel;
        }

        private string CheckString(string text,string fieldName,short maxLength)
        {
            string errorText = string.Empty;
            if (string.IsNullOrEmpty(text))
            {
                errorText = string.Format("{0} {1}", fieldName, EmptyErrorSuffix);
            }
            else
            {
                if (text.Length > maxLength)
                {
                    errorText = string.Format("{0} as {1} with length {2}", text, fieldName, LengthErrorSuffix);
                }
            }

            return errorText;
        }

        private string CheckDate(string  validationDate,string fieldName)
        {
            string errorText = string.Empty;
            if (string.IsNullOrEmpty(validationDate))
            {
                errorText = string.Format("{0} {1}", fieldName, InvalidDate);
            }
            else
            {
                DateTime value;
                if (!DateTime.TryParse(validationDate, out value))
                {
                    errorText = string.Format("{0} {1} {2}", validationDate, fieldName, InvalidDate);
                }
                else if (value > DateTime.Today)
                {
                    errorText = string.Format("{0} {1} {2}", validationDate, fieldName, InvalidDate);
                }
            }

            return errorText;

        }



    }
}
