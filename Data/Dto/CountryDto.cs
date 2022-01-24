using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Data.Dto
{
    public class CountryDto
    {
     
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:10, ErrorMessage ="Short Name is Too Long!")]
        public string ShortName { get; set; }
        public  IList<HotelDto> Hotels { get; set; }

    }
}
