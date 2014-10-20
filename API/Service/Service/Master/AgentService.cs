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
    public class AgentService : IAgentService
    {
        private IAgentRepository _repository;
        private IAgentValidator _validator;
        public AgentService(IAgentRepository _agentRepository, IAgentValidator _agentValidator)
        {
            _repository = _agentRepository;
            _validator = _agentValidator;
        }

        public IAgentValidator GetValidator()
        {
            return _validator;
        }

        public IAgentRepository GetRepository()
        {
            return _repository;
        }

        public IQueryable<Agent> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<Agent> GetAll()
        {
            return _repository.GetAll();
        }

        public Agent GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public Agent CreateObject(Agent agent)
        {
            if (_validator.ValidCreateObject(agent, this))
            {
                agent = _repository.CreateObject(agent);
            }
            return agent;
        }

        public Agent UpdateObject(Agent agent)
        {
            if (_validator.ValidUpdateObject(agent, this))
            {
                agent = _repository.UpdateObject(agent);
            }
            return agent;
        }

        public Agent SoftDeleteObject(Agent agent, IProspectService _prospectService)
        {
            if (_validator.ValidDeleteObject(agent, _prospectService))
            {
                _repository.SoftDeleteObject(agent);
            }
            return agent;
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        public bool IsCodeDuplicated(Agent agent)
        {
            return _repository.IsCodeDuplicated(agent);
        }
    }
}