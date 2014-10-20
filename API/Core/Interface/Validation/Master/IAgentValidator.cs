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
        Agent VHasNoProspects(Agent agent, IProspectService _prospectService);
        Agent VHasUniqueCode(Agent agent, IAgentService _agentService);
        Agent VHasName(Agent agent);
        Agent VHasPosition(Agent agent);
        Agent VNonNullHasDirectLeader(Agent agent, IAgentService _agentService);

        Agent VCreateObject(Agent agent, IAgentService _agentService);
        Agent VUpdateObject(Agent agent, IAgentService _agentService);
        Agent VDeleteObject(Agent agent, IProspectService _prospectService);

        bool ValidCreateObject(Agent agent, IAgentService _agentService);
        bool ValidUpdateObject(Agent agent, IAgentService _agentService);
        bool ValidDeleteObject(Agent agent, IProspectService _prospectService);
        bool isValid(Agent agent);
        string PrintError(Agent agent);
    }
}