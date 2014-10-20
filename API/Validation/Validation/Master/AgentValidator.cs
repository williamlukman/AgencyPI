using Core.DomainModel;
using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Constants;

namespace Validation.Validation
{
    public class AgentValidator : IAgentValidator
    {
        public Agent VHasUniqueCode(Agent agent, IAgentService _agentService)
        {
            if (String.IsNullOrEmpty(agent.Code) || agent.Code.Trim() == "")
            {
                agent.Errors.Add("Code", "Tidak boleh kosong");
            }
            if (_agentService.IsCodeDuplicated(agent))
            {
                agent.Errors.Add("Code", "Tidak boleh diduplikasi");
            }
            return agent;
        }

        public Agent VHasNoProspects(Agent agent, IProspectService _prospectService)
        {
            IList<Prospect> prospects = _prospectService.GetObjectsByAgentId(agent.Id);
            if (prospects.Any())
            {
                agent.Errors.Add("Generic", "Tidak bisa dihapus. Prospect yang berhubungan dengan agent " + agent.Name +
                                            " harus dipindahtangankan terlebih dahulu");
            }
            return agent;
        }

        public Agent VHasName(Agent agent)
        {
            if (String.IsNullOrEmpty(agent.Name) || agent.Name.Trim() == "")
            {
                agent.Errors.Add("Name", "Tidak boleh kosong");
            }
            return agent;
        }

        public Agent VHasPosition(Agent agent)
        {
            if (agent.Position != Constant.AgentPosition.BusinessExecutive &&
                agent.Position != Constant.AgentPosition.BusinessPartner)
            {
                agent.Errors.Add("Generic", "Agen harus merupakan BE atau BP");
            }
            return agent;
        }

        public Agent VNonNullHasDirectLeader(Agent agent, IAgentService _agentService)
        {
            if (!agent.IsOwner)
            {
                if(agent.DirectLeaderId == null)
                {
                    agent.Errors.Add("Generic", "Direct Leader tidak boleh kosong"); 
                }
                else if (_agentService.GetObjectById((int)agent.DirectLeaderId) == null)
                {
                    agent.Errors.Add("Generic", "Direct Leader tidak ditemukan");
                }
            }
            return agent;
        }

        public Agent VCreateObject(Agent agent, IAgentService _agentService)
        {
            VHasUniqueCode(agent, _agentService);
            if (!isValid(agent)) { return agent; }
            VHasName(agent);
            if (!isValid(agent)) { return agent; }
            VHasPosition(agent);
            if (!isValid(agent)) { return agent; }
            VNonNullHasDirectLeader(agent, _agentService);
            return agent;
        }

        public Agent VUpdateObject(Agent agent, IAgentService _agentService)
        {
            return VCreateObject(agent, _agentService);
        }

        public Agent VDeleteObject(Agent agent, IProspectService _prospectService)
        {
            VHasNoProspects(agent, _prospectService);
            return agent;
        }

        public bool ValidCreateObject(Agent agent, IAgentService _agentService)
        {
            VCreateObject(agent, _agentService);
            return isValid(agent);
        }

        public bool ValidUpdateObject(Agent agent, IAgentService _agentService)
        {
            agent.Errors.Clear();
            VUpdateObject(agent, _agentService);
            return isValid(agent);
        }

        public bool ValidDeleteObject(Agent agent, IProspectService _prospectService)
        {
            agent.Errors.Clear();
            VDeleteObject(agent, _prospectService);
            return isValid(agent);
        }
        
        public bool isValid(Agent obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(Agent obj)
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
