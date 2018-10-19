using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.Entity;

namespace DAL.Model
{
    public class DbEntities : DbContext
    {
        public DbEntities(): base("name=DBEntities") { }
        public DbSet<Bittrex> Bittrexes { get; set; }
        public DbSet<MarketType> MarketTypes { get; set; }
    }
}
