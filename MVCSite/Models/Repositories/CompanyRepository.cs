using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSite.Models.Data;

namespace MVCSite.Models.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>
    {
        public CompanyRepository(MVCSiteDataContext mvcSiteEntities) : base(mvcSiteEntities)
        {

        }

        public Company GetByID(int id)
        {
            return GetAll(x => x.CompanyID == id).FirstOrDefault();
        }

        public override IQueryable<Company> GetAll()
        {
            return base.GetAll(x=>true);
        }
    }
}