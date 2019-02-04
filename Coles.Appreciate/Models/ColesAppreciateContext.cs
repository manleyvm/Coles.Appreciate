using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Coles.Appreciate.Models
{
    public class ColesAppreciateContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ColesAppreciateContext() : base("name=ColesAppreciateContext")
        {

         //   this.Configuration.LazyLoadingEnabled = false;
         //   this.Configuration.ProxyCreationEnabled = false;

        }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.ReasonType> ReasonTypes { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.ResponseType> ResponseTypes { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.Appreciation> Appreciations { get; set; }

        public System.Data.Entity.DbSet<Coles.Appreciate.Domain.Models.AppreciationReason> AppreciationReasons { get; set; }
    }
}
