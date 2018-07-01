using Logger.DAL.Core;
using Logger.DAL;

namespace Logger.BAL.Interfaces
{
    public enum TransactionTypes
    {
        Income = 1,
        Expenditure = 2
    }

    public interface ITransactionRepository : IRepository<FinancialTransaction>
    {

    }
}
