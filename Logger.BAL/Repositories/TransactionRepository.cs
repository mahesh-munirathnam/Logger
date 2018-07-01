using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL;
using Logger.DAL.Core;

namespace Logger.BAL.Repositories
{
    public class TransactionRepository : Repository<FinancialTransaction>, ITransactionRepository
    {
        public enum TransactionTypes : long
        {
            Income = 1,
            Expenditure = 2
        }

        public TransactionRepository(DbContext context) : base(context)
        {
        }
    }
}
