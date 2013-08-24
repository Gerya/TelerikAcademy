using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJewels.Data.Migrations;
using CodeJewels.Models;

namespace CodeJewels.Data
{
    public class CodeJewelsContext : DbContext
    {
        static CodeJewelsContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeJewelsContext, Configuration>());
        }

        public CodeJewelsContext()
            : base("Name=CodeJewelsConnection")
        {

        }

        public DbSet<CodeJewel> CodeJewels { get; set; }
    }
}
