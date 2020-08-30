using Bermuda.Core.Database.Entity;

namespace Payment.Domain.Entity
{
    public class BankBin : EntityBaseWithLog
    {
        public virtual long BankId { get; protected set; }
        public virtual Bank Bank { get; protected set; }
        public virtual int BinNumber { get; protected set; }
        public virtual string CardType { get; protected set; }
        public virtual string Organization { get; protected set; }
        public virtual bool IsCommercialCard { get; protected set; }
        public virtual bool IsSupportInstallment { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        public BankBin() { }

        public BankBin(
            Bank bank,
            int binNumber,
            string cardType,
            string organization,
            bool isCommercialCard,
            bool isSupportInstallment,
            bool isActive)
        {
            Bank = bank;
            BinNumber = binNumber;
            CardType = cardType;
            Organization = organization;
            IsCommercialCard = isCommercialCard;
            IsSupportInstallment = isSupportInstallment;
            IsActive = isActive;
        }

        public void UpdateBankBin(
            Bank bank,
            int binNumber,
            string cardType,
            string organization,
            bool isCommercialCard,
            bool isSupportInstallment,
            bool isActive)
        {
            Bank = bank;
            BinNumber = binNumber;
            CardType = cardType;
            Organization = organization;
            IsCommercialCard = isCommercialCard;
            IsSupportInstallment = isSupportInstallment;
            IsActive = isActive;
        }
    }
}
