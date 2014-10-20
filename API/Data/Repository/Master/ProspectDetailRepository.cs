using Core.DomainModel;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using Data.Repository;
using System.Data;

namespace Data.Repository
{
    public class ProspectDetailRepository : EfRepository<ProspectDetail>, IProspectDetailRepository
    {
        private APIEntities entities;
        public ProspectDetailRepository()
        {
            entities = new APIEntities();
        }

        public IQueryable<ProspectDetail> GetQueryable()
        {
            return FindAll();
        }

        public IList<ProspectDetail> GetAll()
        {
            return FindAll().ToList();
        }

        public IList<ProspectDetail> GetAllByMonthCreated()
        {
            return FindAll(x => x.CreatedAt.Month == DateTime.Today.Month && !x.IsDeleted).ToList();
        }

        public IList<ProspectDetail> GetObjectsByProspectId(int prospectId)
        {
            return FindAll(x => x.ProspectId == prospectId && !x.IsDeleted).ToList();
        }

        public ProspectDetail GetObjectById(int Id)
        {
            ProspectDetail prospectDetail = Find(x => x.Id == Id && !x.IsDeleted);
            if (prospectDetail != null) { prospectDetail.Errors = new Dictionary<string, string>(); }
            return prospectDetail;
        }

        public ProspectDetail CreateObject(ProspectDetail prospectDetail)
        {
            string ParentCode = "";
            ParentCode = prospectDetail.ProspectId + ".";
            prospectDetail.Code = SetObjectCode(ParentCode);
            prospectDetail.IsConfirmed = false;
            prospectDetail.IsDeleted = false;
            prospectDetail.CreatedAt = DateTime.Now;
            return Create(prospectDetail);
        }

        public ProspectDetail UpdateObject(ProspectDetail prospectDetail)
        {
            prospectDetail.UpdatedAt = DateTime.Now;
            Update(prospectDetail);
            return prospectDetail;
        }

        public ProspectDetail SoftDeleteObject(ProspectDetail prospectDetail)
        {
            prospectDetail.IsDeleted = true;
            prospectDetail.DeletedAt = DateTime.Now;
            Update(prospectDetail);
            return prospectDetail;
        }

        public bool DeleteObject(int Id)
        {
            ProspectDetail prospectDetail =  Find(x => x.Id == Id);
            return (Delete(prospectDetail) == 1) ? true : false;
        }

        public ProspectDetail ConfirmObject(ProspectDetail prospectDetail)
        {
            prospectDetail.IsConfirmed = true;
            Update(prospectDetail);
            return prospectDetail;
        }

        public ProspectDetail UnconfirmObject(ProspectDetail prospectDetail)
        {
            prospectDetail.IsConfirmed = false;
            prospectDetail.ConfirmationDate = null;
            prospectDetail.UpdatedAt = DateTime.Now;
            Update(prospectDetail);
            return prospectDetail;
        }

        public string SetObjectCode(string ParentCode)
        {
            int totalnumberinthemonth = GetAllByMonthCreated().Count() + 1;
            string Code = ParentCode + totalnumberinthemonth;
            return Code;
        } 
    }
}