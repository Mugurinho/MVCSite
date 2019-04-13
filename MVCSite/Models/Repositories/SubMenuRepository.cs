using MVCSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSite.Models.Repositories
{
    public class SubMenuRepository
    {
        public IEnumerable<SubMenu> GetSubMenues()
        {
            //add submenu elements here
            yield return new SubMenu
            {
                Title = "Employees",
                Description = "Employees management page",
                Action = "Index",
                Controller = "Employee",
                BtnName = "Show employees"
            };

            yield return new SubMenu
            {
                Title = "Companies",
                Description = "Companies management page",
                Action = "Index",
                Controller = "Company",
                BtnName = "Show companies"
            };
        }

       
    }
}