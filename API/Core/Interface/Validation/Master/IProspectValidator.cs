using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IProspectValidator
    {
        Prospect VCreateObject(Prospect prospect);
        Prospect VUpdateObject(Prospect prospect);
        Prospect VDeleteObject(Prospect prospect);

        bool ValidCreateObject(Prospect prospect);
        bool ValidUpdateObject(Prospect prospect);
        bool ValidDeleteObject(Prospect prospect);
        bool isValid(Prospect prospect);
        string PrintError(Prospect prospect);
    }
}