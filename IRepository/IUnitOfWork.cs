using ListingApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.IRepository
{
    interface IUnitOfWork:IDisposable
    {
        IRepository<Country> Countries { get; }
        IRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
