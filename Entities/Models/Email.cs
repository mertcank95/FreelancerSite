using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Email
    {
        //gönderici bilgileri
        public String? SmtpHost { get; set; } // ex: smtp.gmail.com
        public int SmtPort { get; set; } // port num : 587
        public String? SenderEmail { get; set; } // sender email
        public String? Password { get; set; } // sender password 

        //Gönderilen email adresi
        public String? ToEmail { get; set; }
        //data
        public String? Subject { get; set; }
        public String? Body { get; set; }

    }


}
