using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coles.Appreciate.Domain
{
    public class Response
    {

        public Response(string ResponseId, string ResponseText)
        {
            this.ResponseId= ResponseId ;
            this.ResponseText= ResponseText;
        }

        public string ResponseId { get; set; }

        public string ResponseText { get; set; }

    }
}
