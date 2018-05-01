using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Domain.Business
{
    public class ContactUs
    {
        public int SubmissionId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMessage { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
