using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface.Validation;

namespace Core.Interface.Service
{
    public interface IAgentService
    {
        IAgentValidator GetValidator();
        IQueryable<Agent> GetQueryable();
        IList<Agent> GetAll();
        Agent GetObjectById(int Id);
        Agent CreateObject(Agent agent);
        Agent UpdateObject(Agent agent);
        Agent SoftDeleteObject(Agent agent, IProspectService _prospectService);
        bool DeleteObject(int Id);
        bool IsCodeDuplicated(Agent agent);
    }
}