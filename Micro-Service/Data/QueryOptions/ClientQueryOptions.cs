using Micro_Service.Data.Grid;
using Micro_Service.Data.Options;
using Micro_Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.QueryOptions
{
    public class ClientQueryOptions:QueryOptions<Clients>
    {
        public void SortFilter(ClientGridBuilder builder)
        {
            //if (builder.iSFilterByAccountType)
            //{
            //    if (builder.CurrentRoute.AccountTypeFilter == "Savings")
            //        Where = b => b. == "Assigned";
            //    else if (builder.CurrentRoute.ContractTypeFilter == "Closed")
            //        Where = b => b.Status == "Closed";
            //    else
            //        Where = b => b.Status == "New";

            //    //if (builder.IsSortBySuburb)
            //    //{
            //    //    OrderBy = b => b.Suburbs.Name;
            //    //}
            //    if (builder.IsSortByName)
            //{
            //    OrderBy = b => b.FirstName;
            //}
        }

    }
}
