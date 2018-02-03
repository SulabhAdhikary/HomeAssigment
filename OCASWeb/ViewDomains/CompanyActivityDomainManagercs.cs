using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCASWeb.PresentationValidation;


namespace OCASWeb.ViewDomains
{
    public class CompanyActivityDomainManagercs
    {

      private const string EmptyErrorSuffix = "is empty";
      private const string LengthErrorSuffix = "has exceeded its length";
      private const string InvalidDate = "is invalid date";

      private const short MaxLength = 50;
      private const short MaxLengthActivity = 5;

      public DomainResultModel ValidateCustomerModel(CompanyActivityViewDomain companyActivityModel)
      {
          var _domainResultModel = new DomainResultModel();

            if (companyActivityModel == null)
            {
              _domainResultModel.AddError(string.Format("activity model{0} ", EmptyErrorSuffix));
            }
            else
            {
              _domainResultModel.AddError(CheckString(companyActivityModel.firstName, "First Name", MaxLength));
              _domainResultModel.AddError(CheckString(companyActivityModel.lastName, "Last Name", MaxLength));
              _domainResultModel.AddError(CheckString(companyActivityModel.email, "Email", MaxLength));
              _domainResultModel.AddError(CheckString(companyActivityModel.activityId, "Activity", MaxLengthActivity));       
            }
            if (_domainResultModel.Errors.Count == 0)
            {
              _domainResultModel.AddSuccess(true);
            }
          return _domainResultModel;
      }

      private string CheckString(string text, string fieldName, short maxLength)
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

      private string CheckDate(string validationDate, string fieldName)
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
