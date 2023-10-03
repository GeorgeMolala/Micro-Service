using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Model
{
    public class BankAccount
    {
       [Key]
        public int AccountID { get; set; }

        [Required]
        public string AccounNumer { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Status { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public int ClientID { get; set; }
        public Clients Clients { get; set; }

    
    }
}
