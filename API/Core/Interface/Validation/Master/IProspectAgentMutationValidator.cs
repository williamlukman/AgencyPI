using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Validation
{
    public interface IProspectAgentMutationValidator
    {
        ProspectAgentMutation VCreateObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation VUpdateObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation VDeleteObject(ProspectAgentMutation prospectAgentMutation);

        bool ValidCreateObject(ProspectAgentMutation prospectAgentMutation);
        bool ValidUpdateObject(ProspectAgentMutation prospectAgentMutation);
        bool ValidDeleteObject(ProspectAgentMutation prospectAgentMutation);
        bool isValid(ProspectAgentMutation prospectAgentMutation);
        string PrintError(ProspectAgentMutation prospectAgentMutation);
    }
}