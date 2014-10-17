using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IAgentValidator
    {
        Agent VCreateObject(Agent agent);
        Agent VUpdateObject(Agent agent);
        Agent VDeleteObject(Agent agent);

        bool ValidCreateObject(Agent agent);
        bool ValidUpdateObject(Agent agent);
        bool ValidDeleteObject(Agent agent);
        bool isValid(Agent agent);
        string PrintError(Agent agent);
    }
}