using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Data.Dto
{
    public class CreateCountryDto
    {

            [Required]
            public string Name { get; set; }
            [Required]
            [StringLength(maximumLength: 10, ErrorMessage = "Short Name is Too Long!")]
            public string ShortName { get; set; }
        
    }
}
