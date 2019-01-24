using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coles.Appreciate.Domain
{
    public class Person
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public Person(string UserId, string UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
        }
    }

    public class PersonSearch
    {
        public string SearchTerm { get; set; }
        public Person[] Results { get; set; }

        public PersonSearch(string SearchTerm)
        {
            this.SearchTerm = SearchTerm;
        }
    }
}
