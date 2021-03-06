using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Data.Dto
{
    public class HotelDto
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public double Rating { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
