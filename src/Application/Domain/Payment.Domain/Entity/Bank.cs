using Bermuda.Core.Database.Entity;
using System.Collections.Generic;

namespace Payment.Domain.Entity
{
    public class Bank : EntityBase
    {
        public virtual int Code { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual ICollection<BankBin> BankBins { get; protected set; }
        public virtual ICollection<BankProvider> BankProviders { get; protected set; }

        public Bank() { }

        public Bank(
            int code,
            string name)
        {
            Code = code;
            Name = name;
        }

        public void UpdateBank(
            int code,
            string name)
        {
            Code = code;
            Name = name;
        }
    }
}
