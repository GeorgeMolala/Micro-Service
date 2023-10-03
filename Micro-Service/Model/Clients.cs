using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Model
{
    public class Clients
    {
        [Key]
        public int CLientID { get; set; }

        [Required]
        public string FirtName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public double MobileNumber { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        public double IdNumber { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }

        [Required]
        public int CityID { get; set; }
        public City City { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }

    }
}
