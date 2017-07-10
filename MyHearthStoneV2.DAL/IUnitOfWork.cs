using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.DAL
{
    public interface IUnitOfWork
    {
        bool IsCommitted { get; }
        int Commit();
        void Rollback();
    }
}
