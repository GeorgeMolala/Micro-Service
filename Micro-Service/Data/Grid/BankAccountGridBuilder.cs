using Micro_Service.Data.DTO;
using Micro_Service.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.Grid
{
    public class BankAccountGridBuilder:GridBuilder
    {
        public BankAccountGridBuilder(ISession sess) : base(sess) { }

        public BankAccountGridBuilder(ISession sess, BankAccountGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.AccountType.IndexOf(FilterPrefix.AccountType) == -1;
            routes.ClientNameFilter = (isinitial) ? FilterPrefix.Client + values.Client : values.Client;
            

            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, BankAccount account)
        {
            if (account == null)
            {
                routes.AccountTypeFilter = FilterPrefix.AccountType + filter[0];
            }
            else
            {
                routes.AccountTypeFilter = FilterPrefix.AccountType + filter[0] + "-" + account.AccountType.Slug();
            }

            //routes.ClientNameFilter = FilterPrefix.Client + filter[1];

        }

        public void ClearFilterSegments() => routes.ClearFilters();


        string def = BankAccountGridDTO.DefaultFilter;
        //  string default = NurseGridDTO.DefaultFilter; 
        public bool IsFilterByAccountType => routes.AccountTypeFilter != def;
        public bool IsFilterByClienName => routes.ClientNameFilter != def;

        public bool IsSortByNurse => routes.SortField.EqualsNoCase(nameof(BankAccount));
    }
}
