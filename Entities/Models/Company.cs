using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        public string CompanyId { get; set; }    
        public Company()
        {
            CompanyId = Guid.NewGuid().ToString();
        }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string ContactEmail { get; set; }
        public List<User> Users { get; set; }
    }


}
