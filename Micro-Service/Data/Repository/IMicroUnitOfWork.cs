using Micro_Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.Repository
{
    public interface IMicroUnitOfWork
    {
       

        Repository<BankAccount> BankAccounts { get; }
        Repository<Clients> Client { get; }
        Repository<City> Cities { get; }
        Repository<Suburb> Suburbs { get; }

    }
}
