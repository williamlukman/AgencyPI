using Core.DomainModel;
using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validation.Validation
{
    public class ProspectValidator : IProspectValidator
    {
        public Prospect VHasAgent(Prospect prospect, IAgentService _agentService)
        {
            Agent agent = _agentService.GetObjectById(prospect.AgentId);
            if (agent == null)
            {
                prospect.Errors.Add("AgentId", "Tidak terasosiasi dengan agent");
            }
            return prospect;
        }

        public Prospect VHasNoOutstandingProspectDetail(Prospect prospect, IProspectDetailService _prospectDetailService)
        {
            IList<ProspectDetail> prospectDetails = _prospectDetailService.GetQueryable().Where(x => x.ProspectId == prospect.Id && !x.IsCompleted && !x.IsDeleted).ToList();
            if (prospectDetails.Any())
            {
                prospect.Errors.Add("Generic", "Masih ada outstanding detail yang belum complete");
            }
            return prospect;
        }

        public Prospect VHasNoProspectAgentMutation(Prospect prospect, IProspectAgentMutationService _prospectAgentMutationService)
        {
            IList<ProspectAgentMutation> prospectAgentMutations = _prospectAgentMutationService.GetObjectsByProspectId(prospect.Id);
            if (prospectAgentMutations.Any())
            {
                prospect.Errors.Add("Generic", "Sudah ada informasi bahwa prospect tersebut dimutasikan sebagai agen");
            }
            return prospect;
        }

        public Prospect VCreateObject(Prospect prospect, IAgentService _agentService)
        {
            VHasAgent(prospect, _agentService);
            if (!isValid(prospect)) { return prospect; }
            return prospect;
        }

        public Prospect VUpdateObject(Prospect prospect, IAgentService _agentService)
        {
            return VCreateObject(prospect, _agentService);
        }

        public Prospect VDeleteObject(Prospect prospect, IProspectService _prospectService, IProspectDetailService _prospectDetailService,
                                      IProspectAgentMutationService _prospectAgentMutationService)
        {
            VHasNoOutstandingProspectDetail(prospect, _prospectDetailService);
            if (!isValid(prospect)) { return prospect; }
            VHasNoProspectAgentMutation(prospect, _prospectAgentMutationService);
            return prospect;
        }

        public bool ValidCreateObject(Prospect prospect, IAgentService _agentService)
        {
            VCreateObject(prospect, _agentService);
            return isValid(prospect);
        }

        public bool ValidUpdateObject(Prospect prospect, IAgentService _agentService)
        {
            prospect.Errors.Clear();
            VUpdateObject(prospect, _agentService);
            return isValid(prospect);
        }

        public bool ValidDeleteObject(Prospect prospect, IProspectService _prospectService, IProspectDetailService _prospectDetailService,
                               IProspectAgentMutationService _prospectAgentMutationService)
        {
            prospect.Errors.Clear();
            VDeleteObject(prospect, _prospectService, _prospectDetailService, _prospectAgentMutationService);
            return isValid(prospect);
        }

        public bool isValid(Prospect obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(Prospect obj)
        {
            string erroroutput = "";
            KeyValuePair<string, string> first = obj.Errors.ElementAt(0);
            erroroutput += first.Key + "," + first.Value;
            foreach (KeyValuePair<string, string> pair in obj.Errors.Skip(1))
            {
                erroroutput += Environment.NewLine;
                erroroutput += pair.Key + "," + pair.Value;
            }
            return erroroutput;
        }

    }
}
