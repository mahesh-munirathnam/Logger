using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.DAL;
using Logger.DAL.Core;

namespace Logger.BAL.Interfaces
{
    public interface IPersonSessionRepository : IRepository<PersonSession>
    {
    }
}
