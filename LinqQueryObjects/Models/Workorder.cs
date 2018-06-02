using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinqQueryObjects.Model
{
    public class Workorder
    {
        public int Id { get; set; }
        public int EnterpriseId { get; set; }
        public string WorkorderNo { get; set; }
        public int StatusId { get; set; }
        [NotMapped]
        public DateTime ? ClosedDate { get; set; }
              
        public ICollection<WorkorderAudit> WorkorderAudits { get; set; }
    }
}