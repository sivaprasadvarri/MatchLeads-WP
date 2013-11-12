using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MatchLeads.Model
{
    public class StaticDbDataContext : System.Data.Linq.DataContext
    {
        public StaticDbDataContext(string connectionString)
            : base(connectionString)
        {

        }

        public Table<BlCountry> CountryTable
        {
            get
            {
                return GetTable<BlCountry>();
            }
        }

        public Table<BLStates> StateTable
        {
            get
            {
                return GetTable<BLStates>();
            }
        }
    }

    [Table]
    public class BlCountry
    {
        [Column(IsPrimaryKey = true, DbType = "BIGINT NOT NULL Identity", IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public long Id
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string Name
        {
            get;
            set;
        }
    }

    [Table]
    public class BLStates
    {
        [Column(IsPrimaryKey = true, DbType = "BIGINT NOT NULL Identity", IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public long Id
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string Name
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public long CountryId
        {
            get;
            set;
        }
    }
}
