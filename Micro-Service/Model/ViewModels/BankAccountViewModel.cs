﻿using Micro_Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.ViewModels
{
    public class BankAccountViewModel
    {
           
            public IEnumerable<BankAccount> BankAccounts { get; set; }
            public RouteDictionary CurrentRoute { get; set; }
            public int TotalPages { get; set; }


            public Dictionary<string, string> AccountType =>
          new Dictionary<string, string> {
                { "Savings", "Savings" },
                { "Cheque", "Cheque" },
                { "Fixed Deposit", "Fixed Deposit" }
       };


            public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
     } 
}

