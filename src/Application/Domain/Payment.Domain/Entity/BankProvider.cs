﻿using Bermuda.Core.Database.Entity;

namespace Payment.Domain.Entity
{
    public class BankProvider : EntityBaseWithLog
    {
        public virtual Bank Bank { get; protected set; }
        public virtual Provider Provider { get; protected set; }
        public virtual string Configuration { get; protected set; }

        public BankProvider(
            Bank bank,
            Provider provider,
            string configuration)
        {
            Bank = bank;
            Provider = provider;
            Configuration = configuration;
        }

        public void UpdateBankProvider(
            Bank bank,
            Provider provider,
            string configuration)
        {
            Bank = bank;
            Provider = provider;
            Configuration = configuration;
        }
    }
}
