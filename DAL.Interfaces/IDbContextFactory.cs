using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.Entity;

namespace DAL.Interfaces
{
    public interface IDbContextFactory
    {
        DbContext GetContext(ContextType contextType);
        DbContext Create();
        void Release(DbContext context);
    }
}
