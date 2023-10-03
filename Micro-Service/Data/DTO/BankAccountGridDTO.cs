using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data.DTO
{
    public class BankAccountGridDTO:GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Client { get; set; } = DefaultFilter;
        public string AccountType { get; set; } = DefaultFilter;
       
    }
}
