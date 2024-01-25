using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class CompanyRegisterDto
    {
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string ContactEmail { get; set; }
    }
}
