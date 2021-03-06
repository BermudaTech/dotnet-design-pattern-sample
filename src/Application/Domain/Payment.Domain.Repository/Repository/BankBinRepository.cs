﻿using Bermuda.Core.Repository.UnitOfWork;
using Bermuda.Infrastructure.Database.Repository;
using Payment.Domain.Entity;
using System.Threading.Tasks;

namespace Payment.Domain.Repository
{
    public class BankBinRepository : Repository<BankBin>, IBankBinRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BankBinRepository(
            IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<BankBin> GetByBinNumberAsync(IUnitOfWork unitOfWork, int binNumber)
        {
            return await base.GetAsync(unitOfWork, x => x.BinNumber == binNumber);
        }
    }
}
