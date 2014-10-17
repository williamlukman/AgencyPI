using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interface.Repository
{
    public interface IProspectAgentMutationRepository : IRepository<ProspectAgentMutation>
    {
        IQueryable<ProspectAgentMutation> GetQueryable();
        IList<ProspectAgentMutation> GetAll();
        IList<ProspectAgentMutation> GetAllByMonthCreated();
        ProspectAgentMutation GetObjectById(int Id);
        ProspectAgentMutation CreateObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation UpdateObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation SoftDeleteObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation ConfirmObject(ProspectAgentMutation prospectAgentMutation);
        ProspectAgentMutation UnconfirmObject(ProspectAgentMutation prospectAgentMutation);
        bool DeleteObject(int Id);
        string SetObjectCode();
    }
}