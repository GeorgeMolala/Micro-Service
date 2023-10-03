using Micro_Service.Data.Grid;
using Micro_Service.Data.Options;
using Micro_Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.QueryOptions
{
    public class BankAccountQueryOptions:QueryOptions<BankAccount>
    {
        public void SortFilter(BankAccountGridBuilder builder)
        {
                 

            if (builder.IsFilterByAccountType)
            {
                if (builder.CurrentRoute.AccountTypeFilter == "Savings")
                    Where = b => b.AccountType == "Savings";
                else if (builder.CurrentRoute.AccountTypeFilter == "Cheque")
                    Where = b => b.AccountType == "Cheque";
                else if (builder.CurrentRoute.AccountTypeFilter == "FixedDeposit")
                    Where = b => b.AccountType == "FixedDeposit";
            }

           

        }

    }
}
