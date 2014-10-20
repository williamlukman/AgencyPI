using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface.Validation;
using Core.DomainModel;
using Core.Interface.Service;
using Core.Constants;

namespace Validation.Validation
{
    public class ProspectDetailValidator : IProspectDetailValidator
    {
        public ProspectDetail VHasProspect(ProspectDetail prospectDetail, IProspectService _ProspectService)
        {
            Prospect prospect = _ProspectService.GetObjectById(prospectDetail.ProspectId);
            if (prospect == null)
            {
                prospectDetail.Errors.Add("ProspectId", "Tidak terasosiasi dengan Stock Adjustment");
            }
            return prospectDetail;
        }

        public ProspectDetail VHasNature(ProspectDetail prospectDetail)
        {
            if (prospectDetail.Nature != Constant.ProspectDetailNature.UpdateAppointment &&
                prospectDetail.Nature != Constant.ProspectDetailNature.UpdateMeeting &&
                prospectDetail.Nature != Constant.ProspectDetailNature.UpdatePresentation &&
                prospectDetail.Nature != Constant.ProspectDetailNature.FollowUp &&
                prospectDetail.Nature != Constant.ProspectDetailNature.JoinFieldWork &&
                prospectDetail.Nature != Constant.ProspectDetailNature.Recruit)
            {
                prospectDetail.Errors.Add("Nature", "Pilihlah dari dropdown list yang sudah disediakan");
            }
            return prospectDetail;
        }

        public ProspectDetail VAgentHasPermissionForDetailNature(ProspectDetail prospectDetail, IProspectService _prospectService, IAgentService _agentService)
        {
            Prospect prospect = _prospectService.GetObjectById(prospectDetail.ProspectId);
            Agent agent = _agentService.GetObjectById(prospect.AgentId);
            if (agent.Position == Constant.AgentPosition.BusinessExecutive)
            {
                if (prospectDetail.Nature == Constant.ProspectDetailNature.Recruit ||
                    prospectDetail.Nature == Constant.ProspectDetailNature.JoinFieldWork)
                {
                    prospectDetail.Errors.Add("Generic", "Agent tidak memiliki akses untuk melakukan aktivitas ini. Hubungi Direct Leader anda.");
                }
            }
            return prospectDetail;
        }

        public ProspectDetail VHasAppointedDate(ProspectDetail prospectDetail)
        {
            if (prospectDetail.AppointedDate == null)
            {
                prospectDetail.Errors.Add("AppointedDate", "Tidak boleh kosong");
            }
            return prospectDetail;
        }

        public ProspectDetail VHasBeenConfirmed(ProspectDetail prospectDetail)
        {
            if (!prospectDetail.IsConfirmed)
            {
                prospectDetail.Errors.Add("Generic", "Prospect detail belum dikonfirmasi");
            }
            return prospectDetail;
        }

        public ProspectDetail VHasNotBeenConfirmed(ProspectDetail prospectDetail)
        {
            if (prospectDetail.IsConfirmed)
            {
                prospectDetail.Errors.Add("Generic", "Prospect detail sudah dikonfirmasi");
            }
            return prospectDetail;
        }

        public ProspectDetail VHasBeenCompleted(ProspectDetail prospectDetail)
        {
            if (!prospectDetail.IsCompleted)
            {
                prospectDetail.Errors.Add("Generic", "Prospect detail belum complete");
            }
            return prospectDetail;
        }

        public ProspectDetail VHasNotBeenCompleted(ProspectDetail prospectDetail)
        {
            if (prospectDetail.IsCompleted)
            {
                prospectDetail.Errors.Add("Generic", "Prospect detail sudah complete");
            }
            return prospectDetail;
        }

        public ProspectDetail VHasResponse(ProspectDetail prospectDetail)
        {
            if (String.IsNullOrEmpty(prospectDetail.Response) || prospectDetail.Response.Trim() == "")
            {
                prospectDetail.Errors.Add("Response", "Harus diisi dengan laporan anda");
            }
            return prospectDetail;
        }

        public ProspectDetail VCreateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            VHasProspect(prospectDetail, _prospectService);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VHasAppointedDate(prospectDetail);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VHasNature(prospectDetail);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VAgentHasPermissionForDetailNature(prospectDetail, _prospectService, _agentService);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VHasNotBeenConfirmed(prospectDetail);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VHasNotBeenCompleted(prospectDetail);
            return prospectDetail;
        }

        public ProspectDetail VUpdateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            VCreateObject(prospectDetail, _agentService, _prospectService);
            return prospectDetail;
        }

        public ProspectDetail VDeleteObject(ProspectDetail prospectDetail)
        {
            VHasNotBeenConfirmed(prospectDetail);
            return prospectDetail;
        }

        public ProspectDetail VHasConfirmationDate(ProspectDetail prospectDetail)
        {
            if (prospectDetail.ConfirmationDate == null)
            {
                prospectDetail.Errors.Add("ConfirmationDate", "Tidak boleh kosong");
            }
            return prospectDetail;
        }

        public ProspectDetail VConfirmObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            VCreateObject(prospectDetail, _agentService, _prospectService);
            return prospectDetail;
        }

        public ProspectDetail VUnconfirmObject(ProspectDetail prospectDetail)
        {
            VHasBeenConfirmed(prospectDetail);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VHasNotBeenCompleted(prospectDetail);
            return prospectDetail;
        }

        public ProspectDetail VGiveFeedback(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            VCreateObject(prospectDetail, _agentService, _prospectService);
            if (!isValid(prospectDetail)) { return prospectDetail; }
            VHasResponse(prospectDetail);
            return prospectDetail;
        }

        public bool ValidCreateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            VCreateObject(prospectDetail, _agentService, _prospectService);
            return isValid(prospectDetail);
        }

        public bool ValidUpdateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectDetail.Errors.Clear();
            VUpdateObject(prospectDetail, _agentService, _prospectService);
            return isValid(prospectDetail);
        }

        public bool ValidDeleteObject(ProspectDetail prospectDetail)
        {
            prospectDetail.Errors.Clear();
            VDeleteObject(prospectDetail);
            return isValid(prospectDetail);
        }

        public bool ValidConfirmObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectDetail.Errors.Clear();
            VConfirmObject(prospectDetail, _agentService, _prospectService);
            return isValid(prospectDetail);
        }

        public bool ValidUnconfirmObject(ProspectDetail prospectDetail)
        {
            prospectDetail.Errors.Clear();
            VUnconfirmObject(prospectDetail);
            return isValid(prospectDetail);
        }

        public bool ValidGiveFeedback(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectDetail.Errors.Clear();
            VGiveFeedback(prospectDetail, _agentService, _prospectService);
            return isValid(prospectDetail);
        }

        public bool isValid(ProspectDetail obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(ProspectDetail obj)
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