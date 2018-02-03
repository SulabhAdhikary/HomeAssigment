using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCASWeb.PresentationValidation
{
    public interface Ivalidate
    {
         DomainResultModel IsObjectValid();
    }
}
