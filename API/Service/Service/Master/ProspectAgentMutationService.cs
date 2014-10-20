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
    public class ProspectAgentMutationService : IProspectAgentMutationService
    {
        private IProspectAgentMutationRepository _repository;
        private IProspectAgentMutationValidator _validator;
        public ProspectAgentMutationService(IProspectAgentMutationRepository _prospectAgentMutationRepository, IProspectAgentMutationValidator _prospectAgentMutationValidator)
        {
            _repository = _prospectAgentMutationRepository;
            _validator = _prospectAgentMutationValidator;
        }

        public IProspectAgentMutationValidator GetValidator()
        {
            return _validator;
        }

        public IProspectAgentMutationRepository GetRepository()
        {
            return _repository;
        }

        public IQueryable<ProspectAgentMutation> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<ProspectAgentMutation> GetAll()
        {
            return _repository.GetAll();
        }

        public Agent GetAgent(ProspectAgentMutation prospectAgentMutation)
        {
            return _repository.GetAgent(prospectAgentMutation);
        }

        public Agent GetRefereeAgent(ProspectAgentMutation prospectAgentMutation)
        {
            return _repository.GetRefereeAgent(prospectAgentMutation);
        }

        public Agent GetDirectLeader(ProspectAgentMutation prospectAgentMutation)
        {
            return _repository.GetDirectLeader(prospectAgentMutation);
        }

        public IList<ProspectAgentMutation> GetObjectsByProspectId(int prospectId)
        {
            return _repository.GetObjectsByProspectId(prospectId);
        }

        public ProspectAgentMutation GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public ProspectAgentMutation CreateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectAgentMutation.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(prospectAgentMutation, _agentService, _prospectService) ? _repository.CreateObject(prospectAgentMutation) : prospectAgentMutation);
        }

        public ProspectAgentMutation UpdateObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            return (prospectAgentMutation = _validator.ValidUpdateObject(prospectAgentMutation, _agentService, _prospectService) ? _repository.UpdateObject(prospectAgentMutation) : prospectAgentMutation);
        }

        public ProspectAgentMutation SoftDeleteObject(ProspectAgentMutation prospectAgentMutation)
        {
            return (prospectAgentMutation = _validator.ValidDeleteObject(prospectAgentMutation) ? _repository.SoftDeleteObject(prospectAgentMutation) : prospectAgentMutation);
        }

        public ProspectAgentMutation ConfirmObject(ProspectAgentMutation prospectAgentMutation, DateTime ConfirmationDate, IAgentService _agentService, IProspectService _prospectService)
        {
            prospectAgentMutation.ConfirmationDate = ConfirmationDate;
            if (_validator.ValidConfirmObject(prospectAgentMutation, _agentService, _prospectService))
            {
                _repository.ConfirmObject(prospectAgentMutation);
            }
            return prospectAgentMutation;
        }

        public ProspectAgentMutation UnconfirmObject(ProspectAgentMutation prospectAgentMutation, IAgentService _agentService, IProspectService _prospectService)
        {
            if (_validator.ValidUnconfirmObject(prospectAgentMutation, _agentService, _prospectService))
            {
                _repository.UnconfirmObject(prospectAgentMutation);
            }
            return prospectAgentMutation;
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }
    }
}