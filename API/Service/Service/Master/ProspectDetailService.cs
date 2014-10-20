using Core.DomainModel;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Service
{
    public class ProspectDetailService : IProspectDetailService
    {
        private IProspectDetailRepository _repository;
        private IProspectDetailValidator _validator;
        public ProspectDetailService(IProspectDetailRepository _prospectDetailRepository, IProspectDetailValidator _prospectDetailValidator)
        {
            _repository = _prospectDetailRepository;
            _validator = _prospectDetailValidator;
        }

        public IProspectDetailValidator GetValidator()
        {
            return _validator;
        }

        public IProspectDetailRepository GetRepository()
        {
            return _repository;
        }

        public IQueryable<ProspectDetail> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<ProspectDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<ProspectDetail> GetObjectsByProspectId(int ProspectId)
        {
            return _repository.GetObjectsByProspectId(ProspectId);
        }

        public ProspectDetail GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public ProspectDetail CreateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectDetail.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(prospectDetail, _agentService, _prospectService) ? _repository.CreateObject(prospectDetail) : prospectDetail);
        }

        public ProspectDetail UpdateObject(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            return (prospectDetail = _validator.ValidUpdateObject(prospectDetail, _agentService, _prospectService) ? _repository.UpdateObject(prospectDetail) : prospectDetail);
        }

        public ProspectDetail SoftDeleteObject(ProspectDetail prospectDetail)
        {
            return (prospectDetail = _validator.ValidDeleteObject(prospectDetail) ? _repository.SoftDeleteObject(prospectDetail) : prospectDetail);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        public ProspectDetail ConfirmObject(ProspectDetail prospectDetail, DateTime ConfirmationDate, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectDetail.ConfirmationDate = ConfirmationDate;
            if (_validator.ValidConfirmObject(prospectDetail, _agentService, _prospectService))
            {
                _repository.ConfirmObject(prospectDetail);
            }
            return prospectDetail;
        }

        public ProspectDetail UnconfirmObject(ProspectDetail prospectDetail)
        {
            if (_validator.ValidUnconfirmObject(prospectDetail))
            {
                _repository.UnconfirmObject(prospectDetail);
            }
            return prospectDetail;
        }

        public ProspectDetail GiveFeedback(ProspectDetail prospectDetail, IAgentService _agentService, IProspectService _prospectService)
        {
            if (_validator.ValidGiveFeedback(prospectDetail, _agentService, _prospectService))
            {
                _repository.UpdateObject(prospectDetail);
            }
            return prospectDetail;
        }
    }
}