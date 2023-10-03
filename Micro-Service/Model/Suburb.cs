using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Model
{
    public class Suburb
    {
        [Key]
        public int SuburbID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
