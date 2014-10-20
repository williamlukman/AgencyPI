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
    public class ProspectService : IProspectService
    {
        private IProspectRepository _repository;
        private IProspectValidator _validator;
        public ProspectService(IProspectRepository _prospectRepository, IProspectValidator _prospectValidator)
        {
            _repository = _prospectRepository;
            _validator = _prospectValidator;
        }

        public IProspectValidator GetValidator()
        {
            return _validator;
        }

        public IQueryable<Prospect> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<Prospect> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Prospect> GetObjectsByAgentId(int AgentId)
        {
            return _repository.GetObjectsByAgentId(AgentId);
        }

        public IList<Prospect> GetObjectsByFirstName(string FirstName)
        {
            return _repository.GetObjectsByFirstName(FirstName);
        }

        public IList<Prospect> GetObjectsByLastName(string LastName)
        {
            return _repository.GetObjectsByLastName(LastName);
        }

        public IList<Prospect> GetObjectsByFirstAndLastName(string FirstName, string LastName)
        {
            return _repository.GetObjectsByFirstAndLastName(FirstName, LastName);
        }

        public Prospect GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public Prospect CreateObject(Prospect prospect, IAgentService _agentService)
        {
            prospect.Errors = new Dictionary<String, String>();
            if (_validator.ValidCreateObject(prospect, _agentService))
            {
                prospect = _repository.CreateObject(prospect);
            }
            return prospect;
        }

        public Prospect UpdateObject(Prospect prospect, IAgentService _agentService)
        {
            return (prospect = _validator.ValidUpdateObject(prospect, _agentService) ? _repository.UpdateObject(prospect) : prospect);
        }

        public Prospect SoftDeleteObject(Prospect prospect, IProspectDetailService _prospectDetailService, IProspectAgentMutationService _prospectAgentMutationService)
        {
            if (_validator.ValidDeleteObject(prospect, this, _prospectDetailService, _prospectAgentMutationService))
            {
                _repository.SoftDeleteObject(prospect);
            }
            return prospect;
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        public bool IsNameDuplicated(Prospect prospect)
        {
            return _repository.IsNameDuplicated(prospect);
        }
    }
}