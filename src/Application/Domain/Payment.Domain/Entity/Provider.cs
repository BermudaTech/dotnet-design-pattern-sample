using Bermuda.Core.Database.Entity;
using Payment.Core.Enumeration;
using System.Collections.Generic;

namespace Payment.Domain.Entity
{
    public class Provider : EntityBase
    {
        public virtual string Name { get; protected set; }
        public virtual ProviderType ProviderType { get; protected set; }
        public virtual ICollection<BankProvider> BankProviders { get; protected set; }

        public Provider(
            string name,
            ProviderType providerType)
        {
            Name = name;
            ProviderType = providerType;
        }
    }
}
