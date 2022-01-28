using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Data.Dto
{
    public class UpdateCountryDtO
    {
        public IList<CreateHotelDto> Hotels { get; set; }
    }
}
