using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Coles.Appreciate.Models
{
    public class ColesAppreciateDataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ColesAppreciateDataContext() : base("name=ColesAppreciateDataContext")
        {
        }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.Appreciation> Appreciations { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.AppreciationAgree> AppreciationAgrees { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.Response> Responses { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.Reason> Reasons { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.AppreciationReason> AppreciationReasons { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.AppreciationTarget> AppreciationTargets { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.Status> Status { get; set; }
    }
}
