using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coles.Appreciate.Web.Models
{
    public class AppreciateViewModel
    {
        public int AppreciateId { get; set; }

        public AppreciateViewModel(int AppreciateId)
        {
            this.AppreciateId = AppreciateId;
        }
    }
}