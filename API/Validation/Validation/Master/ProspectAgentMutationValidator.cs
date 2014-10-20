using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface.Validation;
using Core.DomainModel;
using Core.Interface.Service;

namespace Validation.Validation
{
    public class ProspectAgentMutationValidator : IProspectAgentMutationValidator
    {
        public ProspectAgentMutation VHasProspect(ProspectAgentMutation ProspectAgentMutation, IProspectService _prospectService)
        {
            if (ProspectAgentMutation.ProspectId == null)
            {
                ProspectAgentMutation.Errors.Add("ProspectId", "Tidak boleh kosong");
            }
            else if (_prospectService.GetObjectById(ProspectAgentMutation.ProspectId) == null)
            {
                ProspectAgentMutation.Errors.Add("ProspectId", "Tidak terasosiasi dengan Prospect");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasNewAgent(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService)
        {
            Agent newAgent = _agentService.GetObjectById(ProspectAgentMutation.NewAgentId);
            if (newAgent == null)
            {
                ProspectAgentMutation.Errors.Add("NewAgentId", "Tidak terasosiasi dengan New Agent");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasRefereeAgent(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService)
        {
            Agent refereeAgent = _agentService.GetObjectById(ProspectAgentMutation.RefereeAgentId);
            if (refereeAgent == null)
            {
                ProspectAgentMutation.Errors.Add("RefereeAgentId", "Tidak terasosiasi dengan Referee Agent");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasDirectLeader(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService)
        {
            Agent directLeader = _agentService.GetObjectById(ProspectAgentMutation.NewDirectLeaderId);
            if (directLeader == null)
            {
                ProspectAgentMutation.Errors.Add("NewDirectLeaderId", "Tidak terasosiasi dengan Direct Leader");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasRegistrationDate(ProspectAgentMutation ProspectAgentMutation)
        {
            if (ProspectAgentMutation.RegistrationDate == null)
            {
                ProspectAgentMutation.Errors.Add("RegistrationDate", "Tidak boleh kosong");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasNotBeenConfirmed(ProspectAgentMutation ProspectAgentMutation)
        {
            if (ProspectAgentMutation.IsConfirmed)
            {
                ProspectAgentMutation.Errors.Add("Generic", "Tidak boleh sudah dikonfirmasi");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasBeenConfirmed(ProspectAgentMutation ProspectAgentMutation)
        {
            if (!ProspectAgentMutation.IsConfirmed)
            {
                ProspectAgentMutation.Errors.Add("Generic", "Harus sudah dikonfirmasi");
            }
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VCreateObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            VHasProspect(ProspectAgentMutation, _prospectService);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VHasNewAgent(ProspectAgentMutation, _agentService);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VHasRefereeAgent(ProspectAgentMutation, _agentService);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VHasDirectLeader(ProspectAgentMutation, _agentService);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VHasRegistrationDate(ProspectAgentMutation);
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VUpdateObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            VHasNotBeenConfirmed(ProspectAgentMutation);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VCreateObject(ProspectAgentMutation, _agentService, _prospectService);
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VDeleteObject(ProspectAgentMutation ProspectAgentMutation)
        {
            VHasNotBeenConfirmed(ProspectAgentMutation);
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VHasConfirmationDate(ProspectAgentMutation obj)
        {
            if (obj.ConfirmationDate == null)
            {
                obj.Errors.Add("ConfirmationDate", "Tidak boleh kosong");
            }
            return obj;
        }

        public ProspectAgentMutation VConfirmObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            VHasConfirmationDate(ProspectAgentMutation);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VHasNotBeenConfirmed(ProspectAgentMutation);
            if (!isValid(ProspectAgentMutation)) { return ProspectAgentMutation; }
            VCreateObject(ProspectAgentMutation, _agentService, _prospectService);
            return ProspectAgentMutation;
        }

        public ProspectAgentMutation VUnconfirmObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            VHasBeenConfirmed(ProspectAgentMutation);
            return ProspectAgentMutation;
        }

        public bool ValidCreateObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            VCreateObject(ProspectAgentMutation, _agentService, _prospectService);
            return isValid(ProspectAgentMutation);
        }

        public bool ValidUpdateObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            ProspectAgentMutation.Errors.Clear();
            VUpdateObject(ProspectAgentMutation, _agentService, _prospectService);
            return isValid(ProspectAgentMutation);
        }

        public bool ValidDeleteObject(ProspectAgentMutation ProspectAgentMutation)
        {
            ProspectAgentMutation.Errors.Clear();
            VDeleteObject(ProspectAgentMutation);
            return isValid(ProspectAgentMutation);
        }

        public bool ValidConfirmObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            ProspectAgentMutation.Errors.Clear();
            VConfirmObject(ProspectAgentMutation, _agentService, _prospectService);
            return isValid(ProspectAgentMutation);
        }

        public bool ValidUnconfirmObject(ProspectAgentMutation ProspectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            ProspectAgentMutation.Errors.Clear();
            VUnconfirmObject(ProspectAgentMutation, _agentService, _prospectService);
            return isValid(ProspectAgentMutation);
        }

        public bool isValid(ProspectAgentMutation obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(ProspectAgentMutation obj)
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