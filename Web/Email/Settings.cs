using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Email
{
    public class Settings
    {
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string MailGunDomain { get; set; }
        public string MailGunApiKey { get; set; }
    }
}
