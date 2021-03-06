﻿using Bermuda.Core.Repository.Repository;
using Bermuda.Core.Repository.UnitOfWork;
using Payment.Domain.Entity;
using System.Threading.Tasks;

namespace Payment.Domain.Repository
{
    public interface IBankBinRepository : IRepository<BankBin>
    {
        Task<BankBin> GetByBinNumberAsync(IUnitOfWork unitOfWork, int binNumber);
    }
}
