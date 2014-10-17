using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IProspectDetailValidator
    {
        ProspectDetail VCreateObject(ProspectDetail prospectDetail);
        ProspectDetail VUpdateObject(ProspectDetail prospectDetail);
        ProspectDetail VDeleteObject(ProspectDetail prospectDetail);

        bool ValidCreateObject(ProspectDetail prospectDetail);
        bool ValidUpdateObject(ProspectDetail prospectDetail);
        bool ValidDeleteObject(ProspectDetail prospectDetail);
        bool isValid(ProspectDetail prospectDetail);
        string PrintError(ProspectDetail prospectDetail);
    }
}