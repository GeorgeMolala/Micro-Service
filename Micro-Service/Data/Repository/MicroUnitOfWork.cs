using Micro_Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.Repository
{
    public class MicroUnitOfWork:IMicroUnitOfWork
    {
        private Micro_ServiceContextDb context { get; set; }

        public MicroUnitOfWork(Micro_ServiceContextDb ctx) => context = ctx;

       

        private Repository<BankAccount> BankAccountData;
        public Repository<BankAccount> BankAccounts
        {
            get
            {
                if (BankAccountData == null)
                    BankAccountData = new Repository<BankAccount>(context);

                return BankAccountData;
            }
        }

        private Repository<Clients> ClientData;
        public Repository<Clients> Client
        {
            get
            {
                if (ClientData == null)
                    ClientData = new Repository<Clients>(context);
                return ClientData;
            }
        }

        private Repository<City> CityData;
        public Repository<City> Cities
        {
            get
            {
                if (CityData == null)
                    CityData = new Repository<City>(context);
                return CityData;
            }
        }

        private Repository<Suburb> SuburbsData;
        public Repository<Suburb> Suburbs
        {
            get
            {
                if (SuburbsData == null)
                    SuburbsData = new Repository<Suburb>(context);
                return SuburbsData;
            }
        }

    }
}
