using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Model
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Suburb> Suburbs { get; set; }
    }
}
