using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}
