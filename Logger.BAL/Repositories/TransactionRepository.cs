using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL;
using Logger.DAL.Core;

namespace Logger.BAL.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }
    }
}
