using Micro_Service.Data.DTO;
using Micro_Service.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.Grid
{
    public class ClientGridBuilder:GridBuilder
    {
        public ClientGridBuilder(ISession sess) : base(sess) { }

        public ClientGridBuilder(ISession sess, ClientGridDTO values, string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isinitial = values.AccountType.IndexOf(FilterPrefix.AccountType) == -1;
            routes.ClientFilter = (isinitial) ? FilterPrefix.Client + values.AccountType : values.AccountType;


            SaveRouteSegments();
        }

        public void LoadFilterSegments(string[] filter, Clients client)
        {
            if (client == null)
            {
                routes.AccountTypeFilter = FilterPrefix.AccountType + filter[0];
            }
            else
            {
                routes.AccountTypeFilter = FilterPrefix.AccountType + filter[0] + "-" + client.FirtName.Slug();
            }

            routes.AccountTypeFilter = FilterPrefix.AccountType + filter[0];

        }

        //public void ClearFilterSegments() => routes.ClientFilter;


        string def = ClientGridDTO.DefaultFilter;

        //  string default = NurseGridDTO.DefaultFilter; 
        public bool iSFilterByAccountType => routes.AccountTypeFilter != def;
       

        public bool IsSortBy => routes.SortField.EqualsNoCase(nameof(Clients));
    }
}
